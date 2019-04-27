/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - Product.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchKraft1
{
    public class Product
    {
        private int productID, categoryID, shoppingCartID;
        private double price;
        private String productName, image, productDescription, audience, colour, printType, size;
        private DatabaseAccess dbAccess = new DatabaseAccess();

        public Product()
        {
            productID = 0;
            productName = "";
            image = "";
            size = "";
            categoryID = 0;
            shoppingCartID = 0;
            price = 0;
            productDescription = "";
            audience = "";
            colour = "";
            printType = "";
        }

        public Product(int productID, String image, String size, int categoryID, int shoppingCartID, double price,
            String productName, String productDescription, String audience, String colour, String printType)
        {
            this.productID = productID;
            this.image = image;
            this.size = size;
            this.categoryID = categoryID;
            this.shoppingCartID = shoppingCartID;
            this.price = price;
            this.productName = productName;
            this.productDescription = productDescription;
            this.audience = audience;
            this.colour = colour;
            this.printType = printType;
        }

        // Get & Set for productID
        public void setProductID(int productID) { this.productID = productID; }
        public int getProductID() { return productID; }

        // Get & Set for image
        public void setImage(String image) { this.image = image; }
        public String getImage() { return image; }

        // Get & Set for size
        public void setSize(String size) { this.size = size; }
        public String getSize() { return size; }

        // Get & Set for categoryID
        public void setCategoryID(int categoryID) { this.categoryID = categoryID; }
        public int getCategoryID() { return categoryID; }

        // Get & Set for shoppingCartID
        public void setShoppingCartID(int shoppingCartID) { this.shoppingCartID = shoppingCartID; }
        public int getShoppingCartID() { return shoppingCartID; }

        // Get & Set for price
        public void setPrice(double price) { this.price = price; }
        public double getPrice() { return price; }

        // Get & Set for productName
        public void setProductName(String productName) { this.productName = productName; }
        public String getProductName() { return productName; }

        // Get & Set for productDescription
        public void setProductDescription(String productDescription) { this.productDescription = productDescription; }
        public String getProductDescription() { return productDescription; }

        // Get & Set for audience
        public void setAudience(String audience) { this.audience = audience; }
        public String getAudience() { return audience; }

        // Get & Set for colour
        public void setColour(String colour) { this.colour = colour; }
        public String getColour() { return colour; }

        // Get & Set for printType
        public void setPrintType(String printType) { this.printType = printType; }
        public String getPrintType() { return printType; }

        // Gets the number of items that was in the last array created (of items from the DB)
        public int getNumOfItems() {
            return dbAccess.getNumOfItems(); }

        // Gets the number of items that was in the last array created (of items from the DB)
        public String getColumnType() {
            return dbAccess.getColumnType(); }

        // Gets all the productIDs of all products stored in the DB
        public ArrayList retrieveData(String query, String attribute) {
            return dbAccess.selectData(query, attribute); }

        // Adds the product to the DB
        public void addProductToDB()
        {
            // Automatically the shopping cart ID is 0 because when a product is added, it has not been selected yet
            // This uses the DB connection to insert this record (with these details) into the DB
            dbAccess.insertProductData(productName, image, price, audience, colour, printType, size, categoryID, 0);
        }
    }
}
