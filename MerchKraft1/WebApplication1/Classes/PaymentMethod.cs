/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - PaymentMethod.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchKraft1
{
    public class PaymentMethod
    {

        private int paymentID;
        private String paymentTransaction;

        public PaymentMethod ()
        {
            paymentID = 0;
            paymentTransaction = "";
        }

        public PaymentMethod (int paymentID, String paymentType)
        {
            this.paymentID = paymentID;
            this.paymentTransaction = paymentType;
        }

        public void setPaymentID (int paymentID) { this.paymentID = paymentID; }
        public void setPaymentType (String paymentTransaction) { this.paymentTransaction = paymentTransaction; }
        public int getPaymentID() { return paymentID; }
        public String getPaymentType() { return paymentTransaction; }

    }
}