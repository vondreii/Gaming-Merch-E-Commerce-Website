/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - AdminRegister.aspx.cs
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
    public partial class AdminRegister : System.Web.UI.Page
    {
        private TestData td = new TestData();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                if (Session["Name"] == null)
                {
                    Session["Name"] = username.Text;
                    td.addNewAdmin(firstName.Text, lastName.Text, DateTime.Parse(dob.Text), 
                        role.Text, confirmEmail.Text, username.Text, pwd.Text);
                    Response.Redirect("~/Default");
                }
            }
        }
    }
}