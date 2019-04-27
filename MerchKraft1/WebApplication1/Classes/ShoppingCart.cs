/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - ShoppingCart.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchKraft1
{
    public class ShoppingCart
    {
        // private variables storing details about a ShoppingCart
        private int shoppingCartID, numberOfItems, discountID, paymentID;
        private double shippingCost, totalPrice;
        private DatabaseAccess dbAccess = new DatabaseAccess();

        // Default Constructor for Shopping Cart, if no info is known about the object
        public ShoppingCart ()
        {
            shoppingCartID = 0; numberOfItems = 0; discountID = 0;
            paymentID = 0; shippingCost = 0; totalPrice = 0;
        }

        // Constructor for Shopping Cart, when details are already known
        public ShoppingCart (int shoppingCartID, int numberOfItems, int discountID, int paymentID,
            double shippingCost, double totalPrice)
        {
            this.shoppingCartID = shoppingCartID; this.numberOfItems = numberOfItems;
            this.discountID = discountID; this.paymentID = paymentID;
            this.shippingCost = shippingCost; this.totalPrice = totalPrice;
        }

        // Getters for all Shopping Cart instance variables
        public void setShoppingCartID (int shoppingCartID) { this.shoppingCartID = shoppingCartID; }
        public void setNumberOfItems(int numberOfItems) { this.numberOfItems = numberOfItems; }
        public void setDiscountCode (int discountID) { this.discountID = discountID; }
        public void setPaymentID (int paymentID) { this.paymentID = paymentID; }
        public void setShippingCost (double shippingCost) { this.shippingCost = shippingCost; }
        public void setTotalPrice (double totalPrice) { this.totalPrice = totalPrice; }

        // Setters for all Shopping Cart instance variables
        public int getShoppingCartID () { return shoppingCartID; }
        public int getNumberOfItems () { return numberOfItems; }
        public int getDiscountCode () { return discountID; }
        public int getPaymentID () { return paymentID; }
        public double getShippingCost () { return shippingCost; }
        public double getTotalCost () { return totalPrice; }

        // inserts new customer account record
        public void addNewShoppingCart() {
            dbAccess.insertShoppingCart();  }
    }
}