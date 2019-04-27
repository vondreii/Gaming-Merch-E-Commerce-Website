/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - TestData.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

// TESTDATA will act as a control class, to control which methods will be used from the different classes
// depending on the functionality or task the user is trying to accomplish.
// For A1 part 1, this was the class that was used to generate the fake data.

namespace MerchKraft1
{
    public class TestData
    {
        private String function, currentUser;
        private int current, currentProduct;

        // Declaring Objects
        private Admin admin = new Admin();
        private Customer customer = new Customer();
        private CustomerAccount customerAcc = new CustomerAccount();
        private Product product = new Product();
        private CartItem cartItem = new CartItem();
        DatabaseAccess db = new DatabaseAccess();

        public TestData()
        {
            function = ""; current = 0; currentUser = "";
        }

        // The current function determines what the user it currently trying to do, for example, displaying all
        // Accessory products, all Home Decor products, etc. 
        public void setCurrentFunction(String function) { this.function = function; }

        // Because the display loops through each product in the database and displays it, this method determines
        // which item the display is currently displaying. 
        public void setCurrentItemToDisplay(int current) { this.current = current; }

        // get and set for which current user to display for profiles.
        public void setCurrentUserToDisplay(String currentUser) { this.currentUser = currentUser; }
        public String getCurrentUserToDisplay() { return currentUser; }

        // Setter and getter for the current product that we are displaying/editing/deleting etc.
        public void setCurrentProduct(int currentProduct) { this.currentProduct = currentProduct; }
        public int getCurrentProduct() { return currentProduct; }

        // ********************************************************** //
        // ---------------- DISPLAYING USER ACCOUNTS ---------------- //
        // ********************************************************** //

        public String getUser(String attribute)
        {
            String query = "";
            // A different query is run depending on the functionality (or what data we are trying to retrieve). So, we have a
            // 'function' attribute that stores the current functionality, For example, displaying all products as opposed to displaying
            // all products in the clothing category.

            // Query to retrieve data from all Customers.
            if (function.Equals("Customers"))
                query = " FROM Customer";
            // Query to retrieve data from all Customers.
            else if (function.Equals("CustomerAccounts"))
                query = " FROM CustomerAccount JOIN Customer ON CustomerAccount.customerID=Customer.customerID";
            // Query to retrieve data from all Customer Logins.
            else if (function.Equals("CustomerLogins"))
                query = " FROM Login JOIN CustomerAccount ON Login.loginID = CustomerAccount.loginID";
            // Query to retrieve data from all Admins.
            else if (function.Equals("Admins"))
                query = " FROM Admin";
            // Query to retrieve data from all AdminAccounts.
            else if (function.Equals("AdminAccounts"))
                query = " FROM AdminAccount JOIN Admin ON Admin.adminAccountID = AdminAccount.adminAccountID";
            // Query to retrieve data from all AdminLogins.
            else if (function.Equals("AdminLogins"))
                query = " FROM AdminAccount JOIN Login ON Login.loginID = AdminAccount.loginID";
            // Query to retrieve data from all Logins.
            else if (function.Equals("Logins"))
                query = " FROM Login ORDER BY loginID";
            // Query to retrieve data from all MailingAddress.
            else if (function.Equals("MailingAddress"))
                query = " FROM MailingAddress JOIN CustomerAccount ON MailingAddress.addressID = CustomerAccount.addressID";

            // Retrieves an array list of all the values from the column we specified (attribute).
            // The attribute and the query is combined to make the SQL statement that is passed to the DAL. 
            if (customer.getColumnType().Equals("string"))
            {
                return customer.retrieveData("SELECT " + attribute + query, attribute)[current].ToString();
            }
            else
            {
                // "Login.loginID AS id" -- there is no column called Login.loginID. The column we are trying to get data from is loginID (because of ambigious column name)
                // so, we rename the columns to 'id' and try to find the 'id' column.
                if (attribute.Equals("Login.loginID AS id")) return Convert.ToString(customer.retrieveData("SELECT " + attribute + query, "id")[current].ToString());
                // All other columns just have an arraylist with all values for that column. [current] is similar to i - in the list, we find 
                // the record we want to display, and then return it. 
                else return Convert.ToString(customer.retrieveData("SELECT " + attribute + query, attribute)[current].ToString());
            }

        }

        // Counts the number of entries in the array and returns the number of customers 
        public int returnNoOfCustomers()
        {
            // Gets the customerIDs and stores it in the array. getNumOfItems returns the length
            ArrayList temp = customer.retrieveData("SELECT customerID FROM Customer", "customerID");
            return customer.getNumOfItems();
        }

        public int returnNoOfAdmins()
        {
            // Gets the adminIDs and stores it in the array. getNumOfItems returns the length
            ArrayList temp = admin.retrieveData("SELECT adminID FROM Admin", "adminID");
            return admin.getNumOfItems();
        }

        // ********************************************************** //
        // ------------------- DISPLAYING PRODUCTS ------------------ //
        // ********************************************************** //

        // Determines which query to run based on current function. These queries are passed through the entity classes
        // and then finally passed to the databaseAccess DL class that pulls the data from the DB.
        // This uses the product class (which subsequently uses the DatabaseAccess class to retrieve the data itself)
        // Similar to the method above - getUser()
        public String getProduct(String attribute)
        {
            String query = "";
            // Query to retrieve data from all AllProducts.
            if (function.Equals("AllProducts"))
                query = " FROM Product";
            // Query to retrieve data from all Accessories.
            else if (function.Equals("Accessories"))
                query = " FROM Product JOIN Category ON Product.categoryID = Category.categoryID WHERE Category.name = 'Accessories'";
            // Query to retrieve data from all Clothing.
            else if (function.Equals("Clothing"))
                query = " FROM Product JOIN Category ON Product.categoryID = Category.categoryID WHERE Category.name = 'Clothing'";
            // Query to retrieve data from all Home.
            else if (function.Equals("Home"))
                query = " FROM Product JOIN Category ON Product.categoryID = Category.categoryID WHERE Category.name = 'Home Decor'";
            // Query to retrieve data from all Technology.
            else if (function.Equals("Technology"))
                query = " FROM Product JOIN Category ON Product.categoryID = Category.categoryID WHERE Category.name = 'Technology'";
            // Query to retrieve data from all AllItems.
            else if (function.Equals("AllItems"))
                query = " FROM CartItem JOIN Product ON CartItem.productID=Product.productID";
            // Query to retrieve data from all Category.
            else if (function.Equals("Category"))
                query = " FROM Product JOIN Category ON Category.categoryID=Product.categoryID";

            // See comments in getUser(), this does the same thing.
            if (product.getColumnType().Equals("string"))
                return product.retrieveData("SELECT " + attribute + query, attribute)[current].ToString();
            else
                return Convert.ToString(product.retrieveData("SELECT " + attribute + query, attribute)[current].ToString());
        }

        // Counts the number of entries in the array and returns the number of products 
        public int returnNoOfProducts()
        {
            // Gets the customerIDs and stores it in the array. getNumOfItems returns the length
            //ArrayList IDs = product.retrieveProductIDs();
            String temp = getProduct("productID");
            return product.getNumOfItems();
        }

        // ********************************************************** //
        // ------------------ ADDING A NEW PRODUCT ------------------ //
        // ********************************************************** //

        public void addNewProduct(String name, double price, String audience, String colour, String printType, String size, int category)
        {
            // Creates a new temporary product object to store details that the user entered
            Product temp = new Product();

            // Uses the setters for the product to set the details
            temp.setProductName(name);
            temp.setPrice(price);
            temp.setAudience(audience);
            temp.setColour(colour);
            temp.setPrintType(printType);
            temp.setSize(size);
            temp.setCategoryID(category);

            // A default image will display (Because we have no functionality for the user to upload an image).
            if (category == 1) temp.setImage("Images/defaultClothing.png");
            else if (category == 2) temp.setImage("Images/defaultAccessory.png");
            else if (category == 3) temp.setImage("Images/defaultHome.jpg");
            else if (category == 4) temp.setImage("Images/defaultTech.jpg");

            // Calls a method in the Product class that will insert the details as a row in the Product Table in the DB
            temp.addProductToDB();
        }

        // ********************************************************** //
        // ------------- MANAGING SHOPPING CART ITEMS --------------- //
        // ********************************************************** //

        public void addToCart(int prodNum, int userID, int quantity)
        {
            cartItem.addCartItemToDB(prodNum, userID, quantity);
        }

        public String getCartItems(String attribute, int num)
        {
            //DatabaseAccess dbAccess = new DatabaseAccess();
            //cartItems = dbAccess.getNumOfItems();
            String query = "";
            if (function.Equals("AllItems"))
                query = " FROM CartItem JOIN Product ON CartItem.productID=Product.productID";
            else if (function.Equals("Cart"))
                query = " FROM CartItem";

            if (cartItem.getColumnType().Equals("string"))
                return cartItem.retrieveData("SELECT " + attribute + query, attribute)[num].ToString();
            else
                return Convert.ToString(cartItem.retrieveData("SELECT " + attribute + query, attribute)[num].ToString());
        }

        public int getNumOfCartItems()
        {
            // Gets the customerIDs and stores it in the array. getNumOfItems returns the length
            //ArrayList IDs = product.retrieveProductIDs();
            //String temp = getCartItems("productDescription");
            ArrayList temp = cartItem.retrieveData("SELECT cartItemID FROM CartItem", "cartItemID");
            return cartItem.getNumOfItems();
        }

        public int getTotalUsers()
        {
            // Gets the customerIDs and stores it in the array. getNumOfItems returns the length
            ArrayList temp = customer.retrieveData("SELECT loginID FROM Login", "loginID");
            return customer.getNumOfItems();
        }

        public void changeQuantity(int q, int id)
        {
            cartItem.changeQuantity(q, id);
        }

        // ********************************************************** //
        // -------------- ADD NEW ADMIN/ADMIN ACCOUNT --------------- //
        // ********************************************************** //

        // In order to add a new admin, a new record for the Admin, AdminAccount and Login tables need to be added. 
        public void addNewAdmin(String firstName, String lastName, DateTime dob, String role,
            String confirmEmail, String username, String pwd)
        {
            // Makes a new Login object based on username and pwd entered by user.
            Login tempLogin = new Login(0, username, pwd);

            // Inserts the new login record into the DB. 
            tempLogin.insertNewLogin();

            // finds the record that was JUST added now. lastLoginID is the most recent login record in the DB.
            // It will be used as a foreign key to insert a new Admin Account. 
            int lastLoginID = findLastRecord("Login");

            // Makes a new Admin Account object with the details entered by the user.
            AdminAccount tempAccount = new AdminAccount(DateTime.Today, DateTime.Today, role);

            // A new record is inserted, and again, the most recent record is retrieved to be used as a FK in Admin. 
            tempAccount.insertNewAdminAccount(lastLoginID);
            int lastAdminAccountID = findLastRecord("AdminAccount");

            // Adds a new Admin record in the Admin table.
            Admin tempAdmin = new Admin(firstName, lastName, dob, confirmEmail);
            tempAdmin.insertNewAdmin(lastAdminAccountID);
        }

        // ********************************************************** //
        // ----------- ADD NEW CUSTOMER/CUSTOMER ACCOUNT ------------ //
        // ********************************************************** //

        // To add a new Customer, new records in the Customer, MailingAddress, CustomerAccount, ShoppingCart and Login has to be inserted.
        public void addNewCustomer(String firstName, String lastName, DateTime dob, String unit, String street, String suburb,
            String city, String state, String postcode, String username, String pwd)
        {
            // Makes a new Login object based on username and pwd entered by user.
            Login tempLogin = new Login(0, username, pwd);

            // A new record is inserted, and again, the most recent record is retrieved to be used as a FK in CustomerAccount. 
            tempLogin.insertNewLogin();
            int lastLoginID = findLastRecord("Login");

            // Makes a new Customer object based on details. 
            Customer tempCustomer = new Customer(firstName, lastName, dob);

            // New record inserted. ID of the record is retrieved for the FK in CustomerAccount
            tempCustomer.addNewCustomer();
            int lastCustomerID = findLastRecord("Customer");

            // Makes a new Shopping Cart object based on details. 
            ShoppingCart tempCart = new ShoppingCart();

            // New record inserted. ID of the record is retrieved for the FK in ShoppinCart
            tempCart.addNewShoppingCart();
            int lastShoppingCartID = findLastRecord("ShoppingCart");

            // Makes a new Mailing Address object based on details. 
            MailingAddress tempAddress = new MailingAddress(unit, street, suburb, city, state, "Australia", postcode);

            // New record inserted. ID of the record is retrieved for the FK in ShoppinCart
            tempAddress.addNewAddress();
            int lastAddressID = findLastRecord("MailingAddress");

            // Makes a new Customer Account object based on details. 
            CustomerAccount tempAccount = new CustomerAccount();
            tempAccount.addNewCustomerAccount(lastAddressID, lastCustomerID, lastShoppingCartID, lastLoginID);

        }

        // ********************************************************** //
        // ----------- FINDS MOST RECENTLY ADDED RECORD ------------- //
        // ********************************************************** //   

        public int findLastRecord(String table)
        {
            // Finds the last recorded (what was the most recent record inserted).
            ArrayList temp = new ArrayList();
            // Most recent recorded inserted in Login.
            if (table.Equals("Login"))
                temp = customer.retrieveData("SELECT loginID FROM Login ORDER BY loginID", "loginID");
            // Most recent recorded inserted in AdminAccount.
            if (table.Equals("AdminAccount"))
                temp = customer.retrieveData("SELECT adminAccountID FROM AdminAccount ORDER BY adminAccountID", "adminAccountID");
            // Most recent recorded inserted in Customer.
            if (table.Equals("Customer"))
                temp = customer.retrieveData("SELECT customerID FROM Customer ORDER BY customerID", "customerID");
            // Most recent recorded inserted in ShoppingCart.
            if (table.Equals("ShoppingCart"))
                temp = customer.retrieveData("SELECT shoppingCartID FROM ShoppingCart ORDER BY shoppingCartID", "shoppingCartID");
            // Most recent recorded inserted in MailingAddress.
            if (table.Equals("MailingAddress"))
                temp = customer.retrieveData("SELECT addressID FROM MailingAddress ORDER BY addressID", "addressID");


            return Int32.Parse(temp[customer.getNumOfItems() - 1].ToString());
        }

        // loop through all logins, check if SessionName matches the username in LOGIN TABLE 
        // if that index does match, then set the loginID to that name found
        // --------------------- checks to make sure user is admin or not --------------------------
        public String getLoginID(String sessionName)
        {
            setCurrentFunction("Logins");
            String loginID = "";
            for (int i = 0; i < getTotalUsers(); i++)
            {
                setCurrentItemToDisplay(i);
                if (sessionName == getUser("username").Trim()) loginID = getUser("loginID").Trim();
            }
            return loginID;
        }

        public String getAdminName(String loginID)
        {
            setCurrentFunction("AdminLogins");
            int id = 0;
            for (int j = 0; j < returnNoOfAdmins(); j++)
            {
                setCurrentItemToDisplay(j);
                if (loginID == getUser("Login.loginID AS id").Trim()) id = j;
            }
            setCurrentItemToDisplay(id);

            return getUser("username").Trim();
        }

        // ********************************************************** //
        // -------------- EDITING/DELETING A PRODUCT ---------------- //
        // ********************************************************** //

        public void updateProduct(String newName, int prodID, String column, String type)
        {
            // Updates with product based on what column and the new value
            String query = "";
            if (type.Equals("double"))
                // A different query for getting data from the Customer table.
                query = "UPDATE Product SET " + column + "=" + Double.Parse(newName) + " WHERE productID=" + prodID;
            if (type.Equals("int"))
                // If the new value is an int, it has to be converted.
                query = "UPDATE Product SET " + column + "=" + Int32.Parse(newName) + " WHERE productID=" + prodID;
            else
                // Otherwaise, the string is used
                query = "UPDATE Product SET " + column + "='" + newName + "' WHERE productID=" + prodID;

            // Runs the query in the DAL DatabaseAccess Class
            db.update(query);
        }

        public void deleteProduct(int prodID)
        {
            // Cannot delete a product without first deleting that product from the PurchasedItem & Cart Item Tables.
            db.update("DELETE FROM PurchasedItem WHERE productID = " + prodID);
            db.update("DELETE FROM CartItem WHERE productID = " + prodID);

            // After those records are deleted, the Product can be deleted (no FK error).
            db.update("DELETE FROM Product WHERE productID = " + prodID);
        }

        // ********************************************************** //
        // ------------- EDITING USER DETAILS (ADMIN) --------------- //
        // ********************************************************** //

        public void updateUser(String newName, int id, String column, String type, String table)
        {
            // Updates with product based on what column and the new value
            String query = "";
            if (table.Equals("Customer"))
                // A different query for getting data from the Customer table.
                query = "UPDATE " + table + " SET " + column + "='" + newName + "' WHERE customerID=" + id;
            if (table.Equals("MailingAddress"))
                // A different query for getting data from the Address table.
                query = "UPDATE " + table + " SET " + column + "='" + newName + "' WHERE addressID = (SELECT addressID FROM customerAccount WHERE customerID =" + id + ")";
            if (table.Equals("Login"))
                // A different query for getting data from the Login table.
                query = "UPDATE " + table + " SET " + column + "='" + newName + "' WHERE loginID = (SELECT loginID FROM customerAccount WHERE customerID =" + id + ")";
            if (table.Equals("Admin"))
                // A different query for getting data from the Admin table.
                query = "UPDATE " + table + " SET " + column + "='" + newName + "' WHERE adminID=" + id;

            // Runs the query in the DAL DatabaseAccess Class
            db.update(query);
        }

        // ********************************************************** //
        // --------------- CUSTOMER % ADMIN PROFILES ---------------- //
        // ********************************************************** //

        public String getCustomerProfiles(String attribute)
        {
            String query = "";
            // A different query for getting data from the Customer table.
            if (function.Equals("CustomerProfile_Customer"))
                query = " FROM Customer where customerID = (SELECT customerID FROM CustomerAccount WHERE loginID = (SELECT loginID FROM Login WHERE username = '" + getCurrentUserToDisplay() + "'))";
            // A different query for getting data from the CustomerAccount table.
            else if (function.Equals("CustomerProfile_CustomerAccount"))
                query = " FROM CustomerAccount WHERE loginID = (SELECT loginID FROM Login WHERE username = '" + getCurrentUserToDisplay() + "')";
            // A different query for getting data from the Login table.
            else if (function.Equals("CustomerProfile_Login"))
                query = " FROM Login WHERE username='" + getCurrentUserToDisplay() + "'";
            // A different query for getting data from the Mailing table.
            else if (function.Equals("CustomerProfile_Mailing"))
                query = " FROM MailingAddress WHERE addressID = (SELECT addressID FROM CustomerAccount WHERE loginID = (SELECT loginID FROM Login WHERE username = '" + getCurrentUserToDisplay() + "'))";
            // A different query for Tech.
            else if (function.Equals("Technology"))
                query = " FROM Product JOIN Category ON Product.categoryID = Category.categoryID WHERE Category.name = 'Technology'";
            // A different query for All Items.
            else if (function.Equals("AllItems"))
                query = " FROM CartItem JOIN Product ON CartItem.productID=Product.productID";
            // A different query for Category.
            else if (function.Equals("Category"))
                query = " FROM Product JOIN Category ON Category.categoryID=Product.categoryID";

            if (product.getColumnType().Equals("string"))
                return product.retrieveData("SELECT " + attribute + query, attribute)[0].ToString();
            else
                return Convert.ToString(product.retrieveData("SELECT " + attribute + query, attribute)[0].ToString());
            // retrieves the array from the DB of all the values in that column (and finds the record that was are wanting to display).
        }

        public String getAdminProfiles(String attribute)
        {
            String query = "";
            if (function.Equals("AdminProfile_Admin"))
                query = " FROM Admin WHERE adminAccountID = (SELECT adminAccountID FROM AdminAccount WHERE loginID = (SELECT loginID FROM Login WHERE username = '" + getCurrentUserToDisplay() + "'))";
            else if (function.Equals("AdminProfile_AdminAccount"))
                query = " FROM AdminAccount WHERE loginID = (SELECT loginID FROM Login WHERE username = '"+ getCurrentUserToDisplay()+ "')";
            else if (function.Equals("AdminProfile_Login"))
                query = " FROM Login WHERE username = '"+ getCurrentUserToDisplay()+ "'";

            if (product.getColumnType().Equals("string"))
                return product.retrieveData("SELECT " + attribute + query, attribute)[0].ToString();
            else
                return Convert.ToString(product.retrieveData("SELECT " + attribute + query, attribute)[0].ToString());
        }

        public int findWhichCustomer(String username)
        {
            ArrayList allUsernames = product.retrieveData("SELECT username FROM Login ORDER BY loginID", "username");
            int indexFound = 0;
            for (int i = 0; i < product.getNumOfItems(); i++)
            {
                if (username.Equals(allUsernames[i].ToString().Trim()))
                    indexFound = i;
            }
            return indexFound;
        }

        // ********************************************************** //
        // -------------------- PURCHASED ITEMS --------------------- //
        // ********************************************************** //

        // Purchase History
        public String getPurchasedItem(String attribute)
        {
            String query = "";
            if (function.Equals("receipt"))
                query = " FROM PurchasedItem WHERE customerAccountID IN (SELECT customerAccountID FROM CustomerAccount WHERE loginID = (SELECT loginID FROM Login WHERE username = '"+getCurrentUserToDisplay()+"')) ORDER BY productID";
            else if (function.Equals("PurchasedItem"))
                query = " FROM Product WHERE productID IN (SELECT productID FROM purchasedItem WHERE customerAccountID = (SELECT customerAccountID FROM CustomerAccount WHERE loginID = (SELECT loginID FROM Login WHERE username = '"+ getCurrentUserToDisplay()+ "')))";

            if (product.getColumnType().Equals("string"))
                return product.retrieveData("SELECT " + attribute + query, attribute)[current].ToString();
            else
                return Convert.ToString(product.retrieveData("SELECT " + attribute + query, attribute)[current].ToString());
        }

        // Purchase History
        public int getNoOfPurchasedItems()
        {
            // Gets the customerIDs and stores it in the array. getNumOfItems returns the length
            ArrayList temp = product.retrieveData("SELECT purchasedItemID FROM PurchasedItem where customerAccountID = (SELECT customerAccountID FROM CustomerAccount WHERE loginID = (SELECT loginID FROM Login WHERE username = '"+ getCurrentUserToDisplay()+ "'))", "purchasedItemID");
            return product.getNumOfItems();
        }

    }
}
