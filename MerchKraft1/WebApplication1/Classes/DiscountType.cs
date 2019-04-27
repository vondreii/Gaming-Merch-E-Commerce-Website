/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - DiscountType.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchKraft1
{
    public class DiscountType
    {
        private int discountID;
        private double discountAmount;
        private String discountCode, conditions;

        public DiscountType()
        {
            discountID = 0;
            discountCode = "";
            discountAmount = 0;
            conditions = "";
        }

        public DiscountType(int discountID, String discountCode, double discountAmount, String conditions)
        {
            this.discountID = discountID;
            this.discountCode = discountCode;
            this.discountAmount = discountAmount;
            this.conditions = conditions;
        }

        // Get & Set for discountID
        public void setDiscountID(int discountID) { this.discountID = discountID; }
        public int getDiscountID() { return discountID; }

        // Get & Set for discountCode
        public void setDiscountCode(String discountCode) { this.discountCode = discountCode; }
        public String getDiscountCode() { return discountCode; }

        // Get & Set for discountAmount
        public void setDiscountAmount(double discountAmount) { this.discountAmount = discountAmount; }
        public double getDiscountAmount() { return discountAmount; }

        // Get & Set for conditions
        public void setConditions(String conditions) { this.conditions = conditions; }
        public String getConditions() { return conditions; }
    }
}