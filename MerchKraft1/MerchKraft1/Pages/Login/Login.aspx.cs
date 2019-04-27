/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - Login.aspx.cs
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
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected TestData td = new TestData();
        private int numOfUsers = 0;
        private int userNum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Name"] == null)
            {
                td.setCurrentFunction("Logins");
                td.setCurrentItemToDisplay(userNum); // start with first user
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            td.setCurrentFunction("Logins");
            if (Session["Name"] == null)
            {
                userNum = 0;
                // while userNum != num of all users in system
                // check if the name entered matches
                // if not, increment and check if ^ 
                while (userNum != td.getTotalUsers()) // goes through all list of users
                {
                    td.setCurrentItemToDisplay(userNum); // start with first user [0] then changes to whatever userNum increments to

                    if (username.Text.Trim().Equals(td.getUser("username").Trim()) && pwd.Text.Trim().Equals(td.getUser("password").Trim())) { // if the username entered does not match 
                        
                        Session["Name"] = username.Text;
                        Response.Redirect("~/Default");
                        userNum = td.getTotalUsers();
                    } 
                    else {
                        userNum++; // increment
                        incorrectLabel.Text = "Oops! Looks like you have entered your wrong email/password";
                    }
                    
                }
            
                /*if ((username.Text == "admin" && pwd.Text == "password1") || (username.Text == "user" && pwd.Text == "password2"))
                {
                    Session["Name"] = username.Text;
                    Response.Redirect("~/Default");
                }
                else { incorrectLabel.Text = "Oops! Looks like you have entered your wrong email/password"; }*/
            } else
            {
                Response.Redirect("/");
            }


        }

        public int getNumOfUsers ()
        {
            numOfUsers = td.returnNoOfCustomers() + td.returnNoOfAdmins();
            return numOfUsers;
        }

        
    }
}