<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Profile.aspx.cs" Inherits="MerchKraft1.Pages.Profile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="UserContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - Profile page -->

    <!-- Div to hold contents of page -->
    <div class="container">
        
       <h1> Welcome, <asp:Label ID="lblUsername" runat="server" Text="" Visible="true"></asp:Label> </h1>
       <hr />
       <% td.setCurrentFunction("CustomerProfile_Customer"); %>

       <h3> Your Personal Details: </h3>
       <div style="width:400px">
            <p> Full Name: <%= td.getCustomerProfiles("firstName") + " " + td.getCustomerProfiles("lastName") %> </p>
            <p> Email Address: <%= td.getCustomerProfiles("emailAddress")  %> </p>
            <hr />   
        </div>

        <% td.setCurrentFunction("CustomerProfile_CustomerAccount"); %>

        <h3> Your Account Details: </h3>
        <div style="width:400px">
            <p> Join Date <%= td.getCustomerProfiles("joinDate") %> </p>

            <% td.setCurrentFunction("CustomerProfile_Login"); %>

            <p> Login: <%= td.getCustomerProfiles("username") %> </p>
            <p> Password: <%= td.getCustomerProfiles("password") %> </p>
            <hr />  
        </div>

        <% td.setCurrentFunction("CustomerProfile_Mailing"); %>

        <h3> Your Mailing Address: </h3>
        <div style="width:400px">
            <p> Unit: <%= td.getCustomerProfiles("unit") %> </p>
            <p> Street: <%= td.getCustomerProfiles("street") %> </p>
            <p> Suburb: <%= td.getCustomerProfiles("suburb") %> </p>
            <p> City: <%= td.getCustomerProfiles("city") %> </p>
            <p> State: <%= td.getCustomerProfiles("state") %> </p>
            <p> Country: <%= td.getCustomerProfiles("country") %> </p>
            <p> Postcode: <%= td.getCustomerProfiles("postcode") %> </p>
            <hr />  

            <a href="EditProfile"><div class="addToCartButton">Update Profile </div></a>
            <a href="../CustomerAccount/PurchasedItems"><div class="addToCartButton">View Purchased Items</div></a>
        </div>

    </div>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminContent" runat="server">
    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - Profile page -->

    <!-- Div to hold contents of page -->
    <div class="container">
       <h1> Welcome, <asp:Label ID="lblUser2" runat="server" Text="" Visible="true"></asp:Label> </h1>
       <hr />
       <h2> User Details </h2>
       <hr /> 
       <!-- Allows admin to edit the first and last name -->

       <% td.setCurrentFunction("AdminProfile_Admin"); %>
       <h3> Your Personal Details: </h3>
       <div style="width:400px">
            <p> Full Name: <%= td.getAdminProfiles("firstName") + " " + td.getAdminProfiles("lastName") %> </p>
            <p> Email Address: <%= td.getAdminProfiles("emailAddress")  %> </p>
       <hr />   
       </div>

        <% td.setCurrentFunction("AdminProfile_AdminAccount"); %>

        <h3> Your Account Details: </h3>
        <div style="width:400px">
            <p> Join Date <%= td.getAdminProfiles("joinDate") %> </p>
            <p> Company Role <%= td.getAdminProfiles("companyRole") %> </p>
            <p> Last Accessed: <%= td.getAdminProfiles("lastAccessed") %> </p>
            <p> Change Log: <%= td.getAdminProfiles("changeLog") %> </p>

            <% td.setCurrentFunction("AdminProfile_Login"); %>

            <p> Login: <%= td.getAdminProfiles("username") %> </p>
            <p> Password: <%= td.getAdminProfiles("password") %> </p>
            <hr />   


        </div>
           

    </div>

</asp:Content>


