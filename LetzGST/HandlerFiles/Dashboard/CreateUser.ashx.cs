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
    /// Summary description for CreateUser
    /// </summary>
    public class CreateUser : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/json";
                if (context.Session["UserDetails"] != null)
                {
                    string actionType = Convert.ToString(context.Request.QueryString["type"]);
                    string page = Convert.ToString(context.Request.QueryString["page"]);
                    string url = "";

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
                                        
                    if(actionType == "insert")
                    {
                        #region Insert User

                        ReqRegistration regRequest = new ReqRegistration();
                        //deserialize the object
                        regRequest = generateReq.Deserialize<ReqRegistration>(strJson);
                        if (page == "UR")
                        {
                            regRequest.ParentId = UserDetails.UserId;
                        }
                        else if (page == "CR")
                        {
                            regRequest.ParentId = UserDetails.ParentId;
                        }
                            regRequest.IsActive = true;
                        regRequest.RegisteredDate = DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss");
                        regRequest.ExpiryDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd HH':'mm':'ss");

                        #region User Type
                        if (page == "UR")
                        {
                            /* 1= CA; 3= CA User; */
                            if (UserDetails.UserType != null && (UserDetails.UserType == 1 || UserDetails.UserType == 3))
                            {
                                regRequest.UserType = 3;
                            }
                            else if (UserDetails.UserType != null && (UserDetails.UserType == 2))
                            {
                                // 5 = company user
                                regRequest.UserType = 5;
                            }
                            else if (UserDetails.UserType != null &&  UserDetails.UserType == 4)
                            {
                                regRequest.UserType = 6;
                            }
                        }
                        else if(page == "CR")
                        {
                            regRequest.UserType = 4;
                        }
                        #endregion

                        url = generateReq.generateUrl("Registration");
                        ResRegistration regResponse = new ResRegistration();
                        var response = MakeRequest.getServiceObject(url, regRequest, "reqRegistration", "POST", typeof(ResRegistration));

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

                        #endregion
                    }
                    else if(actionType == "update")
                    {
                        ReqUpdateUser reqUpdate = new ReqUpdateUser();
                        reqUpdate = generateReq.Deserialize<ReqUpdateUser>(strJson);

                        url = generateReq.generateUrl("UpdateUser");

                        var UpdateRes = MakeRequest.getServiceObject(url, reqUpdate, "reqUpdateUser", "POST", typeof(ResCommon));
                        if (UpdateRes != null)
                        {
                            context.Response.Write(JsonConvert.SerializeObject(UpdateRes));
                        }
                        else
                        {
                            ResCommon timeOut = new ResCommon();
                            timeOut.ResponseCode = -102;
                            timeOut.ResponseMessage = "No Response from server";
                            context.Response.Write(JsonConvert.SerializeObject(timeOut));
                        }
                    }
                    else if (actionType == "delete")
                    {
                        ReqUserId delRequest = new ReqUserId();
                        delRequest = generateReq.Deserialize<ReqUserId>(strJson);

                        url = generateReq.generateUrl("DeleteUser");

                        var UpdateRes = MakeRequest.getServiceObject(url, delRequest, "reqUserId", "POST", typeof(ResCommon));
                        if (UpdateRes != null)
                        {
                            context.Response.Write(JsonConvert.SerializeObject(UpdateRes));
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