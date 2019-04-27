/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - PayPalPayment.aspx.cs
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
    public partial class PayPalPayment : System.Web.UI.Page
    {
        private Boolean alreadyPaid = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null || Session["Name"].ToString() != "user") // user/admin has not logged in
            {
                Response.Redirect("~/Pages/Error");
            }
        }

        protected void btnValidate_Click1(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                alreadyPaid = true;
                btnPayPalSubmit.Enabled = true;
                btnPayPalSubmit.Visible = true;
                btnValidate.Visible = false;
                PayPalVerified.Visible = true;
                paypalEmail.Enabled = false;
                paypalPassword.Enabled = false;
            }


        }
    }
}