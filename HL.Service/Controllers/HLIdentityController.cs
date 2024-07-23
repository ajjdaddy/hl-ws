using HL.Identity;
using HL.IdentityCache;
using HL.IdentityUtility;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using HL.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HL.Service.Controllers
{
    [Route("[controller]")]
    public class HLIdentityController : ControllerBase
    {
        private readonly IHLLogger hlLogger;
        private readonly IServer server;
        private readonly ICacheManager cache;

        public HLIdentityController(IHLLogger pHLLogger, IServer pServer, ICacheManager cacheManager)
        {
            hlLogger = pHLLogger;
            server = pServer;
            cache = cacheManager;

            var addresses = server.Features.Get<IServerAddressesFeature>().Addresses;
            Console.WriteLine($"Addresses from HomeController.Index: {string.Join(", ", addresses)}");
            hlLogger.WriteLogInformation("", "Controller", string.Format($"Addresses from HLIdentityController.Index: {string.Join(", ", addresses)}"));
        }

        // POST api/<HLIdentityController> - Entry point to post HuongLinh profile/identity
        [HttpPost]
        public async Task<string> Post()
        {
            try
            {
                if (HttpHelper.IsNotNull(Request.HttpContext.Connection) && HttpHelper.IsNotNull(Request.HttpContext.Connection.RemoteIpAddress))
                    hlLogger.WriteLogInformation("", "Post", "HL Identity received from: " + Request.HttpContext.Connection.RemoteIpAddress.ToString().Replace("::ffff:", ""));

                string DbFile = Path.Combine(DbParameters.HLIdentityConfig.CacheFolder, "hl-identity.db");
                if (!System.IO.File.Exists(DbFile))
                {
                    string errorString = "Unable to find HuongLinh database file!";
                    hlLogger.WriteLogError(HttpStatusCode.Unauthorized.ToString(), "Post", errorString);
                    return GetErrorString(HttpStatusCode.InternalServerError, errorString);
                }

                // get the raw body which is the xml template to process
                var rawRequestBody = await new StreamReader(Request.Body).ReadToEndAsync();

                // this is a hack so postman will work
                string decodedData = Regex.Replace(rawRequestBody, "^=", "");

                Debug.WriteLine("Request.ContentType is " + Request.ContentType);

                // decode if decoded data
                if ((decodedData.ToUpper().StartsWith("=%3C") || decodedData.ToUpper().StartsWith("%3C")) && Request.ContentType == "application/x-www-form-urlencoded")
                    decodedData = HttpUtility.UrlDecode(decodedData);

                HLIdentityData hlIdentityData = new HLIdentityData();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(decodedData);
                XmlSerializer ser = new XmlSerializer(typeof(HLIdentityData));
                using (StringReader reader = new StringReader(doc.InnerXml))
                {
                    hlIdentityData = (HLIdentityData)ser.Deserialize(reader);
                }

                // check credentials
                if (hlIdentityData?.Username != DbParameters.HLIdentityConfig.HLServiceToken || hlIdentityData.Password != DbParameters.HLIdentityConfig.HLServiceSecret)
                {
                    string errorString = "Invalid credentials - Username: " + hlIdentityData?.Username.Replace(Environment.NewLine, "");
                    hlLogger.WriteLogError(HttpStatusCode.Unauthorized.ToString(), "Post", errorString);
                    return GetErrorString(HttpStatusCode.Unauthorized, errorString);
                }

                // TODO (): Use CacheManager.Instance if needed
                bool ok = await cache.AddHuongLinh(hlIdentityData.Name, new HuongLinh() { ID = hlIdentityData.Id, Name = hlIdentityData.Name, LastModifiedDateTime = hlIdentityData.LastModifyDateTime });
                if (!ok)
                {
                    string errorString = "Fail to add Huong Linh!";
                    hlLogger.WriteLogError(HttpStatusCode.BadRequest.ToString(), "Post", errorString);
                    return GetErrorString(HttpStatusCode.BadRequest, errorString);
                }

                return GetReturnString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                string errorString = "Invalid content: " + (HttpHelper.IsNotNull(ex.StackTrace) ? ex.StackTrace : ex.Message);
                hlLogger.WriteLogError(HttpStatusCode.BadRequest.ToString(), "Post", errorString);

                // badly formatted xml or some other internal error; return generic error
                return GetErrorString(HttpStatusCode.BadRequest, errorString);
            }
            finally
            {
                //mgr.CloseCacheManager();
            }
        }

        public IActionResult DefaultUnsupportedOperation(string content)
        {
            hlLogger.WriteLogError("EC-101", "Post", "Invalid content: " + content?.Replace(Environment.NewLine, ""));
            return StatusCode((int)HttpStatusCode.InternalServerError, "Invalid request has been made.");
        }

        /// <summary>
        /// Format returned response
        /// </summary>
        /// <returns></returns>
        private string GetReturnString()
        {
            string response = HttpHelper.XMLHeader;
            response += "<HTTPResponse>";
            response += "<ResultCode>" + HttpStatusCode.OK.ToString() + "</ResultCode>";
            response += "<Error>" + "None" + "</Error>";
            response += "</HTTPResponse>";
            return response;
        }

        /// <summary>
        /// Format error response
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        private string GetErrorString(HttpStatusCode errorCode, string error = "")
        {
            string response = HttpHelper.XMLHeader;
            response += "<HTTPResponse>";
            response += "<ResultCode>" + errorCode.ToString() + "</ResultCode>";
            response += "<Error>" + error + "</Error>";
            response += "</HTTPResponse>";
            return response;
        }
    }
}
