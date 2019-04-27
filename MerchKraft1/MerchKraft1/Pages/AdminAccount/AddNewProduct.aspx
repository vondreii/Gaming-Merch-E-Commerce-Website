<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddNewProduct.aspx.cs" Inherits="MerchKraft1.Pages.AdminAccount.AddNewProduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - AddNewProduct page -->

    <!-- Div to hold contents of page -->
    <div class="modal-dialog">
    <div class="modal-content">

            <div style="padding:10px">
                <h6><asp:HyperLink ID="goBack" runat="server" Visible="true" NavigateUrl="ManageItem"> Go back to Manage Items </asp:HyperLink></h6>
            </div>

            <!-- Div with Register heading -->
            <div class="modal-header">
                <h1 class="text-center">Add New Product</h1>
            </div>
            <!-- Body of form -->
            <div class="modal-body">

                 <h2> New Product Details </h2>
                 <hr />

                 <!-- *** Product Name *** -->

                 <div class="form-group">
                     <!-- Text box for the productDescription, checks to see if it is blank -->
                     <p> Product Name: </p><asp:TextBox ID="productName" runat="server" placeholder="Skyrim T-Shirt"></asp:TextBox> 
                     <!-- Validation for the productDescription, checks to see if it is blank -->
                     <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvProductName" runat="server" ControlToValidate="productName"
                        ErrorMessage = "Please enter the product name">
                     </asp:RequiredFieldValidator></p>
                 </div>

                 <!-- *** Price *** -->
                 <div class="form-group">
                    <!-- Text box for size, checks to see if it is blank -->
                    <p> Price: </p><asp:TextBox ID="price" runat="server" placeholder="45.50"></asp:TextBox> 
                    <!-- Validation for price, checks to see if it is blank -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvPrice" runat="server" ControlToValidate="price"
                        ErrorMessage = "Please enter the price">
                    </asp:RequiredFieldValidator></p>
                    <!-- Validation for price, checks to see if it is > 0-->
                    <p class="validateMessage"><asp:CompareValidator 
                        ID="cvPrice" runat="server" ControlToValidate="price" 
                        Type="Double" Operator="GreaterThan" ValueToCompare="0" 
                        ErrorMessage="Invalid Price"> 
                     </asp:CompareValidator></p>
                 </div>
                
                 <!-- *** Audience *** -->
                 <div class="form-group">
                    <!-- Drop down list for audience -->
                    <p> Audience: </p> 
                     <asp:DropDownList ID="audience" runat="server">
                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Unisex" Value="3"></asp:ListItem>
                     </asp:DropDownList>
                    
                 </div>

                 <!-- *** Colour *** -->
                 <div class="form-group">
                    <!-- Text box for suburb -->
                    <p> Colour: </p><asp:TextBox ID="colour" runat="server" placeholder="Blue"></asp:TextBox> 
                    <!-- Validation for age, checks to see if it is blank -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvColour" runat="server" ControlToValidate="colour"
                        ErrorMessage = "Please enter the colour">
                     </asp:RequiredFieldValidator></p>
                 </div>

                 <!-- *** Print Type *** -->
                 <div class="form-group">
                    <!-- Text box for postcode -->
                    <p> Print Type: </p><asp:TextBox ID="printType" runat="server" placeholder="Skyrim Print"></asp:TextBox> 
                    <!-- Validation for age, checks to see if it is blank -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvPrintType" runat="server" ControlToValidate="printType"
                        ErrorMessage = "Please enter the print type">
                     </asp:RequiredFieldValidator></p> 
                 </div>

                 <!-- *** SIZE *** -->
                 <div class="form-group">
                    <!-- Text box for size, checks to see if it is blank -->
                    <p> Size: </p>
                    <asp:DropDownList ID="size" runat="server">
                        <asp:ListItem Text="XS" Value="1"></asp:ListItem>
                        <asp:ListItem Text="S" Value="2"></asp:ListItem>
                        <asp:ListItem Text="M" Value="3"></asp:ListItem>
                        <asp:ListItem Text="L" Value="4"></asp:ListItem>
                        <asp:ListItem Text="XL" Value="5"></asp:ListItem>
                        <asp:ListItem Text="XXL" Value="6"></asp:ListItem>
                     </asp:DropDownList>
                 </div>

                 <!-- *** CATEGORY *** -->
                 <div class="form-group">
                     <p> Category: </p>
                     <asp:DropDownList ID="category" runat="server">
                        <asp:ListItem Text="Clothing" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Accessories" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Home Decor" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Technology" Value="4"></asp:ListItem>

                     </asp:DropDownList>
                     
                 </div>

                 <br />
                 <div class="form-group">
                     <!-- Button to add product-->
                     <asp:Button ID="btnAddProduct" runat="server" Visible="true" cssClass="btn btn-block btn-lg btn-primary" Text="Add New Product" Enabled="true" OnClick="btnAddProduct_Click" />
                 </div>
             </div>
        </div>
    </div>

</asp:Content>
