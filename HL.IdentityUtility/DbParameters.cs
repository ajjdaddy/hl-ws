using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace HL.IdentityUtility
{
    public enum ServerSystemType
    {
        None = -1,
        HLClient = 1,
        XML = 2
    };

    public class DBConfiguration
    {
        public DBConfiguration() { }
        public string ConnectionString64 { get; set; }
        public string EncryptedPassword64 { get; set; }
        public int ConnectionRetries { get; set; }

        [XmlIgnore]
        public string ConnectionString
        {
            get
            {
                if (ConnectionString64 != null)
                    return DbParameters.Unprotect(ConnectionString64);
                else
                    return null;
            }
            set
            {
                if (value != null)
                    ConnectionString64 = DbParameters.Protect(value);
            }
        }
    }

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute("DbParameters", Namespace = "", IsNullable = false)]
    public class DbParameters
    {
        public static string AppDataFolder = @"HLIdentity";
        public static string AppConfigFile = @"HLService.config";

        public DbParameters()
        {
            DBDatabaseConfig = DatabaseConfig;
            DBHLIdentityConfig = HLIdentityConfig;
            DBSystemType = (int)(SystemType == 0 ? ServerSystemType.None : ServerSystemType.HLClient);
        }

        public DbParameters(string wstate, string wsize)
        {
            ;
        }

        public static DBConfiguration DatabaseConfig { get; set; }
        public static HLIdentityConfiguration HLIdentityConfig { get; set; }
        public static string DebugFolder { get; set; }
        public static int SystemType { get; set; }
        public DBConfiguration DBDatabaseConfig { get; set; }
        public HLIdentityConfiguration DBHLIdentityConfig { get; set; }
        public int DBSystemType { get; set; }
        public string DBDebugFolder { get; set; }

        public static string ConnectionString
        {
            get
            {
                return DatabaseConfig.ConnectionString;
            }
        }

        public static string AppFolder
        {
            get
            {
                // set default folder to application data folder
                string fileDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                                AppDataFolder);

                return fileDir;
            }
        }

        public static DbParameters GetDbConfig()
        {
            string filename = Path.Combine(AppFolder, AppConfigFile);
            DbParameters dbConnect = null;
            FileStream fs = null;

            if (File.Exists(filename))
            {
                try
                {
                    XmlSerializer serializer = new
                    XmlSerializer(typeof(DbParameters));

                    // A FileStream is needed to read the XML document.
                    FileInfo fi = new FileInfo(filename);
                    fs = fi.Open(FileMode.Open, FileAccess.Read);
                    XmlReader reader = new XmlTextReader(fs);

                    // Use the Deserialize method to restore the object's state.
                    dbConnect = (DbParameters)serializer.Deserialize(reader);
                    DatabaseConfig = dbConnect.DBDatabaseConfig;
                    HLIdentityConfig = dbConnect.DBHLIdentityConfig;

                    LoadDefaultSettings(dbConnect);
                    fs.Close();
                    return dbConnect;
                }
                catch
                {
                    LoadDefaultSettings(dbConnect);
                    return new DbParameters();
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
            }
            else
            {
                // need to create app folder if does not exist in case of standalone id service
                if (!Directory.Exists(AppFolder))
                {
                    Directory.CreateDirectory(AppFolder);
                }
                LoadDefaultSettings(dbConnect);
                return new DbParameters();
            }
        }

        public static void LoadDefaultSettings(DbParameters dbConnect)
        {
            if (dbConnect == null)
                dbConnect = new DbParameters();

            if (DatabaseConfig == null)
                DatabaseConfig = new DBConfiguration();

            if (HLIdentityConfig == null)
                HLIdentityConfig = new HLIdentityConfiguration();

            if (String.IsNullOrEmpty(dbConnect.DBDebugFolder))
                DebugFolder = AppFolder;
            else
                DebugFolder = dbConnect.DBDebugFolder;

            SystemType = (int)ServerSystemType.HLClient;

            if (HLIdentityConfig.IdentitySearchInterval == 0)
            {
                HLIdentityConfig.IdentitySearchInterval = 120;
            }

            if (HLIdentityConfig.HLServicePort == 0)
            {
                HLIdentityConfig.HLServicePort = 8002;
            }

            if (String.IsNullOrEmpty(HLIdentityConfig.IDServiceListenAddress))
            {
                HLIdentityConfig.IDServiceListenAddress = "localhost";
            }

            if (String.IsNullOrEmpty(HLIdentityConfig.HLServiceName))
            {
                HLIdentityConfig.HLServiceName = "HL.IdentityServer";
            }

            if (String.IsNullOrEmpty(HLIdentityConfig.HLServiceToken))
            {
                HLIdentityConfig.HLServiceToken = CreateSecureRandomString();
                HLIdentityConfig.HLServiceTokenExpiryDate = GenerateTokenExpiryDate();
            }

            if (String.IsNullOrEmpty(HLIdentityConfig.HLServiceTokenExpiryDate) ||
                DateTime.Parse(HLIdentityConfig.HLServiceTokenExpiryDate) < DateTime.Now)
            {
                HLIdentityConfig.HLServiceTokenExpiryDate = GenerateTokenExpiryDate();
            }

            if (String.IsNullOrEmpty(HLIdentityConfig.HLServiceSecret))
            {
                HLIdentityConfig.HLServiceSecret = CreateSecureRandomString();
            }

            // always the same as debug folder for now
            HLIdentityConfig.CacheFolder = DebugFolder;
        }

        /// <summary>
        /// Creates a random key string.
        /// </summary>
        /// <param name="length">The number of bytes of random values to create the string from</param>
        /// <returns>A random string</returns>
        public static string CreateSecureRandomString(int length = 64)
        {
            byte[] rgb = new byte[length];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(rgb);
            return Convert.ToBase64String(rgb);
        }

        /// <summary>
        /// Generate token expiry date.
        /// </summary>
        /// <returns>A generated token expiry date</returns>
        public static string GenerateTokenExpiryDate()
        {
            return DateTime.Now.AddYears(100).ToString();
        }

        public static void WriteDbConfig()
        {
            DbParameters dbNew = new DbParameters
            {
                // set values
                DBDebugFolder = DebugFolder
            };

            WriteDbConfig(dbNew);
        }

        public static void WriteDbConfig(DbParameters dbNew)
        {
            StreamWriter stWriter = null;
            XmlSerializer xmlSerializer;
            XmlDocument doc = new XmlDocument();
            MemoryStream memStream = null;

            try
            {
                string filename = Path.Combine(AppFolder, AppConfigFile);
                xmlSerializer = new XmlSerializer(dbNew.GetType());
                memStream = new MemoryStream();
                stWriter = new StreamWriter(memStream);
                xmlSerializer.Serialize(stWriter, dbNew);
                doc.PreserveWhitespace = true;
                doc.LoadXml(Encoding.ASCII.GetString(memStream.GetBuffer()));
                doc.Save(filename);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (stWriter != null)
                    stWriter.Close();
            }
        }

        static byte[] hamburger = { 6, 3, 2, 8 };

        public static string Protect(string toEncrypt)
        {
            try
            {
                if (String.IsNullOrEmpty(toEncrypt))
                    return null;

                byte[] data = UnicodeEncoding.ASCII.GetBytes(toEncrypt);

                // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted
                //  only by the same current user.
                byte[] t = ProtectedData.Protect(data, hamburger, DataProtectionScope.LocalMachine);
                return Base64Encode(t);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Data was not encrypted. An error occurred.");
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static string Unprotect(string encrypted)
        {
            try
            {
                //Decrypt the data using DataProtectionScope.CurrentUser.
                byte[] data = Base64Decode(encrypted);
                byte[] t = ProtectedData.Unprotect(data, hamburger, DataProtectionScope.LocalMachine);
                return UnicodeEncoding.ASCII.GetString(t);
            }
            catch (Exception e)
            {
                throw new Exception("Error getting db connection string:" + e.Message);
            }
        }

        public static string Base64Encode(byte[] data)
        {
            return System.Convert.ToBase64String(data);
        }

        public static byte[] Base64Decode(string base64EncodedData)
        {
            return System.Convert.FromBase64String(base64EncodedData);
        }
    }

    public class HLIdentityConfiguration
    {
        public const string CacheDBFileName = "hl-identity.db";
        public HLIdentityConfiguration()
        {
            CacheFolder = @"C:\ProgramData\HLIdentity";
            ReceiveTimeoutSeconds = 3;
            SendTimeoutSeconds = 3;
            ConnectionPool = 50;
            HLServiceName = "HL.IdentityServer";
        }

        public int HLServicePort { get; set; }
        public string IDServiceListenAddress { get; set; }
        public int UseSSL { get; set; }

        // Default/Configured username/secret for the ID Service in the ID Service tab of the HL Configuration Utility
        public string HLServiceToken { get; set; }
        public string HLServiceTokenExpiryDate { get; set; }
        public string HLServiceSecret64 { get; set; }

        [XmlIgnore]
        public string HLServiceSecret
        {
            get
            {
                if (HLServiceSecret64 != null)
                    return DbParameters.Unprotect(HLServiceSecret64);
                else
                    return null;
            }
            set
            {
                if (value != null)
                    HLServiceSecret64 = DbParameters.Protect(value);
            }
        }

        public int ReceiveTimeoutSeconds { get; set; }
        public int SendTimeoutSeconds { get; set; }
        public string CacheFolder { get; set; }
        public int ConnectionPool { get; set; }
        public int IsDebug { get; set; }
        public string HLServiceName { get; set; }
        public int IdentitySearchInterval { get; set; }
        public string HLIdentityServerURL { get; set; }

        // Custom configured username/password for HL Identity Client server in HL Service tab of the HL Configuration Utility
        public string HLIdentityClientUsername { get; set; }
        public string HLIdentityClientPassword64 { get; set; }

        [XmlIgnore]
        public string HLIdentityClientPassword
        {
            get
            {
                if (HLIdentityClientPassword64 != null)
                    return DbParameters.Unprotect(HLIdentityClientPassword64);
                else
                    return null;
            }
            set
            {
                if (value != null)
                    HLIdentityClientPassword64 = DbParameters.Protect(value);
            }
        }

        public int HLServiceInStandaloneMode { get; set; }
    }
}
