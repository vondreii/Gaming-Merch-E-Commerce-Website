/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - ManageItem.aspx.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerchKraft1.Pages.AdminAccount
{
    public partial class ManageItem : System.Web.UI.Page
    {
        protected TestData td = new TestData();
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