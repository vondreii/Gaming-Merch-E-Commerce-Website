/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - AdminAccount.cs
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
    public class AdminAccount
    {
        // private variables storing details about a admin account
        private int adminAccountID, loginID;
        private DateTime joinDate, lastAccessed, changeLog;
        // for date only: DateTime dateOnly = date1.Date;
        private String companyRole;
        private DatabaseAccess dbAccess = new DatabaseAccess();

        // Default constructor for an Admin Account
        public AdminAccount()
        {
            adminAccountID = 0; loginID = 0;  joinDate = new DateTime(1980, 01, 01);
            lastAccessed = new DateTime(1980, 01, 01); changeLog = new DateTime(1980, 01, 01);
            companyRole = "Nothing";
            
        }

        // Constructor for an admin account, when details are already known
        public AdminAccount(DateTime joinDate, DateTime lastAccessed, String companyRole)
        {
            this.joinDate = joinDate; this.lastAccessed = lastAccessed; this.companyRole = companyRole.Trim();
        }

        // Get & Set for adminAccountID
        public void setAdminAccountID(int adminAccountID) { this.adminAccountID = adminAccountID; }
        public int getAdminAccountID() { return adminAccountID; }

        // Get & Set for loginID
        public void setLoginID(int loginID) { this.loginID = loginID; }
        public int getLoginID() { return loginID; }

        // Get & Set for joinDate
        public void setJoinDate(DateTime joinDate) { this.joinDate = joinDate; }
        public DateTime getJoinDate() { return joinDate; }

        // Get & Set for lastAccessed
        public void setLastAccessed(DateTime lastAccessed) { this.lastAccessed = lastAccessed; }
        public DateTime getLastAccessed() { return lastAccessed; }

        // Get & Set for changeLog
        public void setChangeLog(DateTime changeLog) { this.changeLog = changeLog; }
        public DateTime getChangeLog() { return changeLog; }

        // Get & Set for companyRole
        public void setCompanyRole(String companyRole) { this.companyRole = companyRole; }
        public String getCompanyRole() { return companyRole; }

        // Gets the number of items that was in the last array created (of items from the DB)
        public int getNumOfItems() {
            return dbAccess.getNumOfItems(); }

        public void insertNewAdminAccount(int loginID) {
            dbAccess.insertNewAdminAccount(joinDate, lastAccessed, companyRole, loginID); }
    }
}