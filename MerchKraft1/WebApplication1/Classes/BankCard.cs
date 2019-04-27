/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - BankCard.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchKraft1
{
    public class BankCard
    {
        private int paymentID;
        private String cardNumber;
        private String CVV; // Security code
        private DateTime expiryDate; // DateTime dateOnly = date1.Date;

        public BankCard ()
        {
            paymentID = 0; cardNumber = ""; CVV = ""; expiryDate = new DateTime(1980, 01, 01);
        }

        public BankCard (int paymentID, String cardNumber, String CVV, DateTime expiryDate)
        {
            this.paymentID = paymentID;  this.cardNumber = cardNumber; this.CVV = CVV; this.expiryDate = expiryDate;
        }

        public void setPaymentID(int paymentID) { this.paymentID = paymentID; }
        public void setCardNumber (String cardNumber) { this.cardNumber = cardNumber; }
        public void setCVV (String CVV) { this.CVV = CVV; }
        public void setExpiryDate (DateTime expiryDate) { this.expiryDate = expiryDate; }

        public int getPaymentID() { return paymentID; }
        public String getCardNumber () { return cardNumber; }
        public String getCVV () { return CVV; }
        public DateTime getExpiryDate () { return expiryDate; }

    }
}