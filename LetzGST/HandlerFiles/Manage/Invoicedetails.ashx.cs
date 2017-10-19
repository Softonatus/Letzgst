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
    /// Summary description for Invoicedetails
    /// </summary>
    public class Invoicedetails : IHttpHandler, IRequiresSessionState
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
                    string url = generateReq.generateUrl("GetInvoice");
                    ReqUserId request = new ReqUserId();
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        request.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        request.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }
                    var POResponse = MakeRequest.getServiceObject(url, request, "reqUserId", "POST", typeof(ResInvoiceGetList));
                    if (POResponse != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(POResponse));
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
                    ReqInvoice reqBill = new ReqInvoice();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    reqBill = generateReq.Deserialize<ReqInvoice>(strJson);
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        reqBill.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        reqBill.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }

                    string DueDate = reqBill.DueDate;
                    string PoDate = reqBill.InvoiceDate;
                    string EndDate = reqBill.SupplyDate;
                    IFormatProvider culture = new CultureInfo("en-US", true);

                    DateTime dueDateVal = DateTime.ParseExact(DueDate, "dd/MM/yyyy", null);
                    DateTime poDateVal = DateTime.ParseExact(PoDate, "dd/MM/yyyy", null);
                    if (reqBill.SupplyDate != null)
                    {
                        DateTime endDateVal = DateTime.ParseExact(EndDate, "dd/MM/yyyy", null);
                        reqBill.SupplyDate = endDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    }

                    reqBill.DueDate = dueDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    reqBill.InvoiceDate = poDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    string url = generateReq.generateUrl("InsertInvoice");
                    var insertResponse = MakeRequest.getServiceObject(url, reqBill, "reqInvoice", "POST", typeof(ResCommon));

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
                    //SNServiceClient client = new SNServiceClient();
                    //client.UpdateBill
                    ReqInvoice reqUpdatePurchase = new ReqInvoice();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    reqUpdatePurchase = generateReq.Deserialize<ReqInvoice>(strJson);
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        reqUpdatePurchase.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        reqUpdatePurchase.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }

                    string DueDate = reqUpdatePurchase.DueDate;
                    string PoDate = reqUpdatePurchase.InvoiceDate;
                    string EndDate = reqUpdatePurchase.SupplyDate;
                    IFormatProvider culture = new CultureInfo("en-US", true);

                    DateTime dueDateVal = DateTime.ParseExact(DueDate, "dd/MM/yyyy", null);
                    DateTime poDateVal = DateTime.ParseExact(PoDate, "dd/MM/yyyy", null);

                    if (reqUpdatePurchase.SupplyDate != null)
                    {
                        DateTime endDateVal = DateTime.ParseExact(EndDate, "dd/MM/yyyy", null);
                        reqUpdatePurchase.SupplyDate = endDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    }

                    reqUpdatePurchase.DueDate = dueDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    reqUpdatePurchase.InvoiceDate = poDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");

                    string url = generateReq.generateUrl("UpdateInvoice");
                    var updateResponse = MakeRequest.getServiceObject(url, reqUpdatePurchase, "reqInvoice", "POST", typeof(ResCommon));

                    if (updateResponse != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(updateResponse));
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


                    string url = generateReq.generateUrl("DeleteInvoice");
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
                else if (operType == "getPODetails")
                {
                    ReqId reqPODetails = new ReqId();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    reqPODetails = generateReq.Deserialize<ReqId>(strJson);
                    string url = ""; ;
                    if (Convert.ToString(context.Request.QueryString["act"]) != null)
                    {
                        url = generateReq.generateUrl("GetInvoiceDetail");
                        var insertResponse = MakeRequest.getServiceObject(url, reqPODetails, "reqId", "POST", typeof(ResInvoiceGetList));
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
                        url = generateReq.generateUrl("GetInvoiceDetail");
                        var insertResponse = MakeRequest.getServiceObject(url, reqPODetails, "reqId", "POST", typeof(ResInvoiceGetList));
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