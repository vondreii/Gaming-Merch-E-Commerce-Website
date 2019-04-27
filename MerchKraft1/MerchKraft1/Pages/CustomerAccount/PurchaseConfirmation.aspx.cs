/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - PurchaseConfirmation.aspx.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerchKraft1.Pages.CustomerAccount
{
    public partial class PurchaseConfirmation : System.Web.UI.Page
    {
        protected TestData td = new TestData();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null || Session["Name"].ToString() != "user") // user/admin has not logged in
            {
                Response.Redirect("~/Pages/Error");
            }
        }
    }
}