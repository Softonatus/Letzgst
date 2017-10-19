using LetzGST.letzGST_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LetzGST.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] == null)
            {
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                if (Convert.ToString(Request.QueryString["usertype"]) != null)
                {
                    string userType = Convert.ToString(Request.QueryString["usertype"]);
                    int cmp_id = Convert.ToInt32(Request.QueryString["cmp_id"]);
                    if (Session["UserDetails"] != null)
                    {
                        ResLogin CompanyDetails = new ResLogin();
                        string sessionName = "company_" + cmp_id;
                        hdn_uType.Value = Convert.ToString(CompanyDetails.UserType);
                        hdn_Main.Value = Convert.ToString(CompanyDetails.UserId);
                        hdn_LoginName.Value = Convert.ToString(CompanyDetails.Name);
                        hdn_LogoUrl.Value = Convert.ToString(CompanyDetails.LogoUrl);
                        hdn_Expiry.Value = "2017-11-02";// Convert.ToString(CompanyDetails.ExpiryDate);
                    }
                }
                else if (Session["UserDetails"] != null)
                {
                    ResLogin UserDetails = new ResLogin();
                    UserDetails = (ResLogin)Session["UserDetails"];
                    hdn_uType.Value = Convert.ToString(UserDetails.UserType);
                    hdn_Main.Value = Convert.ToString(UserDetails.ParentId);
                    hdn_LoginName.Value = Convert.ToString(UserDetails.Name);
                    hdn_LogoUrl.Value = Convert.ToString(UserDetails.LogoUrl);
                    hdn_Expiry.Value = "2017-11-02";//Convert.ToString(UserDetails.ExpiryDate);
                }
            }
        }

        [System.Web.Services.WebMethod]
        public static string GetExpenseDetails(string name)
        {
            return "Hello " + name + Environment.NewLine + "The Current Time is: "
                + DateTime.Now.ToString();
        }
    }
}