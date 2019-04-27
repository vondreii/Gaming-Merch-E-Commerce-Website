/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - PayPal.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchKraft1
{
    public class PayPal
    {
        private int paymentID;
        private String paypalEmail, paypalPassword;

        public PayPal()
        {
            paymentID = 0;
            paypalEmail = "";
            paypalPassword = "";
        }

        public PayPal(int paymentID, String paypalEmail, String paypalPassword)
        {
            this.paymentID = paymentID;
            this.paypalEmail = paypalEmail;
            this.paypalPassword = paypalPassword;
        }

        // Get & Set for paymentID
        public void setPaymentID(int paymentID) { this.paymentID = paymentID; }
        public int getPaymentID() { return paymentID; }

        // Get & Set for paypalEmail
        public void setPaypalEmail(String paypalEmail) { this.paypalEmail = paypalEmail; }
        public String getPaypalEmail() { return paypalEmail; }

        // Get & Set for paypalPassword
        public void setPaypalPassword(String paypalPassword) { this.paypalPassword = paypalPassword; }
        public String getPaypalPassword() { return paypalPassword; }
    }
}