using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using LetzGST.letzGST_Service;
using LetzGST.Common;
using System.Web.SessionState;

namespace LetzGST.HandlerFiles.Manage
{
    /// <summary>
    /// Summary description for ItemDetails
    /// </summary>
    public class ItemDetails : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            try
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
                string operType = Convert.ToString(context.Request.QueryString["opertype"]);
                if (operType == "get")
                {
                    string url = generateReq.generateUrl("GetUserItemList");
                    ReqUserId request = new ReqUserId();
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        request.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        request.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }
                    var expenseResponse = MakeRequest.getServiceObject(url, request, "reqUserId", "POST", typeof(ResUserItemsList));
                    if (expenseResponse != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(expenseResponse));
                    }
                    else
                    {
                        ResCommon timeOut = new ResCommon();
                        timeOut.ResponseCode = -102;
                        timeOut.ResponseMessage = "No Response from server";
                        context.Response.Write(JsonConvert.SerializeObject(timeOut));
                    }
                }
                else if (operType == "insert")
                {
                    ReqInsertUserItems itemReq = new ReqInsertUserItems();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    itemReq = generateReq.Deserialize<ReqInsertUserItems>(strJson);
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        itemReq.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        itemReq.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }
                    string url = generateReq.generateUrl("InsertUserItem");
                    var insertResponse = MakeRequest.getServiceObject(url, itemReq, "reqInsertUserItems", "POST", typeof(ResId));

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