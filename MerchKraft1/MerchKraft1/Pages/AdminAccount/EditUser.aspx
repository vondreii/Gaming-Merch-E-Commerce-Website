<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="MerchKraft1.Pages.AdminAccount.EditUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - EditUser page -->
<div class="modal-dialog">
         
         <% td.setCurrentItemToDisplay(Int32.Parse(Session["customer"].ToString())); %>

        <div class="modal-content">
            <!-- When the user has already selected 'save changes' this will display. -->
            <div style="padding:10px">
                <h5> <asp:Label ID="changesSavedMessage" runat="server" Visible="false" Text="Changes Saved"> </asp:Label> </h5>  
                <h6><asp:HyperLink ID="goBack" runat="server" Visible="true" NavigateUrl="ManageUserAccounts"> Go back to Manage User Accounts </asp:HyperLink></h6>
                <asp:Label ID="lblError" CssClass="validateMessage" runat="server" Visible="true" Text="Please fix all errors on the page before saving any changes"> </asp:Label>
            </div>
            <!-- Div with Edit User heading -->
            <div class="modal-header">
                <h1 class="text-center">Edit User</h1>
                <h4> Enter the new details of the fields you wish to change. </h4>
                
            </div>
            <!-- Body of form -->
            <div class="modal-body">
                <div class="tbl">

                     <h2> User Details </h2>
                     <hr /> 
                     <!-- Allows admin to edit the first and last name -->
                     <% td.setCurrentFunction("Customers"); %>
                     <h5> Full Name </h5>  
                     <div>
                         <!-- displays the current info, and a first/last name text box if they choose to change it -->
                         <p> Current: <%=td.getUser("firstName") + " " + td.getUser("lastName")%> </p><br />
                         <asp:TextBox ID="changeFirstName" runat="server" placeholder="New first Name"></asp:TextBox>
                         <asp:Button ID="btnFirstName" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeFirst_Click" />
                         <br /><br />
                         <asp:TextBox ID="changeLastName" runat="server" placeholder="New Last Name"></asp:TextBox>
                         <asp:Button ID="btnLastName" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeLast_Click" />
                        
                     </div>
                     <hr />

                     <!-- Allows admin to edit the user's email -->
                     <h5> Email Address </h5>  
                     <div>
                        <!-- displays the current info, and a text box if they choose to change it -->
                        <!-- The dummy data currently displays a customer's email. Because customer registeration
                            does not involve entering an email (like the admin registration, the email is automatically blank. -->
                        <p> Current: <%= td.getUser("emailAddress") %></p><br />
                        <asp:TextBox ID="changeEmail" runat="server" placeholder="New Email Address"></asp:TextBox> 
                        <asp:Button ID="btnEmail" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeEmail_Click" />
                        <!-- Validation for email, checks to see if it is valid -->
                        <p class="validateMessage"><asp:RegularExpressionValidator 
                           ID="revEmail1" runat="server" ErrorMessage="Must be a valid email address" 
                           Display="Dynamic" ValidationExpression= "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                           ControlToValidate="changeEmail">  
                        </asp:RegularExpressionValidator>
                     </div>
                     <hr />

                     <h2> Mailing Address </h2>
                     <hr /> 

                     <% td.setCurrentFunction("MailingAddress"); %>
                     <!-- Allows admin to edit the unit number -->
                     <h5> Unit </h5>  
                     <div>
                        <!-- displays the current info, and a text box if they choose to change it -->
                        <p> Current: <%= td.getUser("unit") %> </p><br />
                        <asp:TextBox ID="changeUnit" runat="server" placeholder="New unit"></asp:TextBox> 
                        <asp:Button ID="btnUnit" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeUnit_Click" />
                     </div>
                     <hr />

                     <!-- Allows admin to edit the Street -->
                     <h5> Street </h5>  
                     <div>
                        <!-- displays the current info, and a text box if they choose to change it -->
                        <p> Current: <%= td.getUser("street") %> </p><br />
                        <asp:TextBox ID="changeStreet" runat="server" placeholder="New street"></asp:TextBox> 
                        <asp:Button ID="btnStreet" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeStreet_Click" />
                     </div>
                     <hr />

                     <!-- Allows admin to edit the Suburb -->
                     <h5> Suburb </h5>  
                     <div>
                        <!-- displays the current info, and a text box if they choose to change it -->
                        <p> Current: <%= td.getUser("suburb") %> </p><br />
                        <asp:TextBox ID="changeSuburb" runat="server" placeholder="New suburb"></asp:TextBox> 
                        <asp:Button ID="btnSuburb" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeSuburb_Click" />
                     </div>
                     <hr />

                     <!-- Allows admin to edit the city -->
                     <h5> City </h5>  
                     <div>
                        <!-- displays the current info, and a text box if they choose to change it -->
                        <p> Current: <%= td.getUser("city") %> </p><br />
                        <asp:TextBox ID="changeCity" runat="server" placeholder="New city"></asp:TextBox> 
                        <asp:Button ID="btnCity" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeCity_Click" />
                     </div>
                     <hr />
                    
                     <!-- Drop down list for state -->
                    <h5> State: </h5> 
                    <p> Current: <%= td.getUser("state") %> </p><br />
                    <asp:DropDownList ID="state" runat="server">
                        <asp:ListItem Text="NSW" Value="1"></asp:ListItem>
                        <asp:ListItem Text="VIC" Value="2"></asp:ListItem>
                        <asp:ListItem Text="QLD" Value="3"></asp:ListItem>
                        <asp:ListItem Text="NT" Value="4"></asp:ListItem>
                        <asp:ListItem Text="SA" Value="5"></asp:ListItem>
                        <asp:ListItem Text="WA" Value="6"></asp:ListItem>
                        <asp:ListItem Text="ACT" Value="7"></asp:ListItem>
                        <asp:ListItem Text="TAS" Value="8"></asp:ListItem>
                     </asp:DropDownList>
                     <asp:Button ID="btnState" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeState_Click" />

                     <h2> Account Details </h2>
                     <hr /> 
                     <% td.setCurrentFunction("CustomerLogins"); %>
                     <!-- Allows admin to edit the username for login -->
                     <h5> Login Username </h5>  
                     <div>
                        <!-- displays the current info, and a text box if they choose to change it -->
                        <p> Current: <%= td.getUser("username") %></p><br />
                        <asp:TextBox ID="changeLoginUsername" runat="server" placeholder="New username"></asp:TextBox> 
                        <asp:Button ID="btnUsername" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangeUsername_Click" />
                     </div>
                     <hr />

                     <!-- Allows admin to edit the password -->
                     <h5> Password </h5>  
                     <div>
                        <!-- displays the current info, and a text box if they choose to change it -->
                        <p> Current: <%= td.getUser("password") %> </p><br />
                        <asp:TextBox ID="changePwd" runat="server" placeholder="New password"></asp:TextBox> 
                        <asp:Button ID="btnPwd" runat="server" Visible="true" Text="Save Changes" Enabled="true" OnClick="btnChangePwd_Click" />
                     </div>
                     <hr />

                     <!-- Cannot edit the customer Account ID -->
                     <h5> Customer Account ID </h5> 
                     <% td.setCurrentFunction("CustomerAccounts"); %>
                     <div>
                        <!-- displays the current info, and a text box if they choose to change it -->
                        <p> Current: <%= td.getUser("customerAccountID") %></p><br />
                        <asp:TextBox ID="changeCustomerAccount" width="250px" runat="server" Enabled="false" Text="Cannot change Customer Account ID"></asp:TextBox> 
                     </div>
                     <hr />

                     <!-- Cannot edit the Join Date -->
                     <h5> Join Date </h5>  
                     <div>
                        <!-- displays the current info, and a text box if they choose to change it -->
                        <p> Current: <%= td.getUser("joinDate") %></p><br />
                        <asp:TextBox ID="changeJoinDate" width="250px" runat="server" Enabled="false" Text="Cannot change join date"></asp:TextBox> 
                     </div>
                     <hr />

                     <!-- Cannot edit number of purchases -->
                     <h5> Number of Purchases </h5>  
                     <div>
                        <!-- displays the current info, and a text box if they choose to change it -->
                        <p> Current: <%= td.getUser("numOfPurchases") %></p><br />
                        <asp:TextBox ID="changeNumberOfPurchases" width="250px" runat="server" Enabled="false" Text="Cannot change number of purchases"></asp:TextBox> 
                     </div>
                     <hr />     

                    <br />
                    
                </div>
          </div>
    </div>
</div>
</asp:Content>

