<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="MerchKraft1.Pages.CustomerAccount.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="accessDenied" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="UserContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - Checkout page -->
   <!-- Div to hold contents of page -->
    <div class="container">
        
        <h1> Checkout </h1>
        <p> <a href="../../Default"> Home </a> > <a href="ShoppingCart">Shopping Cart</a> > Checkout </p>
        <hr />


        <div class="checkOutItems">
            <div class="coItem">
                <img src="https://image.spreadshirtmedia.net/image-server/v1/products/133821034/views/1,width=800,height=800,appearanceId=2,version=1478003241/fus-ro-dah-5Bskyrim5D-maenner-t-shirt.png" />
                 <%=td.displayName(2245)%> 
                <div class ="coItemPrice">$<%=td.displayPrice(2245)%> </div>
            </div>
            <div class="coItem">
                <img src="https://fgl.scene7.com/is/image/FGLSportsLtd/332538410_20_a?wid=800&hei=800&bgColor=0,0,0,0&fmt=png-alpha&resMode=sharp2&op_sharpen=1" />
                <%=td.displayName(2254)%> 
                <div class ="coItemPrice">$<%=td.displayPrice(2254)%></div>
            </div> 
        </div>
        
        <div class="otherCost">
            <span class="innerTitle">Shipping Cost: </span>
            <div class ="shipPrice">$ <%=shippingPrice%></div>
        </div>

        <div class="otherCost">
            <span class="innerTitle">Total: </span>
            <div class ="shipPrice">$ <%=shippingPrice + td.displayPrice(2245) + td.displayPrice(2254)%></div>
        </div>

        <!--<p> Can add a Discount Code here with an input box in a form? </p>
            <p> If it is blank then ignore, iif they enter something, then it should be validated. </p>
            <p> Total price </p>
            <br /> 
        <br />-->
       
        <!--<h3>Method of Delivery:</h3>   
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Text ="Pick-up" Value="1" />
                <asp:ListItem Text ="Deliver" Value="2" />
        </asp:RadioButtonList>-->
        <h3> Choose Method of Payment </h3>

        
        <a href="PayPalPayment"> <div class="payButton paypal">PayPal</div> </a> 
        <a href="BankCardPayment"> <div class="payButton card">Card</div>  </a>

    </div> 

</asp:Content>