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
using System.Globalization;

namespace LetzGST.HandlerFiles.Manage
{
    /// <summary>
    /// Summary description for CreditNoteDetails
    /// </summary>
    public class CreditNoteDetails : IHttpHandler, IRequiresSessionState
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
                        string url = generateReq.generateUrl("GetCredit");
                        ReqUserId request = new ReqUserId();
                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            request.UserId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            request.UserId = Convert.ToInt32(UserDetails.ParentId);
                        }
                        var expenseResponse = MakeRequest.getServiceObject(url, request, "reqUserId", "POST", typeof(ResCreditNoteGetList));
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
                        ReqCreditNote creditReq = new ReqCreditNote();
                        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                        creditReq = generateReq.Deserialize<ReqCreditNote>(strJson);
                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            creditReq.UserId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            creditReq.UserId = Convert.ToInt32(UserDetails.ParentId);
                        }
                        //string DueDate = debitReq.DueDate;
                        string PoDate = creditReq.CreditDate; ;
                        IFormatProvider culture = new CultureInfo("en-US", true);

                       // DateTime dueDateVal = DateTime.ParseExact(DueDate, "dd/MM/yyyy", null);
                        DateTime poDateVal = DateTime.ParseExact(PoDate, "dd/MM/yyyy", null);


                       // creditReq.DueDate = dueDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                        creditReq.CreditDate = poDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");

                        string url = generateReq.generateUrl("InsertCredit");
                        var insertResponse = MakeRequest.getServiceObject(url, creditReq, "reqCreditNote", "POST", typeof(ResCommon));

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
                    else if (operType == "update")
                    {
                        ReqCreditNote creditReq = new ReqCreditNote();
                        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                        creditReq = generateReq.Deserialize<ReqCreditNote>(strJson);
                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            creditReq.UserId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            creditReq.UserId = Convert.ToInt32(UserDetails.ParentId);
                        }
                        //string DueDate = debitReq.DueDate;
                        string PoDate = creditReq.CreditDate; ;
                        IFormatProvider culture = new CultureInfo("en-US", true);

                        // DateTime dueDateVal = DateTime.ParseExact(DueDate, "dd/MM/yyyy", null);
                        DateTime poDateVal = DateTime.ParseExact(PoDate, "dd/MM/yyyy", null);


                        // creditReq.DueDate = dueDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                        creditReq.CreditDate = poDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");

                        string url = generateReq.generateUrl("UpdateCredit");
                        var insertResponse = MakeRequest.getServiceObject(url, creditReq, "reqCreditNote", "POST", typeof(ResCommon));

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
                    else if (operType == "delete")
                    {
                        ReqId reqId = new ReqId();
                        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                        reqId = generateReq.Deserialize<ReqId>(strJson);


                        string url = generateReq.generateUrl("DeleteCredit");
                        var insertResponse = MakeRequest.getServiceObject(url, reqId, "reqId", "POST", typeof(ResCommon));

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
                    else if (operType == "getcreditNoteDetails")
                    {
                        ReqId reqPODetails = new ReqId();
                        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                        reqPODetails = generateReq.Deserialize<ReqId>(strJson);
                        string url = "";
                        if (Convert.ToString(context.Request.QueryString["act"]) != null)
                        {
                            url = generateReq.generateUrl("GetCreditDetail");
                            var insertResponse = MakeRequest.getServiceObject(url, reqPODetails, "reqId", "POST", typeof(ResCreditNoteGetList));
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
                            url = generateReq.generateUrl("GetCreditDetail");
                            var insertResponse = MakeRequest.getServiceObject(url, reqPODetails, "reqId", "POST", typeof(ResCreditNoteGetList));
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