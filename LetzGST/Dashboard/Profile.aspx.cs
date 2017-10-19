using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LetzGST.letzGST_Service;

namespace LetzGST.Dashboard
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Request.QueryString["usertype"]) != null)
            {
                string userType = Convert.ToString(Request.QueryString["usertype"]);

                int cmp_id = Convert.ToInt32(Request.QueryString["cmp_id"]);
                if (Session["UserDetails"] != null)
                {
                    ResLogin CompanyDetails = new ResLogin();
                    string sessionName = "company_" + cmp_id;
                    CompanyDetails = (ResLogin)Session[sessionName];
                    hdn_uType.Value = Convert.ToString(CompanyDetails.UserType);
                    hdn_LoginName.Value = Convert.ToString(CompanyDetails.Name);
                    hdn_LogoUrl.Value = Convert.ToString(CompanyDetails.LogoUrl);
                    hdn_Expiry.Value = "2017-11-02";// Convert.ToString(CompanyDetails.ExpiryDate);
                    if (CompanyDetails.ResponseCode == 0)
                    {
                        hdn_FirstTime.Value = "1";
                    }
                }
            }
            else if (Session["UserDetails"] != null)
            {
                ResLogin UserDetails = new ResLogin();
                UserDetails = (ResLogin)Session["UserDetails"];
                hdn_uType.Value = Convert.ToString(UserDetails.UserType);
                hdn_LoginName.Value = Convert.ToString(UserDetails.Name);
                hdn_LogoUrl.Value = Convert.ToString(UserDetails.LogoUrl);
                hdn_Expiry.Value = "2017-11-02";// Convert.ToString(UserDetails.ExpiryDate);
                if (UserDetails.ResponseCode == 0)
                {
                    hdn_FirstTime.Value = "1";
                }
            }
        }
    }
}