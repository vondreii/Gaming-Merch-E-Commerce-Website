/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - Customer.cs
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
    public class Customer
    {
        // private variables storing details about a customer
        private int customerID, customerAccountID;
        private String firstName, lastName, emailAddress;
        private DateTime dateOfBirth; //dateOfBirth.Date just to show the date
        private DatabaseAccess dbAccess = new DatabaseAccess();

        // Default constructor for Customer
        public Customer()
        {
            customerID = 0;
            customerAccountID = 0;
            firstName = "";
            lastName = "";
            emailAddress = "";
            dateOfBirth = new DateTime(1980, 01, 01);
        }

        // Constructor for customer, when details are already known
        public Customer(String firstName, String lastName, DateTime dateOfBirth)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }

        // Get & Set for customerID
        public void setCustomerID(int customerID) { this.customerID = customerID; }
        public int getCustomerID() { return customerID; }

        // Get & Set for customerAccountID
        public void setCustomerAccountID(int customerAccountID) { this.customerAccountID = customerAccountID; }
        public int getCustomerAccountID() { return customerAccountID; }

        // Get & Set for firstName
        public void setFirstName(String firstName) { this.firstName = firstName; }
        public String getFirstName() { return firstName; }

        // Get & Set for lastname
        public void setLastName(String lastName) { this.lastName = lastName; }
        public String getLastName() { return lastName; }

        // Get & Set for emailAddress
        public void setEmailAddress(String emailAddress) { this.emailAddress = emailAddress; }
        public String getEmailAddress() { return emailAddress; }

        // Get & Set for dateOfBirth
        public void setDateOfBirth(DateTime dateOfBirth) { this.dateOfBirth = dateOfBirth; }
        public DateTime getDateOfBirth() { return dateOfBirth; }

        // Gets the number of items that was in the last array created (of items from the DB)
        public String getColumnType() {
            return dbAccess.getColumnType(); }

        // Gets the number of items that was in the last array created (of items from the DB)
        public int getNumOfItems() {
            return dbAccess.getNumOfItems(); }

        // Gets all the productIDs of all products stored in the DB
        public ArrayList retrieveData(String query, String attribute) {
            return dbAccess.selectData(query, attribute); }

        // Inserts new Customer record
        public void addNewCustomer() {
            dbAccess.insertCustomer(firstName, lastName, dateOfBirth, emailAddress); }

    }
}