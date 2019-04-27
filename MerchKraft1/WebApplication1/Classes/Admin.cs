/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - Admin.cs
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
    public class Admin
    {
        // private variables storing details about a admin
        private int adminID, adminAccountID;
        private String firstName, lastName, emailAddress;
        private DateTime dateOfBirth;
        private DatabaseAccess dbAccess = new DatabaseAccess();

        // Default constructor for Admin
        public Admin()
        {
            adminID = 0;
            adminAccountID = 0;
            firstName = "";
            lastName = "";
            dateOfBirth = new DateTime(1980, 01, 01);
            emailAddress = "";
        }

        // Constructor for admin, when details are already known
        public Admin(String firstName, String lastName, DateTime dateOfBirth, String emailAddress)
        {
            this.firstName = firstName.Trim();
            this.lastName = lastName.Trim();
            this.dateOfBirth = dateOfBirth;
            this.emailAddress = emailAddress.Trim();
        }

        // Get & Set for adminID
        public void setAdminID(int adminID) { this.adminID = adminID; }
        public int getAdminID() { return adminID; }

        // Get & Set for adminAccountID
        public void setAdminAccountID(int adminAccountID) { this.adminAccountID = adminAccountID; }
        public int getAdminAccountID() { return adminAccountID; }

        // Get & Set for firstName
        public void setFirstName(String firstName) { this.firstName = firstName; }
        public String getFirstName() { return firstName; }

        // Get & Set for lastName
        public void setLastName(String lastName) { this.lastName = lastName; }
        public String getLastName() { return lastName; }

        // Get & Set for dateOfBirth
        public void setDateOfBirth(DateTime dateOfBirth) { this.dateOfBirth = dateOfBirth; }
        public DateTime getDateOfBirth() { return dateOfBirth; }

        // Get & Set for emailAddress
        public void setEmailAddress(String emailAddress) { this.emailAddress = emailAddress; }
        public String getEmailAddress() { return emailAddress; }

        // Gets the number of items that was in the last array created (of items from the DB)
        public int getNumOfItems() {
            return dbAccess.getNumOfItems(); }

        // Gets the number of items that was in the last array created (of items from the DB)
        public String getColumnType() {
            return dbAccess.getColumnType(); }

        // Gets all the productIDs of all products stored in the DB
        public ArrayList retrieveData(String query, String attribute) {
            return dbAccess.selectData(query, attribute); }

        public void insertNewAdmin(int adminAccountID) {
           dbAccess.insertNewAdmin(firstName, lastName, dateOfBirth, emailAddress, adminAccountID); }
    }
}