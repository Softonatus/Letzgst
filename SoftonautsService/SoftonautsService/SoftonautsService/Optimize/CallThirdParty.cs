using EASendMail;
using SoftonautsService.CRequest;
using SoftonautsService.CResponse;
using SoftonautsService.Optimize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace SoftonautsService.Optimize
{
    public static class CallThirdParty
    {

        public static ResOtp SendMessage(string mobileNo)
        {
            Random rn = new Random();
            int Otp = rn.Next(100000, 999999);
            ReqInsertOtp reqInsertOtp = new ReqInsertOtp();
            reqInsertOtp.OtpNo = Otp;
            reqInsertOtp.mobileNo = mobileNo;
            ResOtp resOtp = new ResOtp();
            string body = "Dear Customer ," + Otp + "  is your one time password(OTP).Please enter the OTP to proceed.Thank you,Team Letzgst";
           
            //HTTP connection;
            string createdURL = StaticConst.SMSURL + "authkey="+ StaticConst .AUTHKEY+ "&mobiles="+ mobileNo + "&message=" + body + "&sender="+StaticConst.SENDERID+"&otp="+Otp;
            if (CreateHttpRequest(createdURL) == 200)
                return Common<ReqInsertOtp, ResOtp>.Serialize_Deserialize(reqInsertOtp, resOtp, StaticConst.SP_INSERTOTP);
            else return null;
        }


        public static void SendDefaultPassword(string mobileNo,string Password)
        {

            string message = "Please use this default password " + Password + "to login in Letzgst";
            //Create the request and send data to Ozeki NG SMS Gateway Server by
            //HTTP connection;
            string createdURL = StaticConst.SMSURL + "authkey=" + StaticConst.AUTHKEY + "&mobile=" + mobileNo + "&message=" + message + "&sender=" + StaticConst.SENDERID + "&otp=" + Password;
            CreateHttpRequest(createdURL);
               
        }


        public static void SendMail(string EmailId,string Password)
        {
           
                try
                {
                EASendMail.SmtpMail oMail = new SmtpMail("TryIt");
                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();

                // Set sender email address, please change it to yours
                oMail.From = StaticConst.EMAILID;

                // Set recipient email address, please change it to yours
                oMail.To = EmailId;

                // Set email subject
                oMail.Subject = "Auto Generated Password for first time User.";

                // Set email body
                oMail.TextBody = "Please Use this auto generated password";
             
                oMail.HtmlBody = "<html><body>Please Use this auto generated password<b>"+Password+"</b></body></html>";
               // oMail.AddAttachment("http://app.letzgst.com/AllDesign/Reports/Reports.html");
                // Your SMTP server address
                SmtpServer oServer = new SmtpServer("letzgst.com");

                // User and password for ESMTP authentication, if your server doesn't require
                // User authentication, please remove the following codes.
                oServer.User = StaticConst.EMAILID;
                oServer.Password = StaticConst.EMAILPASSWORD;
                oSmtp.SendMail(oServer, oMail);

            }
                catch (Exception ex)
                {
                    
                }
               
        }

        public static ResCommon SendMailCustom(ReqEmail reqEmail,string Password = null)
        {
            ResCommon resCommon = new ResCommon();
            try
            {
                EASendMail.SmtpMail oMail = new SmtpMail("TryIt");
                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();

                // Set sender email address, please change it to yours
                oMail.From = StaticConst.EMAILID;

                // Set recipient email address, please change it to yours
                oMail.To = reqEmail.EmailId;
                oMail.From = new EASendMail.MailAddress(reqEmail.UserName, StaticConst.EMAILID);

                // Set email subject
                oMail.Subject = reqEmail.EmailSubject;

                string path = AppDomain.CurrentDomain.BaseDirectory + "\\Optimize\\EmailHtml\\";
                StreamReader strReader = new StreamReader(path + reqEmail.HtmlType + ".html");
                string objReader = strReader.ReadToEnd();
                objReader = objReader.Replace("{{Username}}", reqEmail.UserName);
                objReader = objReader.Replace("{{EmailBody}}", reqEmail.EmailBody);

                if (reqEmail.HtmlType.Contains("Password"))
                    objReader.Replace("{{ Password}}", Password);
                oMail.HtmlBody = objReader;
                if(!String.IsNullOrEmpty(reqEmail.EmailAttachmentUrl))
                    oMail.AddAttachment(reqEmail.EmailAttachmentUrl);
                // Your SMTP server address
                SmtpServer oServer = new SmtpServer(StaticConst.SERVERNAME);

                // User and password for ESMTP authentication, if your server doesn't require
                // User authentication, please remove the following codes.
                
                oServer.User = StaticConst.EMAILID;
                
                oServer.Password = StaticConst.EMAILPASSWORD;
                oSmtp.SendMail(oServer, oMail);
                resCommon.ResponseCode = 0;
                resCommon.ResponseMessage = "Email Sent Successfully";

                return resCommon;
            }
            catch (Exception ex)
            {
                resCommon.ResponseCode = 1;
                resCommon.ResponseMessage = "Error while sending Email";
                return resCommon;
            }

        }

        

        public static int CreateHttpRequest(string Url)
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(Url);

            //Get response from Ozeki NG SMS Gateway Server and read the answer
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();


            string jsonResultHttp = new JavaScriptSerializer().Serialize(myResp);
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string res = respStreamReader.ReadToEnd();
            //HttpWebResponse httpResponse = (HttpWebResponse)tResponse;
            int statusCode = Convert.ToInt16(myResp.StatusCode);


            
            //string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();



            return statusCode;
        }


        

    }
}
