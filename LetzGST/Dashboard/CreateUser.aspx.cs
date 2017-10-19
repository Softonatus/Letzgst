using LetzGST.letzGST_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LetzGST.Dashboard
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] == null)
            {
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                ResLogin UserDetails = new ResLogin();
                UserDetails = (ResLogin)Session["UserDetails"];
                if (UserDetails.ResponseCode == 0)
                {
                    hdn_uType.Value = Convert.ToString(UserDetails.UserType);
                    hdn_LoginName.Value = Convert.ToString(UserDetails.Name);
                    hdn_LogoUrl.Value = Convert.ToString(UserDetails.LogoUrl);
                }
            }
        }
    }
}