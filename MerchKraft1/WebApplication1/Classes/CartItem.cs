using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchKraft1
{
    public class CartItem
    {
        private int cartItemID, productID, shoppingCartID, quantity;
        private DatabaseAccess dbAccess = new DatabaseAccess();

        public CartItem ()
        {
            this.cartItemID = 0;
            this.productID = 0;
            this.shoppingCartID = 0;
            this.quantity = 0;
        }

        public CartItem(int cartItemID, int productID, int shoppingCartID, int quantity)
        {
            this.cartItemID = cartItemID;
            this.productID = productID;
            this.shoppingCartID = shoppingCartID;
            this.quantity = quantity;
        }

        public int CartItemID { get => cartItemID; set => cartItemID = value; }
        public int ProductID { get => productID; set => productID = value; }
        public int ShoppingCartID { get => shoppingCartID; set => shoppingCartID = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        // Gets the number of items that was in the last array created (of items from the DB)
        public int getNumOfItems()
        {
            return dbAccess.getNumOfItems();
        }

        // Gets the number of items that was in the last array created (of items from the DB)
        public String getColumnType()
        {
            return dbAccess.getColumnType();
        }

        // Gets all the productIDs of all products stored in the DB
        public ArrayList retrieveData(String query, String attribute)
        {
            return dbAccess.selectData(query, attribute);
        }

        public void changeQuantity (int q, int id)
        {
            dbAccess.changeQuantity(q, id);
        }
        // Adds the product to the DB
        public void addCartItemToDB(int productID, int userID, int quantity)
        {
            // Automatically the shopping cart ID is 0 because when a product is added, it has not been selected yet
            // This uses the DB connection to insert this record (with these details) into the DB
            dbAccess.insertCartItemData(productID, userID, quantity);
        }
    }
}