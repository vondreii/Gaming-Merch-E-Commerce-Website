/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - PurchasedItem.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchKraft1
{
    public class PurchasedItem
    {

        private int purchasedItemID, customerAccountID;
        private DateTime datePurchased;
        private String receiptNumber;

        public PurchasedItem ()
        {
            purchasedItemID = 0; customerAccountID = 0;
            datePurchased = new DateTime(1980, 01, 01); receiptNumber = "RCPT1003";
        }

        public PurchasedItem (int purchasedItemID, int customerAccountID, DateTime datePurchased, 
            String receiptNumber)
        {
            this.purchasedItemID = purchasedItemID; this.customerAccountID = customerAccountID;
            this.datePurchased = datePurchased; this.receiptNumber = receiptNumber;
        }

        public void setPurchasedItemID (int purchasedItemID) { this.purchasedItemID = purchasedItemID; }
        public void setCustomerAccountID (int customerAccountID) { this.customerAccountID = customerAccountID; }
        public void setDatePurchased (DateTime datePurchased) { this.datePurchased = datePurchased; }
        public void setReceiptNumber (String receiptNumber) { this.receiptNumber = receiptNumber; }

        public int getPurchasedItemID () { return purchasedItemID; }
        public int getCustomerAccountID () { return customerAccountID; }
        public DateTime getDatePurchased () { return datePurchased; }
        public String getReceiptNumber () { return receiptNumber; }
    }
}
