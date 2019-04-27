/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - CustomerAccount.cs
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
    public class CustomerAccount
    {
        // private variables storing details about a customer account
        private int CustomerAccountID, numOfPurchases, addressID, loginID;
        private DateTime joinDate;
        private DatabaseAccess dbAccess = new DatabaseAccess();

        // Default constructor for CustomerAccount
        public CustomerAccount ()
        {
            CustomerAccountID = 0; numOfPurchases = 0; addressID = 0; loginID = 0; 
            joinDate = new DateTime(1980, 01, 01);
        }

        // Default constructor when details are already known
        public CustomerAccount (int CustomerAccountID, int numOfPurchases, int addressID, int loginID, 
             DateTime joinDate)
        {
            this.CustomerAccountID = CustomerAccountID; this.numOfPurchases = numOfPurchases; this.loginID = loginID;
            this.addressID = addressID; this.joinDate = joinDate;
        }

        // Get & Set for CustomerAccountID
        public void setCustomerAccountID (int CustomerAccountID) { this.CustomerAccountID = CustomerAccountID; }
        public int getCustomerAccountID() { return CustomerAccountID; }

        // Get & Set for numPurchases
        public void setnumOfPurchases (int numOfPurchases) { this.numOfPurchases = numOfPurchases; }
        public int getnumOfPurchases() { return numOfPurchases; }

        // Get & Set for addressID
        public void setAddressID (int addressID) { this.addressID = addressID; }
        public int getAddressID() { return addressID; }

        // Get & Set for loginID
        public void setLoginID(int loginID) { this.loginID = loginID; }
        public int getLoginID() { return loginID; }

        // Get & Set for joinDate
        public void setJoinDate (DateTime joinDate) { this.joinDate = joinDate; }
        public DateTime getJoinDate() { return joinDate; }

         // Gets the number of items that was in the last array created (of items from the DB)
        public String getColumnType() {
            return dbAccess.getColumnType(); }

        // Gets all the productIDs of all products stored in the DB
        public ArrayList retrieveData(String query, String attribute) {
            return dbAccess.selectData(query, attribute); }

        // Gets the number of items that was in the last array created (of items from the DB)
        public int getNumOfItems() {
            return dbAccess.getNumOfItems(); }

        // inserts new customer account record
        public void addNewCustomerAccount(int addressID, int customerID, int shoppingCartID, int loginID) {
            dbAccess.insertCustomerAccount(addressID, customerID, shoppingCartID, loginID); 
        }
    }
}