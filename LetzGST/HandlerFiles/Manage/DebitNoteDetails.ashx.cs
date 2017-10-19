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
    /// Summary description for DebitNoteDetails
    /// </summary>
    public class DebitNoteDetails : IHttpHandler, IRequiresSessionState
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
                        string url = generateReq.generateUrl("GetDebit");
                        ReqUserId request = new ReqUserId();
                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            request.UserId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            request.UserId = Convert.ToInt32(UserDetails.ParentId);
                        }
                        var expenseResponse = MakeRequest.getServiceObject(url, request, "reqUserId", "POST", typeof(ResDebitNoteGetList));
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
                        ReqDebitNote debitReq = new ReqDebitNote();
                        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                        debitReq = generateReq.Deserialize<ReqDebitNote>(strJson);
                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            debitReq.UserId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            debitReq.UserId = Convert.ToInt32(UserDetails.ParentId);
                        }
                        string DueDate = debitReq.DueDate;
                        string PoDate = debitReq.DebitDate;;
                        IFormatProvider culture = new CultureInfo("en-US", true);

                        DateTime dueDateVal = DateTime.ParseExact(DueDate, "dd/MM/yyyy", null);
                        DateTime poDateVal = DateTime.ParseExact(PoDate, "dd/MM/yyyy", null);


                        debitReq.DueDate = dueDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                        debitReq.DebitDate = poDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");

                        string url = generateReq.generateUrl("InsertDebit");
                        var insertResponse = MakeRequest.getServiceObject(url, debitReq, "reqDebitNote", "POST", typeof(ResCommon));

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
                    else if(operType == "update")
                    {
                        ReqDebitNote debitReq = new ReqDebitNote();
                        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                        debitReq = generateReq.Deserialize<ReqDebitNote>(strJson);
                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            debitReq.UserId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            debitReq.UserId = Convert.ToInt32(UserDetails.ParentId);
                        }
                        string DueDate = debitReq.DueDate;
                        string PoDate = debitReq.DebitDate; ;
                        IFormatProvider culture = new CultureInfo("en-US", true);

                        DateTime dueDateVal = DateTime.ParseExact(DueDate, "dd/MM/yyyy", null);
                        DateTime poDateVal = DateTime.ParseExact(PoDate, "dd/MM/yyyy", null);


                        debitReq.DueDate = dueDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                        debitReq.DebitDate = poDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");

                        string url = generateReq.generateUrl("UpdateDebit");
                        var insertResponse = MakeRequest.getServiceObject(url, debitReq, "reqDebitNote", "POST", typeof(ResCommon));

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


                        string url = generateReq.generateUrl("DeleteDebit");
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
                    else if (operType == "getdebitNoteDetails")
                    {
                        ReqId reqPODetails = new ReqId();
                        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                        reqPODetails = generateReq.Deserialize<ReqId>(strJson);
                        string url = ""; ;
                        if (Convert.ToString(context.Request.QueryString["act"]) != null)
                        {
                            url = generateReq.generateUrl("GetDebitDetail");
                            var insertResponse = MakeRequest.getServiceObject(url, reqPODetails, "reqId", "POST", typeof(ResDebitNoteGetList));
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
                            url = generateReq.generateUrl("GetDebitDetail");
                            var insertResponse = MakeRequest.getServiceObject(url, reqPODetails, "reqId", "POST", typeof(ResDebitNoteGetList));
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