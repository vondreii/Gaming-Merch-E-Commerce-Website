<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="MerchKraft1.Pages.CustomerAccount.ShoppingCart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - ShoppingCart page -->

    <!-- Div to hold contents of page -->
    <div class="container">
        
        <h1> Shopping Cart </h1>
        <p> <a href="../../Default"> Home </a> > Shopping Cart </p>
        <hr />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Panel ID="coItemHead" runat="server"></asp:Panel>
        <asp:Panel ID="coItemPanel" runat="server"></asp:Panel>
            <!--<div class="coItem">
                <img src="https://image.spreadshirtmedia.net/image-server/v1/products/133821034/views/1,width=800,height=800,appearanceId=2,version=1478003241/fus-ro-dah-5Bskyrim5D-maenner-t-shirt.png" />
                 <!%=td.displayName(2245)%> 
                <div class ="coItemPrice">$<!%=td.displayPrice(2245)%> </div>
            </div>
            <div class="coItem">
                <img src="https://fgl.scene7.com/is/image/FGLSportsLtd/332538410_20_a?wid=800&hei=800&bgColor=0,0,0,0&fmt=png-alpha&resMode=sharp2&op_sharpen=1" />
                <!%=td.displayName(2254)%> 
                <div class ="coItemPrice">$<!%=td.displayPrice(2254)%></div>
            </div> -->
        

        <a href="Checkout"><div class="checkOut">Proceed to Checkout</div> </a> 


    </div> 

</asp:Content>
