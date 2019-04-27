<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MerchKraft1.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - Login page -->
    <!-- Bootsrap login form https://bootsnipp.com/snippets/GXAAE -->
    userNum: <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    userName: <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            
    <div class="modal-dialog">
        <div class="modal-content">
              <h1 class="text-center">Login</h1>
             <div class="modal-body">
                 <div class="form-group">
                     <asp:TextBox ID="username" runat="server" PlaceHolder="username"></asp:TextBox> 
                     <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvUsername" 
                        runat="server"
                        ControlToValidate="username"
                        ErrorMessage = "Please enter your username" >
                     </asp:RequiredFieldValidator></p>
                 </div>

                 <div class="form-group">
                     <asp:TextBox ID="pwd" runat="server" TextMode="Password" PlaceHolder="password"></asp:TextBox>
                     <p class="validateMessage"><asp:RequiredFieldValidator 
                        ID="rfvPwd" 
                        runat="server"
                        ControlToValidate="pwd"
                        ErrorMessage = "Please enter your password">
                     </asp:RequiredFieldValidator></p>

                 </div>
                 <br />
                 <div class="form-group">

                     <!--<input type="submit" onsubmit="../../default" class="btn btn-block btn-lg btn-primary" value="Login"/>-->
                     <asp:Button ID="loginButton" CssClass="btn btn-block btn-lg btn-primary" runat="server" Text="Login" OnClick="loginButton_Click"  /><br />
                     <asp:Label ID="incorrectLabel" runat="server" Text="" Style="color:red"></asp:Label>
                     <p>Want to register? <a href="Register">Click here!</a></p>
                     <!--
                     <span class="pull-right"><a href="Register">Register</a></span><span><a href="#">Forgot Password</a></span>
                     -->

                 </div>

                 
             </div>
        </div>

        <div style="height:100px"></div>
    </div>

</asp:Content>


