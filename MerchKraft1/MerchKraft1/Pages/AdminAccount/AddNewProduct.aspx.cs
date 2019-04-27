/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - AddNewProduct.aspx.cs
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
    public partial class AddNewProduct : System.Web.UI.Page
    {
        private TestData td = new TestData();

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

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                td.addNewProduct(productName.Text, Double.Parse(price.Text), audience.SelectedItem.Text, colour.Text, printType.Text, size.SelectedItem.Text, Int32.Parse(category.Text));
                Response.Redirect("SuccessfullyAdded.aspx");
            }
        }
    }
}