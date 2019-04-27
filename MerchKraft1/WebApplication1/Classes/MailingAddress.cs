/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - MailingAddress.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchKraft1
{
    public class MailingAddress
    {
        private int addressID;
        private String unit, street, suburb, city, state, country, postcode;
        private DatabaseAccess dbAccess = new DatabaseAccess();

        public MailingAddress()
        {
            addressID = 0;
            unit = "";
            street = "";
            suburb = "";
            city = "";
            state = "";
            country = "";
            postcode = "";
        }

        public MailingAddress(String unit, String street, String suburb, String city, 
            String state, String country, String postcode)
        {
            this.unit = unit;
            this.street = street;
            this.suburb = suburb;
            this.city = city;
            this.state = state;
            this.country = country;
            this.postcode = postcode;
        }

        // Get & Set for addressID
        public void setAddressID(int addressID) { this.addressID = addressID; }
        public int getAddressID() { return addressID; }

        // Get & Set for unit
        public void setUnit(String unit) { this.unit = unit; }
        public String getUnit() { return unit; }

        // Get & Set for street
        public void setStreet(String street) { this.street = street; }
        public String getStreet() { return street; }

        // Get & Set for suburb
        public void setSuburb(String suburb) { this.suburb = suburb; }
        public String getSuburb() { return suburb; }

        // Get & Set for city
        public void setCity(String city) { this.city = city; }
        public String getCity() { return city; }

        // Get & Set for state
        public void setState(String state) { this.state = state; }
        public String getState() { return state; }

        // Get & Set for country
        public void setCountry(String country) { this.country = country; }
        public String getCountry() { return country; }

        // Get & Set for postcode
        public void setPostcode(String postcode) { this.postcode = postcode; }
        public String getPostcode() { return postcode; }

        // Gets the number of items that was in the last array created (of items from the DB)
        public int getNumOfItems() {
            return dbAccess.getNumOfItems(); }

        // inserts new MailingAddress account record
        public void addNewAddress() {
            dbAccess.insertMailingAddress(unit, street, suburb, city, state, country, postcode); }
    }
}