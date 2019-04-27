<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MerchKraft1.Pages.Login.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - Register page -->
    <!-- Bootsrap login form https://bootsnipp.com/snippets/GXAAE -->
    <div class="modal-dialog">
<div class="modal-content">

            <!-- Div with Register heading -->
            <div class="modal-header">
                <h1 class="text-center">Register</h1>
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
                    <!-- Text box for last name, checks to see if it is blank -->
                    <p> Last Name: </p><asp:TextBox ID="lastName" runat="server" placeholder="Smith"></asp:TextBox> 
                    <!-- Validation for last name, checks to see if it is blank -->
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
                    <!-- Makes sure dob is a valid date -->
                     </asp:RequiredFieldValidator></p>
                     <p class="validateMessage"><asp:CompareValidator id="dateValidator" runat="server" 
                        Type="Date" Operator="DataTypeCheck" ControlToValidate="dob" 
                        ErrorMessage="Please enter a valid date.">
                     </asp:CompareValidator></p> 
                 </div>

                 <h2> Mailing Address </h2>
                 <hr />

                 <!-- *** UNIT *** -->
                 <div class="form-group">
                    <!-- Text box for unit -->
                    <p> Unit or Number: </p><asp:TextBox ID="num" runat="server" placeholder="81"></asp:TextBox> 
                    <!-- Validation for unit, checks to see if it is valid -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvNum" runat="server" ControlToValidate="num" 
                        ErrorMessage = "Please enter your unit">
                     </asp:RequiredFieldValidator></p>
                     <!-- Validation for unit, checks to see if it is > 0-->
                     <p class="validateMessage"><asp:CompareValidator 
                        ID="cvNum" runat="server" ControlToValidate="num" 
                        Type="Integer" Operator="GreaterThan" ValueToCompare="0" 
                        ErrorMessage="Invalid Unit"> 
                     </asp:CompareValidator></p>
                 </div>

                 <!-- *** STREET *** -->
                 <div class="form-group">
                    <!-- Text box for street -->
                    <p> Street: </p><asp:TextBox ID="street" runat="server" placeholder="Lenovo Street"></asp:TextBox> 
                    <!-- Validation for street, checks to see if it is blank -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvStreet" runat="server" ControlToValidate="street"
                        ErrorMessage = "Please enter your street name">
                     </asp:RequiredFieldValidator></p>
                 </div>

                 <!-- *** SUBURB *** -->
                 <div class="form-group">
                    <!-- Text box for suburb -->
                    <p> Suburb: </p><asp:TextBox ID="suburb" runat="server" placeholder="Callaghan"></asp:TextBox> 
                    <!-- Validation for suburb, checks to see if it is blank -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvSuburb" runat="server" ControlToValidate="suburb"
                        ErrorMessage = "Please enter your suburb">
                     </asp:RequiredFieldValidator></p>
                 </div>

                <!-- *** CITY *** -->
                 <div class="form-group">
                    <!-- Text box for city -->
                    <p> City: </p><asp:TextBox ID="city" runat="server" placeholder="Newcastle"></asp:TextBox> 
                    <!-- Validation for city, checks to see if it is blank -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvCity" runat="server" ControlToValidate="city"
                        ErrorMessage = "Please enter your city">
                     </asp:RequiredFieldValidator></p>
                 </div>

                <!-- *** STATE *** -->
                 <div class="form-group">
                    <!-- Drop down list for state -->
                    <p> State: </p> 
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
                    
                 </div>

                 <!-- *** POSTCODE *** -->
                 <div class="form-group">
                    <!-- Text box for postcode -->
                    <p> Postcode: </p><asp:TextBox ID="postcode" runat="server" placeholder="2256"></asp:TextBox> 
                    <!-- Validation for age, checks to see if it is blank -->
                    <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvPostcode" runat="server" ControlToValidate="postcode"
                        ErrorMessage = "Please enter your postcode">
                     </asp:RequiredFieldValidator></p>
                     <!-- Validation for age, checks to see if it is > 999 -->
                     <p class="validateMessage"><asp:CompareValidator 
                        ID="cvPostcode" runat="server" ControlToValidate="postcode" 
                        Type="Integer" Operator="GreaterThan" ValueToCompare="999" 
                        ErrorMessage="Invalid postcode. Must be 4 characters (> 999 and < 10000)"> 
                     </asp:CompareValidator></p>
                     <!-- Validation for age, checks to see if it is < 10000 -->
                     <p class="validateMessage"><asp:CompareValidator 
                        ID="CompareValidator1" runat="server" ControlToValidate="postcode" 
                        Type="Integer" Operator="LessThan" ValueToCompare="10000" 
                        ErrorMessage="Invalid postcode. Must be 4 characters (> 999 and < 10000)">  
                     </asp:CompareValidator></p>
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

                 <div class="form-group">
                     <!-- Submit register button -->

                     <!-- Button to register -->
                     <asp:Button ID="btnRegister" runat="server" Visible="true" cssClass="btn btn-block btn-lg btn-primary" Text="Register" Enabled="true" OnClick="btnRegister_Click"/>
                   
                     <p>Want to Login? <a href="Login">Click here!</a></p>
                     <p> <a href="AdminRegister">Admin Registration</a></p>
                 </div>
             </div>
        </div>
    </div>
</asp:Content>
