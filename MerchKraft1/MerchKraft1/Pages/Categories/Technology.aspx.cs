using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MerchKraft1.Pages.Categories
{
    public partial class Technology : System.Web.UI.Page
    {
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