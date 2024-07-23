using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using HL.Shared;

namespace HL.ClientWFApp
{
    public partial class frmMain : Form
    {
        private bool isDataChanged = false;
        private bool isWorkStation = false;

        public frmMain()
        {
            DbParameters dbConnect = DbParameters.GetDbConfig();
            InitializeComponent();

            // listen for text change to set form change status
            ListenForValidating(this);

            btnApply.Enabled = false;
            SetInitialValues();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (isDataChanged && MessageBox.Show("Do you want to discard your changes?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            else
                Application.Exit();
        }

        private void BtnFile1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtDebugFolder.Text = folderBrowserDialog1.SelectedPath;
                DataHasChanged(sender, e);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (isDataChanged) if (isDataChanged && MessageBox.Show("Do you want to save your changes?", "Exit Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!SaveConfiguration())
                        return;
                }

            Application.Exit();
        }

        private void DataHasChanged(object sender, EventArgs e)
        {
            isDataChanged = true;
            btnApply.Enabled = true;
        }

        private void ListenForValidating(Control ctrlPArent)
        {
            // attach validating event to text boxes
            foreach (Control ctrlChild in ctrlPArent.Controls)
            {
                if (ctrlChild is TextBox)
                {
                    (ctrlChild as TextBox).Validating += DataHasChanged;
                    (ctrlChild as TextBox).KeyDown += DataHasChanged;
                }
                else if (ctrlChild is CheckBox)
                {
                    (ctrlChild as CheckBox).Click += DataHasChanged;
                }
                else if (ctrlChild is RadioButton)
                {
                    (ctrlChild as RadioButton).Click += DataHasChanged;
                }
                else if (ctrlChild is ComboBox)
                {
                    (ctrlChild as ComboBox).TextChanged += DataHasChanged;
                }
                if (ctrlChild.HasChildren)
                    ListenForValidating(ctrlChild);
            }
        }

        private bool SaveConfiguration()
        {
            int tt = 0;

            if (!ValidateConfiguration())
                return false;

            bool ret = true;

            // HL Service settings
            DbParameters.DebugFolder = txtDebugFolder.Text;
            DbParameters.HLIdentityConfig.CacheFolder = txtDebugFolder.Text;

            if (Int32.TryParse(txtHLServicePort.Text, out tt) && tt > 0)
            {
                DbParameters.HLIdentityConfig.HLServicePort = tt;
            }
            else
            {
                MessageBox.Show("HL Service port must be numeric.", "Numeric Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Remove ending '/' in the enrollment server URL
            if (!string.IsNullOrEmpty(txtHLIdentityServerURL.Text) && txtHLIdentityServerURL.Text.EndsWith('/'))
            {
                txtHLIdentityServerURL.Text = txtHLIdentityServerURL.Text.Substring(0, txtHLIdentityServerURL.Text.LastIndexOf('/'));
            }

            DbParameters.HLIdentityConfig.HLIdentityServerURL = txtHLIdentityServerURL.Text;
            DbParameters.HLIdentityConfig.HLIdentityClientUsername = txtHLIdentityClientUsername.Text;
            DbParameters.HLIdentityConfig.HLIdentityClientPassword = txtHLIdentityClientPassword.Text;
            DbParameters.HLIdentityConfig.UseSSL = chkUseSSL.Checked ? 1 : 0;

            if (Int32.TryParse(txtIdentitySearchInterval.Text, out int temp))
            {
                DbParameters.HLIdentityConfig.IdentitySearchInterval = temp;
            }
            else
            {
                MessageBox.Show("Identity search interval must be a positive numeric value (minutes).", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            DbParameters.HLIdentityConfig.IsDebug = chkHLServiceDebug.Checked ? 1 : 0;
            DbParameters.HLIdentityConfig.HLServiceInStandaloneMode = chkHLServiceInStandaloneMode.Checked ? 1 : 0;

            if (!String.IsNullOrEmpty(txtHLServiceToken.Text) && !String.IsNullOrEmpty(txtHLServiceSecret.Text))
            {
                DbParameters.HLIdentityConfig.HLServiceToken = txtHLServiceToken.Text;
                DbParameters.HLIdentityConfig.HLServiceSecret = txtHLServiceSecret.Text;
            }

            DbParameters.WriteDbConfig();
            isDataChanged = false;

            if (ret)
                btnApply.Enabled = false;

            lblStatus.Text = "";
            this.Cursor = Cursors.Default;
            this.Refresh();

            if (DialogResult.Yes == MessageBox.Show("Would you like to restart HL service now?", "Service Restart", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (ServiceManager.IsServiceInstalled(DbParameters.HLIdentityConfig.HLServiceName))
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        lblStatus.Text = "Restarting HL Service.....";
                        this.Refresh();
                        ServiceManager.RestartService(DbParameters.HLIdentityConfig.HLServiceName, 60000);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: '{ex.Message}'. Please temporary restart the '{DbParameters.HLIdentityConfig.HLServiceName}' manually!", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        lblStatus.Text = "";
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            return ret;
        }

        private void SetInitialValues()
        {
            // set initial form values from config file    
            txtDebugFolder.Text = DbParameters.DebugFolder;
            txtHLIdentityServerURL.Text = DbParameters.HLIdentityConfig.HLIdentityServerURL;
            txtHLIdentityClientUsername.Text = DbParameters.HLIdentityConfig.HLIdentityClientUsername;
            txtHLIdentityClientPassword.Text = DbParameters.HLIdentityConfig.HLIdentityClientPassword;
            txtIdentitySearchInterval.Text = DbParameters.HLIdentityConfig.IdentitySearchInterval.ToString();
            txtHLServicePort.Text = DbParameters.HLIdentityConfig.HLServicePort.ToString();
            chkHLServiceInStandaloneMode.Checked = (DbParameters.HLIdentityConfig.HLServiceInStandaloneMode == 1 ? true : false);
            chkUseSSL.Checked = (DbParameters.HLIdentityConfig.UseSSL == 1 ? true : false);

            if (ServiceManager.IsServiceInstalled(DbParameters.HLIdentityConfig.HLServiceName))
            {
                if (DbParameters.HLIdentityConfig.IsDebug == 1)
                    chkHLServiceDebug.Checked = true;

                if (ServiceManager.ServiceIsRunning(DbParameters.HLIdentityConfig.HLServiceName))
                {
                    lblHLStatus.Text = "HL Service is running...";
                }
                else
                {
                    lblHLStatus.Text = " Unknown Status, try running with administrator privileges";
                }
            }
            else
            {
                lblHLStatus.Text = "HL Service is not installed";
            }

            isDataChanged = false;
            btnApply.Enabled = false;
        }

        private bool ValidateConfiguration()
        {
            bool ret = true;

            if (!Directory.Exists(txtDebugFolder.Text))
            {
                MessageBox.Show("HL Identity Database/Debug folder must exist.", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return ret;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestartHLService_Click(object sender, EventArgs e)
        {
            if (isDataChanged) if (isDataChanged && MessageBox.Show("Do you want to save your changes before restarting service?", "Save Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!SaveConfiguration())
                        return;
                }

            this.UseWaitCursor = true;
            lblStatus.Text = "Restarting HL Service...";
            this.Refresh();

            try
            {
                if (ServiceManager.IsServiceInstalled(DbParameters.HLIdentityConfig.HLServiceName))
                {
                    ServiceManager.RestartService(DbParameters.HLIdentityConfig.HLServiceName, 20000);
                    MessageBox.Show("Service has been restarted", "Restart Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Service " + DbParameters.HLIdentityConfig.HLServiceName + " is not avialable on this computer", "Unknown Service", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: '{ex.Message}'. Please temporary restart the '{DbParameters.HLIdentityConfig.HLServiceName}' manually!", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.UseWaitCursor = false;
                lblStatus.Text = "";
            }
        }

        private void btnGenerateCredential_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("This will set new credentials for the HL service. Please update any remote connections using the old credentials, if any." + Environment.NewLine + "Please note these will only be shown this one time."
                + Environment.NewLine + "Are you sure?", "Generate Credentials", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                txtHLServiceToken.Text = DbParameters.CreateSecureRandomString();
                txtHLServiceSecret.Text = DbParameters.CreateSecureRandomString();

                DataHasChanged(sender, e);
            }
        }

        /// <summary>
        /// TODO: Send new HL to HL Identity Service to create a new HL in hl-identity database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            // TODO: Setup httpClient
            // TODO: Read HL Identity server URL, credential
            // TODO: Read HL fields and create XML
            // TODO: send POST an XML request to HL Identity server
            // TODO: Display status on the common status control.
            lblStatus.Text = $"Sample created HL return: '{HttpStatusCode.OK.ToString()}'";
        }

        private void clientListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // CRUD HL client list
                // TODO: Show HL clients list
                tabHLClientList.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to show clients: " + ex.Message, "Client list error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ;
            }
        }
    }
}
