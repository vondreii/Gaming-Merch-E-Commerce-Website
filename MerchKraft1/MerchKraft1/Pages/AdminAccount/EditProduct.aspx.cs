/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - EditProduct.aspx.cs
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
    public partial class EditProduct : System.Web.UI.Page
    {
        public TestData sessionData = new TestData();
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
            td.setCurrentItemToDisplay(Int32.Parse(Session["product"].ToString()));
        }

        protected void update(String function, String newValue, String columnToChange, String type)
        {
            // determines which product to edit
            setProduct(function);

            // Finds the product ID.
            int prodID = Int32.Parse(td.getProduct("productID"));

            // User input and column to change is entered. updateProduct() will generate the correct query
            td.updateProduct(newValue, prodID, columnToChange, type);

            // Some labels will show that it s successfully added
            changesSavedMessage.Visible = true;
            goBack.Visible = true;
        }

        // When changing the description
        protected void btnChangeDescription_Click(object sender, EventArgs e)
        {
            Page.Validate();
            
            // All Products is the currentFunction (to determine the query and which product we are editing).
            // The rest of the arguments are the new name inputted, the column, and whether that column is a string/int
            // etc (for converting purposes).
            if (Page.IsValid) update("AllProducts", changeProductName.Text, "productDescription", "String");
        }

        // When changing the price
        protected void btnChangePrice_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // See above - calls a method that runs the update query to the DB
            if (Page.IsValid) update("AllProducts", changePrice.Text, "price", "double");
        }

        // When changing the audience
        protected void btnChangeAudience_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("AllProducts", audience.SelectedItem.Text, "audience", "String");
        }

        // When changing the colour
        protected void btnChangeColour_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("AllProducts", changeColour.Text, "colour", "String");
        }

        // When changing the print type
        protected void btnChangePrint_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("AllProducts", newPrintType.Text, "printType", "String");
        }

        // When changing the size
        protected void btnChangeSize_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("AllProducts", size.SelectedItem.Text, "size", "String");
        }

        // When changing the category
        protected void btnChangeCategory_Click(object sender, EventArgs e)
        {
            Page.Validate();

            // Calls a method that runs the update query to the DB
            if (Page.IsValid) update("Category", changeCategory.SelectedItem.Value, "categoryID", "int");
        }

        // When deleting the product
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                // determines which product to delete
                setProduct("AllProducts");

                // Finds the product ID.
                int prodID = Int32.Parse(td.getProduct("productID"));

                // Deletes the product, and goes back to the list of products
                td.deleteProduct(prodID);
                Response.Redirect("ManageItem");
            }
          
        }
    }
}