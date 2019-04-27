<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MerchKraft1._Default"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - Default page -->
   
    <!-- Container that holds all the content of the page -->
    <div class="container">
        <asp:Label ID="accDeletedLabel" runat="server" Text="Successfully deleted" Visible="false"></asp:Label>
        <h4> <asp:Label ID="itemAddedLabel" runat="server" Text="Item sucessfully added to cart " Visible="false"></asp:Label> </h4>
        <h1> Featured Items </h1>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Merchkraft1_DBConnectionString %>" SelectCommand="SELECT * FROM [Admin]"></asp:SqlDataSource>
        <hr /> 


    </div> 
  
        <!-- Rows of boxes that contain each item -->
        <div class="row">

            <% td.setCurrentFunction("AllProducts"); %>

            <!-- For each item, display in boxes: -->
            <% for (int i = 0; i < td.returnNoOfProducts(); i++) { %> 

            <% td.setCurrentItemToDisplay(i); %>

            <!-- The first box (the first item) -->
            <div class="col-sm-4">
                <!-- The item inside the box -->
                <div class="item"> 

                    <!-- Has an image associated with it, and a button to add to the cart -->
                    <img src="<%=td.getProduct("productImageName")%>" alt="Product Image" />

                    <!-- Displays the name, description and other info about the product -->
                    <div class="itemDesc"> <%=td.getProduct("productDescription") %> </div>

                    <h3>  $<%= td.getProduct("price") %> </h3>

                    <div class="itemDesc"> <%=td.getProduct("audience")%> 
                                            | <%=td.getProduct("size")%> 
                                            | <%=td.getProduct("colour")%> </div>
                    
                    <div class="itemDesc"> This item has a <%=td.getProduct("printType")%> </div>
                    <a href="Pages/CustomerAccount/AddToCart.aspx?prod=<%=td.getProduct("productID")%>"><div class="addToCartButton">Add to Cart!</div></a>
                    <!-- Adds to cart -->
                    <!--<asp:Button ID="addToCart1" CssClass="addToCartButton" runat="server" Text="Add to Cart" OnClick="addToCart_Click" />-->
                </div>   
            </div>

            <% } %>
           
        </div>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server" Visible="false">

    <!-- Container that holds all the content of the page (for admin) -->
    <div class="container">
        
        <h1> Admin Home </h1>
        <h4> Please select 'Manage Products' or 'Manage User Accounts' under the Manage tab to make changes to data in the system. </h4>
        <hr />

    </div>

</asp:Content>
