/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - Site.Master.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerchKraft1
{
    public partial class SiteMaster : MasterPage
    {
        protected TestData td = new TestData();
        protected void Page_Load(object sender, EventArgs e)
        {

            Object seshName = Session["Name"]; // stores session name object
            string pageName = System.IO.Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath); // gets the page name

            //Label1.Text = td.getTotalUsers().ToString(); // + ", " + td.returnNoOfAdmins().ToString()
            //Label2.Text = "Label2: TotalUsers" + td.getTotalUsers(); // + ", " + td.returnNoOfAdmins().ToString()
            //Label3.Text = "Label3: TotalUsers" + td.getTotalUsers(); // + ", " + td.returnNoOfAdmins().ToString()

            if (seshName != null) // user has logged in 
            {
                String sessionName = seshName.ToString();
                welcomeLabel.Text = "Welcome back, " + seshName.ToString() + "!";
                logoutButton.Visible = true;

                // to prevent any users logged in from registering as either admin or customer
                if (pageName == "Login" || pageName == "Register" || pageName == "AdminRegister") Response.Redirect("../../Default");
                // cannot logout when making payments
                if (pageName == "Checkout" || pageName == "BankCardPayment" || pageName == "PayPalPayment") logoutButton.Visible = false;
                

                String loginID = td.getLoginID(sessionName);
                String adminName = td.getAdminName(loginID);

                if (sessionName == adminName)
                {
                    PlaceHolder1.Visible = false;
                    PlaceHolder2.Visible = false;
                    ManagePlaceHolder.Visible = true;
                    userButton.Visible = true;
                    cartImgButton.Visible = false;
                    if (pageName == "Default") MainContent.Visible = false; // hides content visible to public if admin logged ins
                    AdminContent.Visible = true;
                    UserContent.Visible = false;
                }
                else
                {
                    MainContent.Visible = true;
                    AdminContent.Visible = false;
                    userButton.Visible = true;
                }
            }
            else // user has not logged in yet, so show login button
            {
                // to not show login button when on login page
                if (pageName == "Login") loginButton1.Visible = false;
                else loginButton1.Visible = true;

                AdminContent.Visible = false;
                UserContent.Visible = false;
                MainContent.Visible = true;

            }
        }

        protected void loginButton1_Click(object sender, EventArgs e)
        { // main login button will go to login page if no one has logged in yet
            Response.Redirect("~/Pages/Login/Login");
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Remove("name"); // removes name of user logged in
            Session.Clear();
            logoutButton.Visible = false; // remove logout button 
            Response.Redirect("~/Pages/Login/Logout");
        }

        protected void userButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Pages/Profile/Profile");
        }

    }
}