<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="MerchKraft1.Pages.AdminAccount.EditProduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - EditProduct page -->

<div class="modal-dialog">
    <div class="modal-content">
            <% td.setCurrentFunction("AllProducts"); %>
            <% td.setCurrentItemToDisplay(Int32.Parse(Session["product"].ToString())); %>
            
            <!-- When the user has already selected 'save changes' this will display. -->
            <div style="padding:10px">
                <h5> <asp:Label ID="changesSavedMessage" runat="server" Visible="false" Text="Changes Saved"> </asp:Label> </h5>  
                <h6><asp:HyperLink ID="goBack" runat="server" Visible="true" NavigateUrl="ManageItem"> Go back to Manage Items </asp:HyperLink></h6>
                <asp:Label ID="lblError" CssClass="validateMessage" runat="server" Visible="true" Text="Please fix all errors on the page before saving any changes"> </asp:Label>
            </div>
            <!-- Div with Register heading -->
            <div class="modal-header">
                <h1 class="text-center">Edit Product</h1>
                <h4> Enter the new details of the fields you wish to change. </h4>
                <div class="item" style="height:80px"> 
                    <img src="<%="../../"+td.getProduct("productImageName")%>" alt="Product Image" />
                </div>
                <br />
               
            </div>
            <!-- Body of form -->
            <div class="modal-body">
 
                <div class="tbl">
                     <!-- Allows user to edit the product name -->
                     <h5> Edit Product Name </h5>  
                     <div>
                         <!-- displays the product detail, and a text box if they choose to change the name -->
                         <p> Current: <%=td.getProduct("productDescription") %> </p><br />
                         <asp:TextBox ID="changeProductName" runat="server" placeholder="New Product Name"></asp:TextBox> 
                         <!-- Button to submit changes -->
                         <asp:Button ID="btnChangeDescription" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeDescription_Click" />
                   
                     </div>
                     <hr />

                     <!-- Allows user to edit the the price -->
                     <h5> Edit Price </h5>  
                     <div>
                        <!-- displays the product detail, and a text box if they choose to change the price -->
                        <p> Current: $<%= td.getProduct("price") %> </p><br />
                        <asp:TextBox ID="changePrice" runat="server" placeholder="New Price"></asp:TextBox> 
                        <!-- Button to submit changes -->
                        <asp:Button ID="btnPrice" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangePrice_Click" />
                   
                        <!-- Validation for price, checks to see if it is > 0-->
                        <p class="validateMessage"><asp:CompareValidator 
                            ID="cvChangePrice" runat="server" ControlToValidate="changePrice" 
                            Type="Double" Operator="GreaterThan" ValueToCompare="0" 
                            ErrorMessage="Invalid Price"> 
                         </asp:CompareValidator></p>
                     </div>
                     <hr />

                     <!-- Allows user to edit the audience -->
                    <h5> Edit Audience </h5>  
                    <div>
                        <!-- displays the product detail, and a text box if they choose to change the audience -->
                        <p>Current: <%=td.getProduct("audience")%>  </p>
                        <br />
                        <asp:DropDownList ID="audience" runat="server">
                            <asp:ListItem Text="men" Value="1"></asp:ListItem>
                            <asp:ListItem Text="women" Value="2"></asp:ListItem>
                            <asp:ListItem Text="unisex" Value="3"></asp:ListItem>
                            <asp:ListItem Text="kids" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                        <!-- Button to submit changes -->
                        <asp:Button ID="btnAudience" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeAudience_Click" />

                    </div>
                    <hr />

                    <!-- Allows user to edit the colour -->
                    <h5> Edit Colour </h5>  
                    <div>
                        <!-- displays the product detail, and a text box if they choose to change the colour -->
                       <p> Current: <%=td.getProduct("colour")%> </p><br />
                       <asp:TextBox ID="changeColour" runat="server" placeholder="New Colour"></asp:TextBox> 
                       <!-- Button to submit changes -->
                       <asp:Button ID="btnColour" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeColour_Click" />
                   
                    </div>
                    <hr />

                    <!-- Allows user to edit the print type -->
                    <h5> Edit Print Type </h5>  
                    <div>
                        <!-- displays the product detail, and a text box if they choose to change the print type -->
                       <p> Current: <%=td.getProduct("printType")%> </p><br />
                       <asp:TextBox ID="newPrintType" runat="server" placeholder="New Print Type"></asp:TextBox> 
                        <!-- Button to submit changes -->
                       <asp:Button ID="btnPrint" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangePrint_Click" />
                   
                    </div>
                    <hr />

                    <!-- Allows user to edit the product Size -->
                     <h5> Edit Size </h5>  
                     <div>
                        <!-- displays the product detail, and a text box if they choose to change the size -->
                        <p> Current: <%=td.getProduct("size")%> </p><br />
                        <asp:DropDownList ID="size" runat="server">
                            <asp:ListItem Text="XS" Value="1"></asp:ListItem>
                            <asp:ListItem Text="S" Value="2"></asp:ListItem>
                            <asp:ListItem Text="M" Value="3"></asp:ListItem>
                            <asp:ListItem Text="L" Value="4"></asp:ListItem>
                            <asp:ListItem Text="XL" Value="5"></asp:ListItem>
                            <asp:ListItem Text="XXL" Value="6"></asp:ListItem>
                        </asp:DropDownList> 
                         <!-- Button to submit changes -->
                         <asp:Button ID="btnChangeSize" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeSize_Click" />
                        
                     </div>
                     <hr />

                     <!-- Allows user to edit the product Category -->
                     <% td.setCurrentFunction("Category"); %>
                     <h5 id="h"> Edit Category </h5>  
                     <div>
                         <!-- displays the product detail, and a drop down if they choose to change the category -->
                         <p> Current:  <%=td.getProduct("name") %> </p><br />
                         <p> Category: </p>
                         <asp:DropDownList ID="changeCategory" runat="server">
                            <asp:ListItem Text="Please select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Clothing" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Accessories" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Home Decor" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Technology" Value="4"></asp:ListItem>
                         </asp:DropDownList>
                         <!-- Button to submit changes -->
                         <asp:Button ID="btnCategory" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeCategory_Click" />
                            
                    </div>
                    <hr />
                    
                    <asp:Button ID="lblDeleteProduct" runat="server" Visible="true" Text="Delete Product" Enabled="true" OnClick="btnDelete_Click" />
                    <br />

                    
             </div>
                 
            </div>
    </div>
</div>
</asp:Content>