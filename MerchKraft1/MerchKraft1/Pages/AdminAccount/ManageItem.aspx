<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageItem.aspx.cs" Inherits="MerchKraft1.Pages.AdminAccount.ManageItem" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - ManageItem page -->
    <!-- Container that holds all the content of the page -->
    <div class="container">
      
        <h1> Manage Products </h1>
        <h4> All products list </h4>
        <hr />

        <a href="AddNewProduct"><div class="addToCartButton">(+) Add New Product</div></a>
        <!-- Rows of boxes that contain each item -->
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
                    <img src="<%="../../"+td.getProduct("productImageName")%>" alt="Product Image" />

                    <!-- Displays the name, description and other info about the product -->
                    <div class="itemDesc"> <%=td.getProduct("productDescription") %> </div>

                    <h3>  $<%= td.getProduct("price") %> </h3>

                    <div class="itemDesc"> <%=td.getProduct("audience")%> 
                                            | <%=td.getProduct("size")%> 
                                            | <%=td.getProduct("colour")%> </div>
                    
                    <div class="itemDesc"> This item has a <%=td.getProduct("printType")%> </div>
                    
                    <!-- Link to edit/delete product -->
                    <!-- <a href="EditProduct"><div class="addToCartButton">Edit Product</div></a> -->
                    <a href="../SessionHandler.aspx?product=<%=i%>&customer=-1"><div class="addToCartButton">Manage Product</div></a>
                    
                </div>   
            </div>

            <% } %>
           
        </div> 
       

    </div>

</asp:Content>
