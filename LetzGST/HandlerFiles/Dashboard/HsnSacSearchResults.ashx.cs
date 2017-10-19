using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LetzGST.letzGST_Service;
using LetzGST.Common;
using System.Web.SessionState;
using System.IO;
using Newtonsoft.Json;

namespace LetzGST.HandlerFiles.Dashboard
{
    /// <summary>
    /// Summary description for HsnSacSearchResults
    /// </summary>
    public class HsnSacSearchResults : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            try
            {
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

                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    MakeRequest generateReq = new MakeRequest();

                    ReqHsnCode request = new ReqHsnCode();
                    request = generateReq.Deserialize<ReqHsnCode>(strJson);

                    string url = generateReq.generateUrl("HsnDetailSearch");
                    ResListHsnCodeGoods srcResponse = new ResListHsnCodeGoods();
                    var response = MakeRequest.getServiceObject(url, request, "reqHsnCode", "POST", typeof(ResListHsnCodeGoods));

                    if (response != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(response));
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