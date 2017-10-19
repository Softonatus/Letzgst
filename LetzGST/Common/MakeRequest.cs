using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Web;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Text.RegularExpressions;
using pdfcrowd;
using LetzGST.letzGST_Service;

namespace LetzGST.Common
{
    public class MakeRequest
    {
        
        public static object getServiceObject(string requestUrl, object JSONRequest, string JSONReqName, string JSONmethod,Type JSONResponseType)
        {

            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                //WebRequest WR = WebRequest.Create(requestUrl);   
                string sb = JsonConvert.SerializeObject(JSONRequest);
                sb = "{\""+ JSONReqName + "\":" + sb + "}";
                request.Method = JSONmethod;
                // "POST";
                request.ContentType = " application/json;charset=UTF-8";   
                Byte[] bt = Encoding.UTF8.GetBytes(sb);
                Stream st = request.GetRequestStream();
                st.Write(bt, 0, bt.Length);
                st.Close();


                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    if (response.StatusCode != HttpStatusCode.OK) throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).", response.StatusCode,
                    response.StatusDescription));
                    
                    Stream stream1 = response.GetResponseStream();   
                    StreamReader sr = new StreamReader(stream1);
                    string strsb = sr.ReadToEnd();
                    object objResponse = JsonConvert.DeserializeObject(strsb, JSONResponseType);

                    return objResponse;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        // Converts the specified JSON string to an object of type T
        public T Deserialize<T>(string context)
        {
            string jsonData = context;

            //cast to specified objectType
            var obj = (T)new JavaScriptSerializer().Deserialize<T>(jsonData);
            return obj;
        }

        public string generateUrl (string MethodName)
        {
            //ConfigurationManager.AppSettings 
            string serviceName = "http://letzgst.com/SNService.svc/" + MethodName;
            return serviceName;

        }

        public bool CheckExtensionPanCard(string pancard)
        {
            var hasNumber = new Regex(@"^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$");

            return (hasNumber.IsMatch(pancard)) ? true : false;
        }

        public letzGST_Service.ResLogin generateDummyLogin()
        {
            letzGST_Service.ResLogin login = new letzGST_Service.ResLogin {
                AuthKey = "35O*^&p*5z9s",
                ParentId = 35,
                UserId = 35,
                UserRoleAuth = null,
                UserType = 2,
                authId = 114,
                ResponseCode = 0,
                ResponseMessage = "Login Successfully Done"
            };

            return login;
        }

        //public static bool CheckAdhaar(this string pattern)
        //{
        //    var hasNumber = new Regex(@"^[0-9]{12}$");

        //    return (hasNumber.IsMatch(pattern)) ? true : false;
        //}

        //public static bool CheckVATTIN(this string pattern)
        //{
        //    var hasNumber = new Regex(@"^[0-9]{11}$");

        //    return (hasNumber.IsMatch(pattern)) ? true : false;
        //}

        //public static bool CheckSERVICETAX(this string pattern)
        //{
        //    var hasNumber = new Regex(@"^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[a-zA-Z]{2}[0-9]{3}$");

        //    return (hasNumber.IsMatch(pattern)) ? true : false;
        //}

        //public static bool CheckGSTIN(this string pattern)
        //{
        //    var hasNumber = new Regex(@"^[0-9]{2}[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9A-Z]{1}Z[0-9a-zA-Z]{1}$");

        //    return (hasNumber.IsMatch(pattern)) ? true : false;
        //}

        //public static bool CheckCIN(this string pattern)
        //{
        //    var hasNumber = new Regex(@"^[luLU]{1}[0-9]{5}[a-zA-Z]{2}[0-9]{4}[a-zA-Z]{3}[0-9]{6}$");

        //    return (hasNumber.IsMatch(pattern)) ? true : false;
        //}


        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        public static void ConvertHtml2PdfPdfCrowd(string html, string filePath, string FileName)
        {
            System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            try
            {
                string objReader = htmlStyle + html + closeHtml;
                // create an API client instance
                pdfcrowd.Client client = new pdfcrowd.Client("ShivJha", "8935ddc2cc674f9606e5b9b7e09428f2");
                // convert a web page and write the generated PDF to a memory stream
                MemoryStream Stream = new MemoryStream();

                client.convertHtml(objReader, Stream);
                // set HTTP response headers
                Response.Clear();
                Response.AddHeader("Content-Type", "application/pdf");
                Response.AddHeader("Cache-Control", "max-age=0");
                Response.AddHeader("Accept-Ranges", "none");
                Response.AddHeader("Content-Disposition", "attachment; filename="+ FileName);

                // send the generated PDF
                Stream.WriteTo(Response.OutputStream);
                using (Stream file = File.Create(Path.Combine(HttpContext.Current.Server.MapPath(filePath), FileName))) // +"\\uploads\\" + "NewABC.pdf"))
                {
                    CopyStream(Stream, file);
                }
                Stream.Close();
                //Response.End();
                //Response.End();
            }
            catch (pdfcrowd.Error why)
            {
                Response.Write(why.ToString());
            }
        }

        public const string htmlStyle = @"<!DOCTYPE html>
        <html>
                <style>
                body.A4.sheet {
                    width: 210mm;
                    height: 296mm;
                }

                .sheet.padding-6mm {
                    padding: 6mm;
                }

                .pdftbl {
                    border-collapse: collapse;
                    border-spacing: 0;
                    text-align: center;
                }

                .pdftbl th
                {
                    border-style: solid;
                    border-width: 1px;
                    overflow: hidden;
                    word-break: normal;
                    height: 30px;
                    background-color: #ddd;
                                padding: 0 4px;
                }

                            .pdftbl td
                {
                    border-style: solid;
                    border-width: 1px;
                    overflow: hidden;
                    word-break: normal;
                    height: 30px;
                }
                .pdftbl.footer {
                    font-weight: bold;
                }
            </style>";

        public const string closeHtml = "</html>";

    }

    public class EMailResponse : ResCommon
    {
        public string FileURL { get; set; }
    }
}