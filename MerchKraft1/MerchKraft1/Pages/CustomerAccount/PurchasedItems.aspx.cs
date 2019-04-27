/**
 * INFT3050 - WEB PROGRAMMING
 * ASSIGNMENT PART 1
 * March 2018 - April 2018
 * 
 * MERCHKRAFT - PurchaseItems.aspx.cs
 * @Author: Sora Khan (3197198)
 *          Sharlene Von Drehnen (3220929)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerchKraft1.Pages.CustomerAccount
{
    public partial class PurchasedItems : System.Web.UI.Page
    {
        protected TestData td = new TestData();
        protected void Page_Load(object sender, EventArgs e)
        {
            Object seshName = Session["Name"]; // stores session name object
            string pageName = System.IO.Path.GetFileNameWithoutExtension(Page.AppRelativeVirtualPath); // gets the page name
            if (seshName != null) // user has logged in 
            {
                String sessionName = seshName.ToString();
                td.setCurrentUserToDisplay(sessionName);
            }
        }
    }
}