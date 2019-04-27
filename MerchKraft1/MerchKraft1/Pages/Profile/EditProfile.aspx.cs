using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerchKraft1.Pages
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected TestData td = new TestData();
        protected void Page_Load(object sender, EventArgs e)
        {
            Object seshName = Session["Name"]; // stores session name object
            string pageName = System.IO.Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath); // gets the page name
            if (seshName != null) // user has logged in 
            {
                String sessionName = seshName.ToString();
                td.setCurrentUserToDisplay(sessionName);
            }
        }

        private void setUser(String function)
        {
            // Sets the current function, which will change the query. "AllProducts" gets an array of all records
            // for all products. "Category" finds the category of the product we are looking at.
            td.setCurrentFunction(function);

            // The current item to display is 'i' in the ManageItem.aspx (where the list of items are).
            // Determines which item to edit.
            String seshName = Session["Name"].ToString(); // stores session name object
            
            td.setCurrentItemToDisplay(td.findWhichCustomer(seshName));
        }

        protected void update(String function, String newValue, String columnToChange, String type, String table)
        {
            // determines which product to edit
            setUser(function);

            // Finds the customer ID.
            int customerID = Int32.Parse(td.getUser("customerID").ToString());

            // User input and column to change is entered. updateProduct() will generate the correct query
            td.updateUser(newValue, customerID, columnToChange, type, table);

            // Some labels will show that it s successfully added
            changesSavedMessage.Visible = true;
            goBack.Visible = true;

            /* **** EVERYTHING WORKS EXCEPT USERNAME - USE THE SESSION HANDLER PAGE ********** */
        }

        // ********************************************************** //
        // ----------------- EDIT CUSTOMER PROFILES ----------------- //
        // ********************************************************** //
        
        protected void btnChangeFirst_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Customers is the currentFunction (to determine the query and which product we are editing).
            // The rest of the arguments are the new name inputted, the column, and whether that column is a string/int
            // etc (for converting purposes) and the table (Customer, Mailing Address, etc).
            if (Page.IsValid) update("Customers", changeFirstName.Text, "firstName", "String", "Customer");
        }

        protected void btnChangeLast_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // See above - calls a method that runs the update query to the DB
            if (Page.IsValid) update("Customers", changeLastName.Text, "lastName", "String", "Customer");
        }

        protected void btnChangeEmail_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("Customers", changeEmail.Text, "emailAddress", "String", "Customer");
        }

        protected void btnChangeUnit_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("MailingAddress", changeUnit.Text, "unit", "String", "MailingAddress");
        }

        protected void btnChangeStreet_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("MailingAddress", changeStreet.Text, "street", "String", "MailingAddress");
        }

        protected void btnChangeSuburb_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("MailingAddress", changeSuburb.Text, "suburb", "String", "MailingAddress");
        }

        protected void btnChangeCity_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("MailingAddress", changeCity.Text, "city", "String", "MailingAddress");
        }

        protected void btnChangeState_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("MailingAddress", state.SelectedItem.Text, "state", "String", "MailingAddress");
        }

        protected void btnChangeUsername_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("CustomerLogins", changeLoginUsername.Text, "username", "String", "Login");
        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("CustomerLogins", changePwd.Text, "password", "String", "Login");
        }

        
    }
}