using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerchKraft1.Pages.AdminAccount
{
    public partial class SuccessfullyAdded : System.Web.UI.Page
    {
        private TestData td = new TestData();
        protected void Page_Load(object sender, EventArgs e)
        {
            String sessionName = Session["Name"].ToString();
            String loginID = td.getLoginID(sessionName);
            String adminName = td.getAdminName(loginID);
            if (Session["Name"] == null || sessionName != adminName) // user/admin has not logged in
            {
                Response.Redirect("~/Pages/Error");
            }
        }
    }
}