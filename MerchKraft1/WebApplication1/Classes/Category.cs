/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - Category.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerchKraft1
{
    public class Category
    {

        private int categoryID;
        private String name, categoryDescription;

        public Category ()
        {
            categoryID = 0; name = ""; categoryDescription = "";
        }

        public Category (int categoryID, String name, String categoryDescription)
        {
            this.categoryID = categoryID; this.name = name;
            this.categoryDescription = categoryDescription;
        }

        public void setCategoryID (int categoryID) { this.categoryID = categoryID; }
        public void setName (String name) { this.name = name; }
        public void setCategoryDescription (String categoryDescription)
            { this.categoryDescription = categoryDescription; }

        public int getCategoryID () { return categoryID; }
        public String getName () { return name; }
        public String getCategoryDescription () { return categoryDescription; }
    }
}