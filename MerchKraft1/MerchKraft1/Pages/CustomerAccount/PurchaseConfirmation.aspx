<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseConfirmation.aspx.cs" Inherits="MerchKraft1.Pages.CustomerAccount.PurchaseConfirmation" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="UserContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - PurchaseConfirmation page -->

    <!-- Div to hold contents of page -->
    <div class="container">
        
        <h1> Confirmation of Purchase </h1>

        <hr />

        <!-- Paragraphs about Merchkraft -->
        
        <div class="checkOutItems receipt">
            <h3> Thank you for shopping at Merchkraft! </h3>
            <h4> Receipt Number: #WEBR000042018 </h4> 
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

            <a href="../../Default">Continue shopping</a> <br />
            <a href="PurchasedItems">View Purchased Items</a>
        </div>

        <div style="height:100px"></div>

    </div> 

</asp:Content>