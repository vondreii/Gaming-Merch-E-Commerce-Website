using System;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace MerchKraft1
{
    public class DatabaseAccess
    {
        // connection variable for connecting to the SQL Database
        public String connection;
        SqlConnection sqlconn = new SqlConnection();
        int numOfItems;
        String columnType;

        // Default constructor for CustomerAccountDL
        public DatabaseAccess()
        {
            // The connection connects to the SQL Database Server on Sharlene's laptop 
            // It is called INFT3050_Merchkraft_DB
            connection = System.Configuration.ConfigurationManager.ConnectionStrings["Merchkraft1_DBConnectionString"].ConnectionString;

            //"Data Source=LAPTOP-55E0CCU5\\SQLEXPRESS;Initial Catalog=INFT3050_Merchkraft_DB;Persist Security Info=True;User ID=sa;Password=Leo_mia*1234";
            sqlconn.ConnectionString = connection;

            numOfItems = 0;
            columnType = "";
        }

        /* Selects the data from the database and saves it in an array. 
           Parameters: 
           query - For example, "SELECT customerAccountID FROM CustomerAccount." 
           column - This will select all data for that field for that column in the DB. For example, "customerAccountID"
           All the values from the select statement for the column are saved into an array and returned
        */
        public ArrayList selectData(String query, String column)
        {
            // The array to store the values from the DB
            ArrayList attributes = new ArrayList();

            String[] dateColumns = {"joinDate", "dateOfBirth", "lastAccessed", "changeLog", "datePurchased" };
            String[] stringColumns = {"firstName", "lastName", "emailAddress", "username", "password", "companyRole", "name",
                                      "productDescription", "productImageName", "audience", "printType", "colour", "size", "unit", "street",
                                      "suburb", "city", "state", "country", "postcode", "receiptNumber"};
            String[] doubleColumns = {"price"};
            String[] intColumns = {"customerID", "customerAccountID", "numOfPurchases", "id", "loginID", "adminID", "adminAccountID",
                                   "productID","cartItemID", "quantity", "shoppingCartID", "addressID", "purchasedItemID"};

            numOfItems = 0;

            // Will open the connection to the DB
            if (ConnectionState.Closed == sqlconn.State)
                sqlconn.Open();

            // sql command obj made with the sql query passed into the method and the connection
            SqlCommand cmd = new SqlCommand(query, sqlconn);

            try
            {
                // Will execute the query
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    for (int i = 0; i < stringColumns.Length; i++)
                    {
                        // These columns store String values in the DB
                        if (column.Equals(stringColumns[i]))
                        {
                            // If the column holds String values, then convert it to a String and store it in the array
                            attributes.Add(rd[column].ToString());
                            numOfItems++;
                            columnType = "string";
                        }
                    }
                    for (int i = 0; i < intColumns.Length; i++)
                    {
                        // These columns store String values in the DB
                        if (column.Equals(intColumns[i]))
                        {
                            // If the column holds int values, then convert it to an int and store it in the array
                            attributes.Add(Int32.Parse(rd[column].ToString()));
                            numOfItems++;
                            columnType = "integer";
                        }
                    }
                    for (int i = 0; i < doubleColumns.Length; i++)
                    {
                        // These columns store String values in the DB
                        if (column.Equals(doubleColumns[i]))
                        {
                            // If the column holds int values, then convert it to an int and store it in the array
                            attributes.Add(Double.Parse(rd[column].ToString()));
                            numOfItems++;
                            columnType = "double";
                        }
                    }
                    for (int i = 0; i < dateColumns.Length; i++)
                    {
                        // These columns store String values in the DB
                        if (column.Equals(dateColumns[i]))
                        {
                            // If the column holds int values, then convert it to an int and store it in the array
                            attributes.Add(DateTime.Parse(rd[column].ToString()));
                            numOfItems++;
                            columnType = "dateTime";
                        }
                    }

                }
            }
            catch (Exception e)
            {
                attributes.Add("Something went wrong");
            }

            // Close the connection
            if (ConnectionState.Open == sqlconn.State)
                sqlconn.Close();

            // return the values in the array
            return attributes;

        }

        // Inserts a new Product record into the Database based on a query
        public void insertProductData(String name, String image, double price, String audience, String colour, String print, String size, int catID, int cartID)
        {
            // Query for adding product
            String query = "INSERT INTO Product Values('" + name + "', '" + image + "', " + price + ", '" + audience + "', '" + colour + "', '" + print + "', '" + size + "', " + catID + ")";
            insertRecord(query);
        }

        // Inserts a new Login record into the Database based on a query
        public void insertNewLogin(String username, String pwd)
        {
            // Query for adding Login
            String query = "INSERT INTO Login Values('" + username + "', '" + pwd + "')";
            insertRecord(query);
        }

        // Inserts a new Admin Account record into the Database based on a query
        public void insertNewAdminAccount(DateTime joinDate, DateTime lastAccessed, String companyRole, int loginID)
        {
            // Query for adding AdminAccount
            String query = "INSERT INTO AdminAccount Values('" + joinDate + "', '" + companyRole + "', '" + lastAccessed + "', null, " + loginID + ")";
            insertRecord(query);
        }

        // Inserts a new Admin record into the Database based on a query
        public void insertNewAdmin(String firstName, String lastName, DateTime dateOfBirth, String emailAddress, int adminAccountID)
        {
            // Query for adding AdminAccount
            String query = "INSERT INTO Admin Values("+ adminAccountID + ", '" + firstName + "', '" + lastName + "', '" + dateOfBirth + "', '" + emailAddress + "')";
            insertRecord(query);
        }

        // Inserts a new Customer record into the Database based on a query
        public void insertCustomer(String firstName, String lastName, DateTime dateOfBirth, String emailAddress)
        {
            // Query for adding AdminAccount
            String query = "INSERT INTO Customer Values('" + firstName + "', '" + lastName + "', '" + dateOfBirth + "', '" + emailAddress + "')";
            insertRecord(query);
        }

        // Inserts a new Shopping Cart record into the Database based on a query
        public void insertShoppingCart()
        {
            // Query for adding AdminAccount
            String query = "INSERT INTO ShoppingCart Values(0, 0, 0, null, null)";
            insertRecord(query);
        }

        // Inserts a new Shopping Cart record into the Database based on a query
        public void insertMailingAddress(String unit, String street, String suburb, String city,
            String state, String country, String postcode)
        {
            // Query for adding AdminAccount
            String query = "INSERT INTO MailingAddress Values('" + unit + "', '" + street + "', '" + suburb + "', '" + city + "', '" + state + "', '" + country + "', '" + postcode + "')";
            insertRecord(query);
        }

        // Inserts a new CustomerAccount record into the Database based on a query
        public void insertCustomerAccount(int addressID, int customerID, int shoppingCartID, int loginID)
        {
            // Query for adding AdminAccount
            String query = "INSERT INTO CustomerAccount Values('" + DateTime.Today + "', 0, " + addressID + ", " + customerID + ", " + shoppingCartID + ", " + loginID + ")";
            insertRecord(query);
        }

        public void insertRecord(String query)
        {
            // Will open the connection to the DB
            if (ConnectionState.Closed == sqlconn.State)
                sqlconn.Open();

            SqlCommand cmd = new SqlCommand(query, sqlconn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { }
        }

        // ------------------------------------ CART ITEMS ------------------------------------

        public void changeQuantity (int newQuantity, int cartID)
        {
            // Will open the connection to the DB
            if (ConnectionState.Closed == sqlconn.State)
                sqlconn.Open();

            // Query for editing quantity
            // UPDATE CartItem SET quantity = quantityItem
            String query = "UPDATE CartITEM SET quantity = " + newQuantity + "WHERE cartItemID = " + (cartID+1);
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { }
        }

        public void insertCartItemData(int productID, int shoppingCartUserID, int quantity)
        {
            // Will open the connection to the DB
            if (ConnectionState.Closed == sqlconn.State)
                sqlconn.Open();

            // Query for adding product
            String query = "INSERT INTO CartItem Values(" + productID + ", " + shoppingCartUserID + ", " + quantity + ")";
            // loop through cart (to find which user is logged in)
            // then look at productID
                // if product exists, increment quantity
                // else quantity = 1
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) { }
        }

        // ------------------------------------ EDITING/DELETING PRODUCTS ------------------------------------

        public void update(String query)
        {
            // Will open the connection to the DB
            if (ConnectionState.Closed == sqlconn.State) sqlconn.Open();
            
            // The query that will be passed into this method will always be an update query.
            SqlCommand cmd = new SqlCommand(query, sqlconn);
            try { cmd.ExecuteNonQuery(); }
            catch (Exception e) { }
        }

        public int getNumOfItems()
        {
            return numOfItems;
        }

        public String getColumnType()
        {
            return columnType;
        }

    }
}