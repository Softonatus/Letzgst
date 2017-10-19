using System;
using System.Web;
using System.Web.SessionState;
using LetzGST.letzGST_Service;
using LetzGST.Common;
using Newtonsoft.Json;
using pdfcrowd;
using System.IO;
using Newtonsoft.Json.Linq;

namespace LetzGST.HandlerFiles.Manage
{
    /// <summary>
    /// Summary description for SendEmail
    /// </summary>
    public class SendEmail : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            try
            {
                if (context.Session["UserDetails"] != null)
                {
                    ResLogin UserDetails = new ResLogin();
                    MakeRequest generateReq = new MakeRequest();

                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        string sessionName = "company_" + context.Request.QueryString["cmp_id"];
                        UserDetails = (ResLogin)context.Session[sessionName];
                    }
                    else
                    {
                        UserDetails = (ResLogin)context.Session["UserDetails"];
                    }

                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();

                    string Html = context.Request.Form["html"];

                    string folderName = context.Request.Form["HtmlType"];
                    string fName = folderName + "_" + UserDetails.Name + "_" + UserDetails.UserId + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".pdf";
                    string folderPath = "~/uploads/" + UserDetails.UserId + "/" + folderName + "/";
                    bool exists = System.IO.Directory.Exists(context.Server.MapPath(folderPath));
                    if (!exists)
                    {
                        Directory.CreateDirectory(context.Server.MapPath(folderPath));
                    }
                     MakeRequest.ConvertHtml2PdfPdfCrowd(Html, folderPath, fName);
                    context.Response.Clear();
                    String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
                    String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
                    string uploadPath = strUrl + "uploads/" + UserDetails.UserId + "/" + folderName + "/" + fName;


                    string emailId = context.Request.Form["emailId"];
                    string emailSubject = context.Request.Form["emailSubject"];
                    string Content = context.Request.Form["content"];
                    string AttachmentUrl = uploadPath;

                    ReqEmail requestEmail = new ReqEmail();
                    requestEmail.EmailId = emailId;
                    requestEmail.EmailSubject = emailSubject;
                    requestEmail.EmailBody = Content;
                    requestEmail.HtmlType = folderName;
                    requestEmail.EmailAttachmentUrl = uploadPath;
                    requestEmail.UserName = UserDetails.Name;

                    string url = generateReq.generateUrl("SendMailCustom");
                    var insertResponse = MakeRequest.getServiceObject(url, requestEmail, "reqEmail", "POST", typeof(ResCommon));

                    EMailResponse resp = new EMailResponse();
                    ResCommon commOnResp = new ResCommon();
                    commOnResp = (ResCommon)insertResponse;
                    resp.ResponseCode = commOnResp.ResponseCode;
                    resp.ResponseMessage = commOnResp.ResponseMessage;
                    resp.FileURL = uploadPath;

                    context.Response.ContentType = "text/json";
                    if (insertResponse != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(insertResponse));
                    }
                    else
                    {
                        ResCommon timeOut = new ResCommon();
                        timeOut.ResponseCode = -102;
                        timeOut.ResponseMessage = "No Response from server";
                        context.Response.Write(JsonConvert.SerializeObject(timeOut));
                    }
                }
                else

                {
                    ResCommon timeOut = new ResCommon();
                    timeOut.ResponseCode = -100;
                    timeOut.ResponseMessage = "Session Timed Out";
                    context.Response.Write(JsonConvert.SerializeObject(timeOut));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}