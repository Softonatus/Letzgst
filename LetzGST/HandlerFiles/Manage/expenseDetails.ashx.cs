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
    /// Summary description for expenseDetails
    /// </summary>
    public class expenseDetails : IHttpHandler, IRequiresSessionState
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
                    string operType = Convert.ToString(context.Request.QueryString["opertype"]);
                    if (operType == "get")
                    {
                        string url = generateReq.generateUrl("GetExpense");
                        ReqUserId request = new ReqUserId();
                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            request.UserId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            request.UserId = Convert.ToInt32(UserDetails.ParentId);
                        }
                        var expenseResponse = MakeRequest.getServiceObject(url, request, "reqUserId", "POST", typeof(ResGetExpenseList));
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
                        ReqInsertExpense expenseReq = new ReqInsertExpense();
                        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                        expenseReq = generateReq.Deserialize<ReqInsertExpense>(strJson);
                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            expenseReq.UserId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            expenseReq.UserId = Convert.ToInt32(UserDetails.ParentId);
                        }
                        string url = generateReq.generateUrl("InsertExpense");
                        var insertResponse = MakeRequest.getServiceObject(url, expenseReq, "reqInsertExpense", "POST", typeof(ResId));

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