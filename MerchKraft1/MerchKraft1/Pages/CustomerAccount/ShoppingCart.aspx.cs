/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - ShoppingCart.aspx.cs
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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected TestData td = new TestData();
        private int prodNum = 0;
        protected void Page_Load(object sender, EventArgs e)
        {    // admin will not be able to see this but users and customers can
            if (Session["Name"] == null) Response.Redirect("../Login/Login");
            else {

                // ------------------ ALLOWS TO VIEW SHOPPING CART OF SPECIFIC USER ------------------

                // get username from session
                // look for user name in CartItem table?
                // whatever matches the user name, will be the items displayed.
                td.setCurrentFunction("Logins"); // to get LoginID (1000, 1001, etc.)
                String userID = ""; 
                for (int i = 0; i < td.getTotalUsers(); i++) // loops through all users
                {
                    td.setCurrentItemToDisplay(i);
                    // if the username in the session == username from the table, store that loginID in userID
                    if (Session["Name"].ToString() == td.getUser("username")) userID = td.getUser("loginID");
                }

                td.setCurrentFunction("Cart"); // finds the shoppingCartID based on userID (since userID==shoppingCartID)
                /*coItemHead.Controls.Add(new LiteralControl("<table><tr> <th> Product Name </th><th> Size </th>" +
                            "<th> quantity </th><th> Image </th><th> Price </th></tr></table>"));*/
                int quantityItem = 0;
                for (int j = 0; j < td.getNumOfCartItems(); j++)
                {
                    if (userID == td.getCartItems("shoppingCartID", j)) // if userID == shoppingCartID
                    { // only display those items with that shoppingCartID (userID)
                        quantityItem = Int32.Parse(td.getCartItems("quantity", j));
                        td.setCurrentFunction("AllItems");
                        //Label1.Text += td.getCartItems("productDescription", j) + "|";
                        //GridView1.SelectRow = td.getCartItems("productDescription", j);
                        //coItemPanel.Controls.Add(new LiteralControl("<div class='coItem'>" + td.getCartItems("productDescription", j) + "</div>"));

                        /*coItemPanel.Controls.Add(new LiteralControl("<table><tr>" + 
                            "<td>" + td.getCartItems("productDescription", j) + "</td>" +
                            "<td>" + td.getCartItems("size", j) + "</td>" +
                            "<td>" + quantityItem + "</td>" +
                            "<td><img src='../../Images/" + td.getCartItems("productImageName", j) + "'/></td>" +
                            "<td>" + td.getCartItems("price", j) + "</td>" +
                            "</tr></table>"));*/
                        coItemPanel.Controls.Add(new LiteralControl("<div class='coItem'>" +
                            "<img src='../../" + td.getCartItems("productImageName", j) + "'/>" +
                            td.getCartItems("productDescription", j) +
                            "<div class ='coItemQuantity'>" + quantityItem + "</div>" +
                            "<div class ='coItemPrice'>$" + (Int32.Parse(td.getCartItems("price", j)) * quantityItem) + "</div>" +
                            "</div>"));



                    }
                    else Label1.Text = "Shopping Cart empty"; // if user has no items in their shopping cart

                    td.setCurrentFunction("Cart"); // returns back to ID to check the item under that shoppingCartID
                }
                //Label1.Text = "( userID: " + userID + ", cartID: " + td.getCartItems("shoppingCartID", 0) + ")";

                // ------------------ **END** ALLOWS TO VIEW SHOPPING CART OF SPECIFIC USER ------------------
                // ------------------ ----------------------------------------------------- ------------------

                
                
            }

        }

        public int getProductNum()
        {
            return prodNum;
        }
    }
}