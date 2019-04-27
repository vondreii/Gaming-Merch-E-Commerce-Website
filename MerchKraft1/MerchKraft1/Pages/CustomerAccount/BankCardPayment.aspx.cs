/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - BankCardPayment.aspx.cs
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
    public partial class BankCardPayment : System.Web.UI.Page
    {
        //private Boolean alreadyPaid = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null || Session["Name"].ToString() != "user") // user/admin has not logged in
            {
                Response.Redirect("~/Pages/Error");
            }
            //if(alreadyPaid) container.Visible = false;
        }

        protected void btnValidate_Click1(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                btnCardSubmit.Visible = true;
                btnValidate.Visible = false;
                CardVerified.Visible = true;
                cardNum.Enabled = false;
                cardCode.Enabled = false;
                expiry.Enabled = false;
            }


        }

        protected void btnCardSubmit_Click(object sender, EventArgs e)
        {
            //AlreadyPaidView.Visible = true;
            //alreadyPaid = true;
        }
    }
}