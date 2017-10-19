using LetzGST.letzGST_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LetzGST
{
    public partial class GSTSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserDetails"] == null)
            {
                Response.Redirect("~/Index.aspx");
            }
            
        }
    }
}