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

namespace LetzGST.HandlerFiles.Dashboard
{
    /// <summary>
    /// Summary description for Profile
    /// </summary>
    public class Profile : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/json";               
                
                if(context.Session["UserDetails"] != null)
                {
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    MakeRequest generateReq = new MakeRequest();

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
                        
                    string action = Convert.ToString(context.Request.QueryString["action"]);


                    if (action != null)
                    {
                        ReqProfile profileReq = new ReqProfile();
                        profileReq = generateReq.Deserialize<ReqProfile>(strJson);
                        UserDetails.State = profileReq.State;
                        context.Session.Add("UserDetails", UserDetails);
                        string url = "";
                        if(action == "I")
                        {
                            url = generateReq.generateUrl("InsertProfile");
                            profileReq.CreatedDate = DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss");
                        }
                        else
                        {
                            url = generateReq.generateUrl("UpdateProfile");
                        }
                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            profileReq.UserId = UserDetails.UserId;
                        }
                        else
                        {
                            if (UserDetails.UserType == 4)
                            {
                                profileReq.UserId = UserDetails.UserId;
                            }
                            else
                            {
                                profileReq.UserId = UserDetails.ParentId;
                            }
                           
                        }
                        bool validatePAN = generateReq.CheckExtensionPanCard(profileReq.PanNo);
                        

                        if (validatePAN)
                        {
                            var responseProfile = MakeRequest.getServiceObject(url, profileReq, "reqProfile", "POST", typeof(ResCommon));

                            if (responseProfile != null)
                            {
                                context.Response.Write(JsonConvert.SerializeObject(responseProfile));
                            }
                            else
                            {
                                context.Response.Write("No Data");
                            }
                        }
                        else
                        {
                            ResCommon inavlid = new ResCommon();
                            inavlid.ResponseCode = -101;
                            inavlid.ResponseMessage = "Invalid Pan Card Details";
                            context.Response.Write(JsonConvert.SerializeObject(inavlid));
                        }
                        
                    }
                    else
                    {
                        ReqUserId fetchprofile = new ReqUserId();
                        fetchprofile = generateReq.Deserialize<ReqUserId>(strJson);
                        string url = generateReq.generateUrl("GetProfile");
                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            fetchprofile.UserId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            fetchprofile.UserId = Convert.ToInt32(UserDetails.ParentId);
                        }
                        
                        var resProfileDetails = MakeRequest.getServiceObject(url, fetchprofile, "reqUserId", "POST", typeof(ResProfile));
                        if (resProfileDetails != null)
                        {
                            context.Response.Write(JsonConvert.SerializeObject(resProfileDetails));
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