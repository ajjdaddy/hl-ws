namespace HL.IdentityConfigApp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            btnOK = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            btnApply = new System.Windows.Forms.Button();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            lblStatus = new System.Windows.Forms.TextBox();
            tabDebug = new System.Windows.Forms.TabPage();
            label32 = new System.Windows.Forms.Label();
            lblHLStatus = new System.Windows.Forms.Label();
            btnRestartHLService = new System.Windows.Forms.Button();
            chkHLServiceDebug = new System.Windows.Forms.CheckBox();
            btnFile1 = new System.Windows.Forms.Button();
            txtDebugFolder = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            tabHLService = new System.Windows.Forms.TabPage();
            chkUseSSL = new System.Windows.Forms.CheckBox();
            chkHLServiceInStandaloneMode = new System.Windows.Forms.CheckBox();
            btnGenerateCredential = new System.Windows.Forms.Button();
            txtHLServiceSecret = new System.Windows.Forms.TextBox();
            txtHLServiceToken = new System.Windows.Forms.TextBox();
            txtHLServicePort = new System.Windows.Forms.TextBox();
            txtIdentitySearchInterval = new System.Windows.Forms.TextBox();
            txtHLIdentityClientPassword = new System.Windows.Forms.TextBox();
            txtHLIdentityClientUsername = new System.Windows.Forms.TextBox();
            txtHLIdentityServerURL = new System.Windows.Forms.TextBox();
            label36 = new System.Windows.Forms.Label();
            label35 = new System.Windows.Forms.Label();
            label34 = new System.Windows.Forms.Label();
            label31 = new System.Windows.Forms.Label();
            label29 = new System.Windows.Forms.Label();
            label28 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            tabControl1 = new System.Windows.Forms.TabControl();
            menuStrip1.SuspendLayout();
            tabDebug.SuspendLayout();
            tabHLService.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            menuStrip1.Size = new System.Drawing.Size(734, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // btnOK
            // 
            btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnOK.Location = new System.Drawing.Point(499, 500);
            btnOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new System.Drawing.Size(67, 26);
            btnOK.TabIndex = 2;
            btnOK.Text = "Close";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += BtnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Location = new System.Drawing.Point(574, 500);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(67, 26);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += BtnCancel_Click;
            // 
            // btnApply
            // 
            btnApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnApply.Location = new System.Drawing.Point(649, 500);
            btnApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnApply.Name = "btnApply";
            btnApply.Size = new System.Drawing.Size(67, 26);
            btnApply.TabIndex = 4;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += BtnApply_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblStatus.BackColor = System.Drawing.SystemColors.Control;
            lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lblStatus.Enabled = false;
            lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblStatus.Location = new System.Drawing.Point(12, 607);
            lblStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(712, 13);
            lblStatus.TabIndex = 5;
            // 
            // tabDebug
            // 
            tabDebug.AutoScroll = true;
            tabDebug.BackColor = System.Drawing.SystemColors.Control;
            tabDebug.Controls.Add(label32);
            tabDebug.Controls.Add(lblHLStatus);
            tabDebug.Controls.Add(btnRestartHLService);
            tabDebug.Controls.Add(chkHLServiceDebug);
            tabDebug.Controls.Add(btnFile1);
            tabDebug.Controls.Add(txtDebugFolder);
            tabDebug.Controls.Add(label1);
            tabDebug.Location = new System.Drawing.Point(4, 24);
            tabDebug.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabDebug.Name = "tabDebug";
            tabDebug.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabDebug.Size = new System.Drawing.Size(711, 427);
            tabDebug.TabIndex = 1;
            tabDebug.Text = "Debug";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new System.Drawing.Point(25, 72);
            label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new System.Drawing.Size(396, 15);
            label32.TabIndex = 6;
            label32.Text = "** You must be running with administrator privileges to restart HL services";
            // 
            // lblHLStatus
            // 
            lblHLStatus.AutoSize = true;
            lblHLStatus.Location = new System.Drawing.Point(494, 109);
            lblHLStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHLStatus.Name = "lblHLStatus";
            lblHLStatus.Size = new System.Drawing.Size(160, 15);
            lblHLStatus.TabIndex = 5;
            lblHLStatus.Text = "HL Service status is unknown";
            // 
            // btnRestartHLService
            // 
            btnRestartHLService.Location = new System.Drawing.Point(302, 104);
            btnRestartHLService.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRestartHLService.Name = "btnRestartHLService";
            btnRestartHLService.Size = new System.Drawing.Size(144, 27);
            btnRestartHLService.TabIndex = 4;
            btnRestartHLService.Text = "Restart HL Service";
            btnRestartHLService.UseVisualStyleBackColor = true;
            btnRestartHLService.Click += btnRestartHLService_Click;
            // 
            // chkHLServiceDebug
            // 
            chkHLServiceDebug.AutoSize = true;
            chkHLServiceDebug.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkHLServiceDebug.Location = new System.Drawing.Point(25, 109);
            chkHLServiceDebug.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkHLServiceDebug.Name = "chkHLServiceDebug";
            chkHLServiceDebug.Size = new System.Drawing.Size(234, 19);
            chkHLServiceDebug.TabIndex = 3;
            chkHLServiceDebug.Text = "Run HL service in debug/logging mode";
            chkHLServiceDebug.UseVisualStyleBackColor = true;
            // 
            // btnFile1
            // 
            btnFile1.Location = new System.Drawing.Point(556, 27);
            btnFile1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnFile1.Name = "btnFile1";
            btnFile1.Size = new System.Drawing.Size(88, 27);
            btnFile1.TabIndex = 2;
            btnFile1.Text = "Browse";
            btnFile1.UseVisualStyleBackColor = true;
            btnFile1.Click += BtnFile1_Click;
            // 
            // txtDebugFolder
            // 
            txtDebugFolder.Location = new System.Drawing.Point(191, 27);
            txtDebugFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtDebugFolder.Name = "txtDebugFolder";
            txtDebugFolder.Size = new System.Drawing.Size(357, 23);
            txtDebugFolder.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(25, 30);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(162, 15);
            label1.TabIndex = 0;
            label1.Text = "HL Identity Cache/Log Folder";
            // 
            // tabHLService
            // 
            tabHLService.AutoScroll = true;
            tabHLService.BackColor = System.Drawing.SystemColors.Control;
            tabHLService.Controls.Add(chkUseSSL);
            tabHLService.Controls.Add(chkHLServiceInStandaloneMode);
            tabHLService.Controls.Add(btnGenerateCredential);
            tabHLService.Controls.Add(txtHLServiceSecret);
            tabHLService.Controls.Add(txtHLServiceToken);
            tabHLService.Controls.Add(txtHLServicePort);
            tabHLService.Controls.Add(txtIdentitySearchInterval);
            tabHLService.Controls.Add(txtHLIdentityClientPassword);
            tabHLService.Controls.Add(txtHLIdentityClientUsername);
            tabHLService.Controls.Add(txtHLIdentityServerURL);
            tabHLService.Controls.Add(label36);
            tabHLService.Controls.Add(label35);
            tabHLService.Controls.Add(label34);
            tabHLService.Controls.Add(label31);
            tabHLService.Controls.Add(label29);
            tabHLService.Controls.Add(label28);
            tabHLService.Controls.Add(label26);
            tabHLService.Controls.Add(label27);
            tabHLService.Controls.Add(label25);
            tabHLService.Controls.Add(label23);
            tabHLService.Controls.Add(label11);
            tabHLService.Controls.Add(label15);
            tabHLService.Controls.Add(label12);
            tabHLService.Location = new System.Drawing.Point(4, 24);
            tabHLService.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabHLService.Name = "tabHLService";
            tabHLService.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            tabHLService.Size = new System.Drawing.Size(711, 427);
            tabHLService.TabIndex = 4;
            tabHLService.Text = "HL Service";
            // 
            // chkUseSSL
            // 
            chkUseSSL.AutoSize = true;
            chkUseSSL.Checked = true;
            chkUseSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            chkUseSSL.Location = new System.Drawing.Point(42, 297);
            chkUseSSL.Name = "chkUseSSL";
            chkUseSSL.Size = new System.Drawing.Size(66, 19);
            chkUseSSL.TabIndex = 56;
            chkUseSSL.Text = "Use SSL";
            chkUseSSL.UseVisualStyleBackColor = true;
            // 
            // chkHLServiceInStandaloneMode
            // 
            chkHLServiceInStandaloneMode.AutoSize = true;
            chkHLServiceInStandaloneMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            chkHLServiceInStandaloneMode.Checked = true;
            chkHLServiceInStandaloneMode.CheckState = System.Windows.Forms.CheckState.Checked;
            chkHLServiceInStandaloneMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            chkHLServiceInStandaloneMode.Location = new System.Drawing.Point(38, 62);
            chkHLServiceInStandaloneMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkHLServiceInStandaloneMode.Name = "chkHLServiceInStandaloneMode";
            chkHLServiceInStandaloneMode.Size = new System.Drawing.Size(195, 20);
            chkHLServiceInStandaloneMode.TabIndex = 55;
            chkHLServiceInStandaloneMode.Text = "Run in Standalone mode";
            chkHLServiceInStandaloneMode.UseVisualStyleBackColor = true;
            // 
            // btnGenerateCredential
            // 
            btnGenerateCredential.Location = new System.Drawing.Point(191, 88);
            btnGenerateCredential.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnGenerateCredential.Name = "btnGenerateCredential";
            btnGenerateCredential.Size = new System.Drawing.Size(209, 27);
            btnGenerateCredential.TabIndex = 2;
            btnGenerateCredential.Text = "Generate New Credentials";
            btnGenerateCredential.UseVisualStyleBackColor = true;
            btnGenerateCredential.Click += btnGenerateCredential_Click;
            // 
            // txtHLServiceSecret
            // 
            txtHLServiceSecret.Location = new System.Drawing.Point(90, 155);
            txtHLServiceSecret.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtHLServiceSecret.Name = "txtHLServiceSecret";
            txtHLServiceSecret.ReadOnly = true;
            txtHLServiceSecret.Size = new System.Drawing.Size(483, 23);
            txtHLServiceSecret.TabIndex = 4;
            // 
            // txtHLServiceToken
            // 
            txtHLServiceToken.Location = new System.Drawing.Point(90, 123);
            txtHLServiceToken.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtHLServiceToken.Name = "txtHLServiceToken";
            txtHLServiceToken.ReadOnly = true;
            txtHLServiceToken.Size = new System.Drawing.Size(483, 23);
            txtHLServiceToken.TabIndex = 3;
            // 
            // txtHLServicePort
            // 
            txtHLServicePort.Location = new System.Drawing.Point(90, 91);
            txtHLServicePort.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            txtHLServicePort.Name = "txtHLServicePort";
            txtHLServicePort.Size = new System.Drawing.Size(56, 23);
            txtHLServicePort.TabIndex = 1;
            // 
            // txtIdentitySearchInterval
            // 
            txtIdentitySearchInterval.Enabled = false;
            txtIdentitySearchInterval.Location = new System.Drawing.Point(227, 386);
            txtIdentitySearchInterval.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtIdentitySearchInterval.Name = "txtIdentitySearchInterval";
            txtIdentitySearchInterval.Size = new System.Drawing.Size(116, 23);
            txtIdentitySearchInterval.TabIndex = 9;
            // 
            // txtHLIdentityClientPassword
            // 
            txtHLIdentityClientPassword.Location = new System.Drawing.Point(373, 323);
            txtHLIdentityClientPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtHLIdentityClientPassword.Name = "txtHLIdentityClientPassword";
            txtHLIdentityClientPassword.PasswordChar = '*';
            txtHLIdentityClientPassword.Size = new System.Drawing.Size(230, 23);
            txtHLIdentityClientPassword.TabIndex = 7;
            // 
            // txtHLIdentityClientUsername
            // 
            txtHLIdentityClientUsername.Location = new System.Drawing.Point(108, 323);
            txtHLIdentityClientUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtHLIdentityClientUsername.Name = "txtHLIdentityClientUsername";
            txtHLIdentityClientUsername.Size = new System.Drawing.Size(186, 23);
            txtHLIdentityClientUsername.TabIndex = 6;
            // 
            // txtHLIdentityServerURL
            // 
            txtHLIdentityServerURL.Location = new System.Drawing.Point(173, 243);
            txtHLIdentityServerURL.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            txtHLIdentityServerURL.Name = "txtHLIdentityServerURL";
            txtHLIdentityServerURL.Size = new System.Drawing.Size(294, 23);
            txtHLIdentityServerURL.TabIndex = 5;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new System.Drawing.Point(38, 159);
            label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label36.Name = "label36";
            label36.Size = new System.Drawing.Size(39, 15);
            label36.TabIndex = 54;
            label36.Text = "Secret";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new System.Drawing.Point(38, 127);
            label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new System.Drawing.Size(38, 15);
            label35.TabIndex = 53;
            label35.Text = "Token";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label34.Location = new System.Drawing.Point(38, 221);
            label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new System.Drawing.Size(441, 13);
            label34.TabIndex = 52;
            label34.Text = "Leave blank to use default configuration for the Identity Client on this server";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new System.Drawing.Point(169, 274);
            label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new System.Drawing.Size(393, 15);
            label31.TabIndex = 51;
            label31.Text = "(Be sure to include port number if neccessary (ie :8001) and no ending '/')";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label29.Location = new System.Drawing.Point(26, 13);
            label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new System.Drawing.Size(143, 16);
            label29.TabIndex = 48;
            label29.Text = "HL Service Settings";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label28.Location = new System.Drawing.Point(38, 190);
            label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(160, 16);
            label28.TabIndex = 47;
            label28.Text = "Identity Client Settings";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(29, 38);
            label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(375, 15);
            label26.TabIndex = 46;
            label26.Text = "NOTE: The HL service must be restarted for any changes to take effect.";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(38, 94);
            label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(29, 15);
            label27.TabIndex = 43;
            label27.Text = "Port";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Enabled = false;
            label25.Location = new System.Drawing.Point(38, 389);
            label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(181, 15);
            label25.TabIndex = 40;
            label25.Text = "Identity Search Interval (minutes)";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Enabled = false;
            label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            label23.Location = new System.Drawing.Point(38, 362);
            label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(498, 16);
            label23.TabIndex = 38;
            label23.Text = "Identity Searcher (IS) Settings (Future pulling/searching Identity feature)";
            // 
            // label11
            // 
            label11.Location = new System.Drawing.Point(295, 323);
            label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(70, 23);
            label11.TabIndex = 11;
            label11.Text = "Password";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            label15.Location = new System.Drawing.Point(38, 323);
            label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(62, 23);
            label15.TabIndex = 10;
            label15.Text = "Username";
            label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(38, 248);
            label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(105, 15);
            label12.TabIndex = 0;
            label12.Text = "Identity Client URL";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl1.Controls.Add(tabHLService);
            tabControl1.Controls.Add(tabDebug);
            tabControl1.Location = new System.Drawing.Point(7, 28);
            tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(719, 455);
            tabControl1.TabIndex = 1;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(734, 540);
            Controls.Add(lblStatus);
            Controls.Add(btnApply);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(718, 500);
            Name = "frmMain";
            Text = "HL Identity Configuration";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabDebug.ResumeLayout(false);
            tabDebug.PerformLayout();
            tabHLService.ResumeLayout(false);
            tabHLService.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox lblStatus;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblHLStatus;
        private System.Windows.Forms.Button btnRestartHLService;
        private System.Windows.Forms.CheckBox chkHLServiceDebug;
        private System.Windows.Forms.Button btnFile1;
        private System.Windows.Forms.TextBox txtDebugFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabHLService;
        private System.Windows.Forms.CheckBox chkHLServiceInStandaloneMode;
        private System.Windows.Forms.Button btnGenerateCredential;
        private System.Windows.Forms.TextBox txtHLServiceSecret;
        private System.Windows.Forms.TextBox txtHLServiceToken;
        private System.Windows.Forms.TextBox txtHLServicePort;
        private System.Windows.Forms.TextBox txtIdentitySearchInterval;
        private System.Windows.Forms.TextBox txtHLIdentityClientPassword;
        private System.Windows.Forms.TextBox txtHLIdentityClientUsername;
        private System.Windows.Forms.TextBox txtHLIdentityServerURL;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox chkUseSSL;
    }
}

