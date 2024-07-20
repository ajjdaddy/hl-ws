using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace HL.IdentityUtility
{
    public class HttpHelper
    {
        public static readonly string XMLHeader = @"<?xml version=""1.0"" encoding=""utf-8""?>" + Environment.NewLine;
        public static HttpClient httpClient = null;

        public static void InitHttpClient(string url)
        {
            try
            {
                if (httpClient == null)
                {
                    var handler = new HttpClientHandler();
                    if (handler.SupportsAutomaticDecompression)
                    {
                        handler.AutomaticDecompression = DecompressionMethods.GZip |
                                                         DecompressionMethods.Deflate;
                    }

                    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                    handler.ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) =>
                        {
                            Debug.WriteLine("Return true from certificate handler");
                            return true;
                        };

                    httpClient = new HttpClient(handler);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing http client:" + ex.Message);
            }
        }

        /// <summary>
        /// TODO: Send/Push response or HL records to HL Clients
        /// </summary>
        /// <param name="method"></param>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        public static async Task<HTTPResponse> SendResponseToHLClients(string method, string xmlContent)
        {
            return new HTTPResponse(-1, "Has not implement response");
        }

        public static string GetCredentials()
        {
            string credentials = "<credentials>";
            if (!String.IsNullOrEmpty(DbParameters.HLIdentityConfig.HLIdentityServerURL))
            {
                credentials += "<username>" + DbParameters.HLIdentityConfig.HLIdentityClientUsername + "</username>" + Environment.NewLine;
                credentials += "<password>" + DbParameters.HLIdentityConfig.HLIdentityClientPassword + "</password>" + Environment.NewLine;
                credentials += "<deviceName>" + DbParameters.HLIdentityConfig.HLIdentityServerURL + "</deviceName>" + Environment.NewLine;
            }
            else
            {
                credentials += "<username>" + DbParameters.HLIdentityConfig.HLServiceToken + "</username>" + Environment.NewLine;
                credentials += "<password>" + DbParameters.HLIdentityConfig.HLServiceSecret + "</password>" + Environment.NewLine;
                credentials += "<deviceName>" + (DbParameters.HLIdentityConfig.UseSSL == 1 ? "https" : "http") + "://localhost:8001" + "</deviceName>" + Environment.NewLine;
            }
            credentials += "</credentials>" + Environment.NewLine;

            return credentials;
        }

        public static async Task SaveUrlContentToFile(string url, string filename)
        {
            InitHttpClient(url);

            try
            {
                if (File.Exists(filename))
                {
                    try
                    {
                        // try and delete it if not get out of here
                        File.Delete(filename);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Unable to delete existing file.");
                        return;
                    }
                }

                using (HttpResponseMessage response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    string fileToWriteTo = filename;
                    using (Stream streamToWriteTo = File.Open(fileToWriteTo, FileMode.Create))
                    {
                        await streamToReadFrom.CopyToAsync(streamToWriteTo);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Download Content failed:" + ex.Message);
                throw new Exception("Unable to download from " + url + " to " + filename + ":" + ex.Message);
            }
            finally
            {
                //client.Dispose();
            }
        }

        public static string appendResults(bool valid, bool doPipe)
        {
            return (valid == true ? "1" : "0") + (doPipe == true ? "|" : "");
        }

        public static bool IsNotNull([NotNullWhen(true)] object obj) => obj != null;
    }
}
