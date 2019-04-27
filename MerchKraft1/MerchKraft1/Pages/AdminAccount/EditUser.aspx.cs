/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - EditUser.aspx.cs
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
    public partial class EditUser : System.Web.UI.Page
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

        private void setProduct(String function)
        {
            // Sets the current function, which will change the query. "AllProducts" gets an array of all records
            // for all products. "Category" finds the category of the product we are looking at.
            td.setCurrentFunction(function);

            // The current item to display is 'i' in the ManageItem.aspx (where the list of items are).
            // Determines which item to edit.
            td.setCurrentItemToDisplay(Int32.Parse(Session["customer"].ToString()));
        }

        protected void update(String function, String newValue, String columnToChange, String type, String table)
        {
            // determines which product to edit
            setProduct(function);

            // Finds the product ID.
            int customerID = Int32.Parse(td.getUser("customerID").ToString());

            // User input and column to change is entered. updateProduct() will generate the correct query
            td.updateUser(newValue, customerID, columnToChange, type, table);

            // Some labels will show that it s successfully added
            changesSavedMessage.Visible = true;
            goBack.Visible = true;
        }

        // When changing the first name
        protected void btnChangeFirst_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Customers is the currentFunction (to determine the query and which product we are editing).
            // The rest of the arguments are the new name inputted, the column, and whether that column is a string/int
            // etc (for converting purposes) and the table (Customer, Mailing Address, etc).
            if (Page.IsValid) update("Customers", changeFirstName.Text, "firstName", "String", "Customer");
        }

        // When changing the last name
        protected void btnChangeLast_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // See above - calls a method that runs the update query to the DB
            if (Page.IsValid) update("Customers", changeLastName.Text, "lastName", "String", "Customer");
        }

        // When changing the email
        protected void btnChangeEmail_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("Customers", changeEmail.Text, "emailAddress", "String", "Customer");
        }

        // When changing the unit
        protected void btnChangeUnit_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("MailingAddress", changeUnit.Text, "unit", "String", "MailingAddress");
        }

        // When changing the street
        protected void btnChangeStreet_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("MailingAddress", changeStreet.Text, "street", "String", "MailingAddress");
        }

        // When changing the suburb
        protected void btnChangeSuburb_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("MailingAddress", changeSuburb.Text, "suburb", "String", "MailingAddress");
        }

        // When changing the city
        protected void btnChangeCity_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("MailingAddress", changeCity.Text, "city", "String", "MailingAddress");
        }

        // When changing the state
        protected void btnChangeState_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("MailingAddress", state.SelectedItem.Text, "state", "String", "MailingAddress");
        }

        // When changing the username
        protected void btnChangeUsername_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("CustomerLogins", changeLoginUsername.Text, "username", "String", "Login");
        }

        // When changing the password
        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("CustomerLogins", changePwd.Text, "password", "String", "Login");
        }

        
    }
}