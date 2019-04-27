<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchasedItems.aspx.cs" Inherits="MerchKraft1.Pages.CustomerAccount.PurchasedItems" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="UserContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - PurchasedItems page -->

<!-- Div to hold contents of page -->
<!-- Div to hold contents of page -->
<div class="modal-dialog">
    <div class="modal-content">

        <div class="checkOutItems receipt">

            <!-- Page to go back to Profile -->
            <div style="padding:10px">
                <h6><asp:HyperLink ID="goBack" runat="server" Visible="true" NavigateUrl="../Profile/Profile"> Go back to Profile </asp:HyperLink></h6>
            </div>

            <h1> Purchased Items </h1>
            <hr />

            <!-- For each item, display in boxes: -->
            <% for (int i = 0; i < td.getNoOfPurchasedItems(); i++) { %> 

                <% td.setCurrentItemToDisplay(i); %>

                <!-- The box that contains the item -->
                <div class="coItem">

                    <!-- Price of product displayed on the right -->
                     <% td.setCurrentFunction("PurchasedItem"); %>
                     <div class ="coItemPrice">$<%=td.getPurchasedItem("price")%> </div>
     
                     <!-- The name, price and image for the product -->
                     <div class ="coItemPrice"><img src="../../<%=td.getPurchasedItem("productImageName")%>" alt="Product Image" /></div>
                     <h3> <%=td.getPurchasedItem("productDescription")%> </h3>
                     <p><%=td.getPurchasedItem("audience")%>, 
                     <%=td.getPurchasedItem("colour")%>, 
                     <%=td.getPurchasedItem("printType")%>, 
                     <%=td.getPurchasedItem("size")%> </p>
                     
                     <!-- displays reciept or transaction of item info (date etc). -->
                     <% td.setCurrentFunction("receipt"); %>
                     <p> Date Purchased: <%=td.getPurchasedItem("datePurchased")%> </p>
                     <p> Receipt: <%=td.getPurchasedItem("receiptNumber")%> </p>
                     
                </div>               

            <% } %>

        </div>

    </div>

    <div style="height:100px"></div>
</div>
</asp:Content>
