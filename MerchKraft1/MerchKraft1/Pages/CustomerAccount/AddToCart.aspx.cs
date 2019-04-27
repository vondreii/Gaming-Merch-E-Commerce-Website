using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerchKraft1.Pages.CustomerAccount
{
    public partial class AddToCart : System.Web.UI.Page
    {

        private TestData td = new TestData();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Name"] == null) // user/admin has not logged in
            {
                Response.Redirect("~/Pages/Login/Login");
            }
            else
            {
                
                String s = Request.QueryString["prod"]; // target page
                Session["prod"] = s; // source page
                

                // ---------------------------- ADD PRODUCT TO CART, BY PRODUCT ID ---------------------------

                if (Session["prod"] != null) // if a product has been selected to add to cart
                {
                    // keep track of user logged in (shoppingCartID)
                    // if userName matches shoppingCartID
                    // check if productID (prodNum in session) is there
                    // if it is, increment quantity
                    // if not, quantity = 1
                    String prod = (String)(Session["prod"]); // "string" number of product
                    
                    int prodNum = Int16.Parse(prod); // converts the - "string" number of product - to "int"

                    String userID = "";
                    td.setCurrentFunction("Logins");
                    for (int i = 0; i < td.getTotalUsers(); i++) // loops through all users
                    {
                        td.setCurrentItemToDisplay(i);
                        // if the username in the session == username from the table, store that loginID in userID
                        if (Session["Name"].ToString() == td.getUser("username")) userID = td.getUser("loginID");
                    }
                    
                    
                    // loop through all cart items
                    // if productID (prodNum in session) == productID (in table) &&  userID logged in == (shoppingCartID) 
                    // -- that product already exists in that user's shopping cart so increment quantity
                    // else , and new item and start at 1

                    int quantityItem = 0;

                    td.setCurrentFunction("Cart");
                    
                    int userCount = 0; // this counts the number of times the user logged in is found in CartItem
                    for (int m = 0; m < td.getNumOfCartItems(); m++) 
                        if (userID == td.getCartItems("shoppingCartID", m)) userCount++;

                    int countCheck = 0; // keeps track of number of times it does not find the product user has selecteds
                    for (int n = 0; n < td.getNumOfCartItems(); n++)
                    {
                        if ((userID == td.getCartItems("shoppingCartID", n)) && (prodNum != Int16.Parse(td.getCartItems("productID", n))))
                        { // increments every time it does not find the item in the user's cart
                            countCheck++; // if countCheck == userCount, then all items of user has been checked
                            // and the item was never in their shopping cart
                            if (countCheck == userCount) { td.addToCart(prodNum, Int32.Parse(userID), 1); break; } // so add new item
                        }

                        else if ((userID == td.getCartItems("shoppingCartID", n)) && (prodNum == Int16.Parse(td.getCartItems("productID", n))))
                        {
                            quantityItem = Int32.Parse(td.getCartItems("quantity", n)) + 1;
                            td.changeQuantity(quantityItem, n); // UPDATE CartItem SET quantity = quantityItem WHERE cartItemID = i+1 
                        }
                    }
                    

                }


                Response.Redirect("ShoppingCart");
            }

            
            
        }

        
    }
}