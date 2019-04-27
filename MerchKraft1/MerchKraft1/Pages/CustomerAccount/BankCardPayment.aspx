<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BankCardPayment.aspx.cs" Inherits="MerchKraft1.Pages.CustomerAccount.BankCardPayment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="UserContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - BankCardPayment page -->
   <!-- Div to hold contents of page -->
    <asp:Panel ID="container" runat="server" CSSclass="container" style="height:700px">
        
        <h1> Bank Account Payment </h1>
        <p> <a href="../../Default"> Home </a> > <a href="ShoppingCart">Shopping Cart</a> > <a href="Checkout">Checkout</a> > Pay by Bank Account </p>
        <hr />

        <div class="payType">
            <!-- Text box for the user's card number -->
            <asp:TextBox ID="cardNum" runat="server" Height="40" Width="500" TextMode="Number" Font-Size="20" PlaceHolder="Card number"></asp:TextBox><br /><br />
            <!-- Validation for the card number, checks to see if it is blank -->
            <p class="validateMessage"><asp:RequiredFieldValidator 
                ID="rfvCardNum" runat="server" ControlToValidate="cardNum"
                ErrorMessage = "Please enter your Card Number">
            </asp:RequiredFieldValidator></p>

            <!-- Text box for the CVV -->
            <asp:TextBox ID="cardCode" runat="server" Height="40" Width="100" TextMode="Number" Font-Size="20" PlaceHolder="CVV"></asp:TextBox><br /><br />
            <!-- Validation for the CVV -->
            <p class="validateMessage"><asp:RequiredFieldValidator 
                ID="rfvCardCode" runat="server" ControlToValidate="cardCode"
                ErrorMessage = "Please enter your CVV">
            </asp:RequiredFieldValidator></p>

            <!-- Text box for the expiry date -->
            <asp:TextBox ID="expiry" runat="server" Height="40" Width="500" TextMode="Date" Font-Size="20"></asp:TextBox><br />
            <!-- Validation for the Expiry date -->
            <p class="validateMessage"><asp:RequiredFieldValidator 
                ID="rfvExpiry" runat="server" ControlToValidate="expiry"
                ErrorMessage = "Please enter your Expiry date">
            </asp:RequiredFieldValidator></p>

      </div>
     
      
      <h1><asp:Label ID="CardVerified" runat="server" Visible="false" Text="Congratulations, your Bank Card has been successfully verified." /> </h1>
   
      <!-- Button to proceed -->
      <asp:Button ID="btnValidate" runat="server" Visible="true" Text="Verify Card" Enabled="true" OnClick="btnValidate_Click1" />
      <asp:Button ID="btnCardSubmit" runat="server" Visible="false" Text="Make Payment" OnClientClick="window.open('PurchaseConfirmation.aspx', 'self');" />     

    </asp:Panel> 

    <!-- Div to hold contents of page after user has paid (Stops them from selecting 'make payment' again) -->
    <asp:Panel ID="AlreadyPaidView" runat="server" Visible="false" CSSclass="container" style="height:700px">

        <h1> You have already made a payment for this item </h1>
    </asp:Panel> 

</asp:Content>
