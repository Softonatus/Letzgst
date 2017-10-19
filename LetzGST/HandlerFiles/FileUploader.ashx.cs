using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.SessionState;
using LetzGST.letzGST_Service;

namespace LetzGST.HandlerFiles
{
    /// <summary>
    /// Summary description for FileUploader
    /// </summary>
    public class FileUploader : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string folderName = Convert.ToString(context.Request.QueryString["type"]);
            string fileName = Convert.ToString(context.Request.QueryString["FileName"]);
            string fname = "";
            string folderPath = "";
            if (context.Session["UserDetails"] != null)
            {
                ResLogin UserDetails = new ResLogin();

                if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                {
                    string sessionName = "company_" + context.Request.QueryString["cmp_id"];
                    UserDetails = (ResLogin)context.Session[sessionName];
                }
                else
                {
                    UserDetails = (ResLogin)context.Session["UserDetails"];
                }

                if (context.Request.Files.Count > 0)
                {
                    HttpFileCollection files = context.Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFile file = files[i];
                        if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE" || HttpContext.Current.Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        folderPath = "~/uploads/" + UserDetails.UserId + "/" + folderName + "/";
                        bool exists = System.IO.Directory.Exists(context.Server.MapPath(folderPath));
                        if (!exists)
                        {
                            Directory.CreateDirectory(context.Server.MapPath(folderPath));
                        }
                         
                        fname = Path.Combine(context.Server.MapPath(folderPath), fname);
                        file.SaveAs(fname);
                    }
                }
                if(folderName == "Logo")
                {
                    String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
                    String strUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");
                    string uploadPath = strUrl + "uploads/" + UserDetails.UserId + "/" + folderName + "/" + fileName;
                    UserDetails.LogoUrl = uploadPath;
                }
                context.Response.Write(folderPath + "/" + fileName);
            }
            else
            {
                context.Response.Write("Session Invalid");

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