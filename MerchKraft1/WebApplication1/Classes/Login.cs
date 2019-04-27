/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - Login.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchKraft1
{
    public class Login
    {
        private int loginID;
        private String username, password;
        private DatabaseAccess dbAccess = new DatabaseAccess();

        public Login()
        {
            loginID = 0;
            username = "";
            password = "";
        }

        public Login(int loginID, String username, String password)
        {
            this.loginID = loginID;
            this.username = username;
            this.password = password;
        }

        // Get & Set for adminLoginID
        public void setLoginID(int loginID) { this.loginID = loginID; }
        public int getLoginID() { return loginID; }

        // Get & Set for username
        public void setUserName(String username) { this.username = username; }
        public String getUserName() { return username; }

        // Get & Set for password
        public void setPassword(String password) { this.password = password; }
        public String getPassword() { return password; }

        // Gets the number of items that was in the last array created (of items from the DB)
        public int getNumOfItems() {
            return dbAccess.getNumOfItems(); }

        public void insertNewLogin()
        {
            dbAccess.insertNewLogin(username, password);
        }
    }
}