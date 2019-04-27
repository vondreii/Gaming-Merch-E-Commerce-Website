<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PayPalPayment.aspx.cs" Inherits="MerchKraft1.Pages.CustomerAccount.PayPalPayment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="UserContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - PayPalPayment page -->

   <!-- Div to hold contents of page -->
    <div class="container" style="height:700px">
        
        <h1> PayPal Payment </h1>
        <p> <a href="../../Default"> Home </a> > <a href="ShoppingCart">Shopping Cart</a> > <a href="Checkout">Checkout</a> > Pay by PayPal</p>
        <hr />

        <div class="payType">

                <!-- Text box for the paypal email -->
                <asp:TextBox ID="paypalEmail" runat="server" Height="40" Width="500" TextMode="Email" Font-Size="20" PlaceHolder="email"></asp:TextBox>
                <!-- Validation for the paypal email, checks to see if it is blank -->
                <p class="validateMessage"><asp:RequiredFieldValidator 
                    ID="rfvPaypalEmail1" runat="server" ControlToValidate="paypalEmail"
                    ErrorMessage = "Please enter your Paypal Email">
                </asp:RequiredFieldValidator></p>
                <!-- Validation for paypal email, checks to see if it is valid -->
                <p class="validateMessage"><asp:RegularExpressionValidator 
                    ID="revEmail1" runat="server" ErrorMessage="Must be a valid email address" 
                    Display="Dynamic" ValidationExpression= "\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="paypalEmail">  
                </asp:RegularExpressionValidator>

                <!-- Text box for the paypal password -->
                <asp:TextBox ID="paypalPassword" runat="server" Height="40" Width="500" Font-Size="20" PlaceHolder="password"></asp:TextBox>
                <!-- Validation for the password, checks to see if it is blank -->
                <p class="validateMessage"><asp:RequiredFieldValidator 
                    ID="rfvPaypalPassword" runat="server" ControlToValidate="paypalPassword"
                    ErrorMessage = "Please enter your Paypal Password">
                </asp:RequiredFieldValidator></p>
          </div>      
         
          <h1> <asp:Label ID="PayPalVerified" runat="server" Visible="false" Text="Congratulations, your Pay Pal Account has been successfully verified." /> </h1>
          <!-- Button to proceed -->
          <asp:Button ID="btnValidate" runat="server" Visible="true" Text="Verify PayPal Account" Enabled="true" OnClick="btnValidate_Click1" />

          <asp:Button ID="btnPayPalSubmit" runat="server" Visible="false" Text="Make Payment" OnClientClick="window.open('PurchaseConfirmation.aspx', 'PurchaseConfirmation');" />
        
    </div> 

</asp:Content>
