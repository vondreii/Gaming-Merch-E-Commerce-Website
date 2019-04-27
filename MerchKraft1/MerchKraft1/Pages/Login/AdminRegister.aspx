<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminRegister.aspx.cs" Inherits="MerchKraft1.Pages.AdminAccount.AdminRegister" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" Visible="false">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - AdminRegister page -->
    <!-- Bootsrap login form https://bootsnipp.com/snippets/GXAAE -->
    <div class="modal-dialog">
        <div class="modal-content">

            <!-- Div with Register heading -->
            <div class="modal-header">
                <h1 class="text-center">Register (as admin)</h1>
            </div>
            <!-- Body of form -->
            <div class="modal-body">

                 <h2> Personal Details </h2>
                 <hr />

                 <!-- *** FIRST NAME *** -->
                 <div class="form-group">
                     <!-- Text box for first name, checks to see if it is blank -->
                     <p> First Name: </p><asp:TextBox ID="firstName" runat="server" placeholder="John"></asp:TextBox> 
                     <!-- Validation for first name, checks to see if it is blank -->
                     <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvFirstName" runat="server" ControlToValidate="firstName"
                        ErrorMessage = "Please enter your first name">
                     </asp:RequiredFieldValidator></p>
                 </div>
                 
                <!-- *** LAST NAME *** -->
                 <div class="form-group">
                    <!-- Text box for first name, checks to see if it is blank -->
                    <p> Last Name: </p><asp:TextBox ID="lastName" runat="server" placeholder="Smith"></asp:TextBox> 
                    <!-- Validation for first name, checks to see if it is blank -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvLastName" runat="server" ControlToValidate="lastName"
                        ErrorMessage = "Please enter your last name">
                    </asp:RequiredFieldValidator></p>
                 </div>

                 <!-- *** DOB *** -->
                 <div class="form-group">
                    <!-- Text box for dob -->
                    <p> Date of birth: </p><asp:TextBox ID="dob" runat="server" placeholder="DD/MM/YYYY"></asp:TextBox> 
                    <!-- Validation for dob, checks to see if it is blank -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvDOB" runat="server" ControlToValidate="dob"
                        ErrorMessage = "Please enter your date of birth">
                     </asp:RequiredFieldValidator></p>
                     <p class="validateMessage"><asp:CompareValidator id="dateValidator" runat="server" 
                        Type="Date" Operator="DataTypeCheck" ControlToValidate="dob" 
                        ErrorMessage="Please enter a valid date.">
                     </asp:CompareValidator></p> 
                 </div>

                 <!-- *** COMPANY ROLE *** -->
                 <div class="form-group">
                    <!-- Text box for dob -->
                    <p> Company Role: </p><asp:TextBox ID="role" runat="server" placeholder="IT consultant"></asp:TextBox> 
                    <!-- Validation for dob, checks to see if it is blank -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvRole" runat="server" ControlToValidate="role"
                        ErrorMessage = "Please enter your company role">
                     </asp:RequiredFieldValidator></p>
                 </div>

                 <h2> Contact Details </h2>
                 <hr />

                 <!-- *** EMAIL ADDRESS *** -->
                 <div class="form-group">
                    <!-- Text box for email address -->
                    <p> Email Address: </p><asp:TextBox ID="email" runat="server" placeholder="cherry123@outlook.com"></asp:TextBox> 
                    <!-- Validation for email, checks to see if it is blank -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvEmail" runat="server" ControlToValidate="email"
                        ErrorMessage = "Please enter your email address">
                     </asp:RequiredFieldValidator></p>
                     <!-- Validation for email, checks to see if it is valid -->
                     <p class="validateMessage"><asp:RegularExpressionValidator 
                        ID="revEmail1" runat="server" ErrorMessage="Must be a valid email address" 
                        Display="Dynamic" ValidationExpression= "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ControlToValidate="email">  
                     </asp:RegularExpressionValidator>

                     <!-- Text box to confirm email address -->
                     <p class="validateMessage"><p> Confirm Email Address: </p><asp:TextBox ID="confirmEmail" runat="server" placeholder="cherry123@outlook.com"></asp:TextBox> 
                     <!-- Validation for email, checks to see if email2 matches email1 -->
                     <p class="validateMessage"><asp:CompareValidator 
                         ID="cvEmail2" runat="server" ControlToValidate="confirmEmail"
                         ControlToCompare="email" Display="Dynamic" 
                         ErrorMessage="Email re-entry"> Must match first email 
                     </asp:CompareValidator>
     
                 </div>

                 <br />
                 <h2> New Username and password </h2>
                 <hr />

                 <!-- *** USERNAME *** -->
                 <div class="form-group">
                    <!-- Text box for username -->
                    <p> Username: </p><asp:TextBox ID="username" runat="server" placeholder="sk123"></asp:TextBox> 
                    <!-- Validation for username, checks to see if it is valid -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvUsername" runat="server" ControlToValidate="username" 
                        ErrorMessage = "Please enter your username">
                     </asp:RequiredFieldValidator></p>      
                 </div>

                <!-- *** PASSWORD *** -->
                 <div class="form-group">
                    <!-- Text box for Password -->
                    <p> Password: </p><asp:TextBox ID="pwd" runat="server" placeholder="*****"></asp:TextBox> 
                    <!-- Validation for Password, checks to see if it is valid -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvPwd" runat="server" ControlToValidate="pwd" 
                        ErrorMessage = "Please enter your password">
                     </asp:RequiredFieldValidator></p>      
                 </div>

                 <br />
                 <div class="form-group">
                     <!-- Button to register -->
                     <asp:Button ID="btnRegister" runat="server" Visible="true" cssClass="btn btn-block btn-lg btn-primary" Text="Register" Enabled="true" OnClick="btnRegister_Click"/>

                     <p> <a href="Register">Register</a> as a customer to purchase items!</p>
                 </div>
             </div>
        </div>
    </div>
</asp:Content>