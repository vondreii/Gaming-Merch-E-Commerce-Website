/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - Default.aspx.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerchKraft1
{
    public partial class _Default : Page //Page
    {
        // Declares and initialises all objects with test data
        protected TestData td = new TestData();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            
        }

        protected void addToCart_Click(object sender, EventArgs e)
        {
            itemAddedLabel.Visible = true;
        }
    }
}