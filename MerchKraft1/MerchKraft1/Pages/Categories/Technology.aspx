<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Technology.aspx.cs" Inherits="MerchKraft1.Pages.Categories.Technology" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - Keychains page -->

    <!-- Container that holds all the content of the page -->
    <div class="container">
        <h4> <asp:Label ID="itemAddedLabel" runat="server" Text="Item sucessfully added to cart " Visible="false"></asp:Label> </h4>
        <h1> Technology </h1>
        <hr />

        <!-- Rows of boxes that contain each item -->
        <div class="row">

            <% td.setCurrentFunction("Technology"); %>
            
            <!-- For each item, display in boxes: -->
            <% for (int i = 0; i < td.returnNoOfProducts(); i++) { %> 

            <% td.setCurrentItemToDisplay(i); %>

            <!-- The first box (the first item) -->
            <div class="col-sm-4">
                <!-- The item inside the box -->
                <div class="item"> 

                   <!-- Has an image associated with it, and a button to add to the cart -->
                    <img src="<%="../../"+td.getProduct("productImageName")%>" alt="Product Image" />

                    <!-- Displays the name, description and other info about the product -->
                    <div class="itemDesc"> <%=td.getProduct("productDescription") %> </div>

                    <h3>  $<%= td.getProduct("price") %> </h3>

                    <div class="itemDesc"> <%=td.getProduct("audience")%> 
                                            | <%=td.getProduct("size")%> 
                                            | <%=td.getProduct("colour")%> </div>
                    
                    <div class="itemDesc"> This item has a <%=td.getProduct("printType")%> </div>

                    <!-- Adds to cart -->
                    <asp:Button ID="addToCart1" CssClass="addToCartButton" runat="server" Text="Add to Cart" OnClick="addToCart_Click" />
                </div>   
            </div>

            <% } %>
        </div>

    </div>

</asp:Content>
