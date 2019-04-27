using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerchKraft1.Pages
{
    public partial class SessionHandler : System.Web.UI.Page
    {
        public TestData sessionData = new TestData();
        protected void Page_Load(object sender, EventArgs e)
        {
            String s = Request.QueryString["product"]; // target page
            Session["product"] = s; // source page

            String c = Request.QueryString["customer"]; // target page
            Session["customer"] = c; // source page


            //Label1.Text = Session["product"].ToString();
            //sessionData.setCurrentProduct(Int32.Parse(Session["product"].ToString()));

            if(!Session["product"].ToString().Equals("-1")) Response.Redirect("AdminAccount/EditProduct");
            if (!Session["customer"].ToString().Equals("-1")) Response.Redirect("AdminAccount/EditUser");
        }
    }
}