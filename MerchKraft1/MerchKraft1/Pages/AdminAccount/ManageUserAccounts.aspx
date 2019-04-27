<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUserAccounts.aspx.cs" Inherits="MerchKraft1.Pages.AdminAccount.ManageUserAccounts" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">

    <!-- INFT3050 - ASSIGNMENT PART 1 
        - MERCHKRAFT by Sora (3197198) and Sharlene (3220929)
        - ManageUserAccounts page -->
    <!-- Container that holds all the content of the page -->

    <div class="container">
        
        <!-- Manage User Accounts Page - Lists all customer and admins and their details -->
        <h1> Manage User Accounts </h1>

        <!-- Lists all Customers -->
        <h4> All Customer Accounts </h4>
        <hr />

        <!-- div that displays all customers that are in the db -->
        <div style="width:400px">   

            <!-- For every Customer in the Database -->
            <% for (int i = 0; i < td.returnNoOfCustomers(); i++) { %> 

                <% td.setCurrentItemToDisplay(i); %>

                <!-- Display customer name & details -->
                <% td.setCurrentFunction("Customers"); %>
                <h3><%=td.getUser("firstName") %> <%=td.getUser("lastName") %> </h3>
                <br />

                <h5> Personal Details </h5>
                <p> Date of Birth: <%=td.getUser("dateOfBirth") %> </p>
                <p> CustomerID: <%=td.getUser("customerID") %></p>
                <p> Email: <%=td.getUser("emailAddress") %></p>
                <br />
                <!-- Display the corresponding Customer Account -->
                <h5> Customer Account Details </h5>
                <% td.setCurrentFunction("CustomerAccounts"); %>
                <p> Customer Account ID: <%=td.getUser("customerAccountID") %> </p>
                <p> Join Date: <%=td.getUser("joinDate") %> </p>
                <p> Number of Purchases: <%=td.getUser("numOfPurchases") %> </p>
                <br />
                <!-- Display the corresponding MailingAddress Information -->
                <h5> Mailing Address </h5>
                <% td.setCurrentFunction("MailingAddress"); %>
                <p> Unit: <%=td.getUser("unit") %> </p>
                <p> Street: <%=td.getUser("street") %> </p>
                <p> Suburb: <%=td.getUser("suburb") %> </p>
                <p> City: <%=td.getUser("city") %> </p>
                <p> State: <%=td.getUser("state") %> </p>
                <p> Country: <%=td.getUser("country") %> </p>
                <p> Postcode: <%=td.getUser("postcode") %> </p>
                <br />
                <!-- Display the corresponding Login Details -->
                <h5> Login Details </h5>
                <% td.setCurrentFunction("CustomerLogins"); %>
                <p> Login: <%= td.getUser("username") %> </p>
                <p> Password: <%= td.getUser("password") %> </p>

                <!-- Link to edit product -->
                <!-- <a href="EditProduct"><div class="addToCartButton">Edit Product</div></a> -->
                <a href="../SessionHandler.aspx?customer=<%=i%>&product=-1"><div class="addToCartButton">Update Details</div></a>
                <hr />
            <% } %>

        </div>
        <br /><br />

        <!-- Lists all admins -->
        <h4> All Admin Accounts </h4>
        <hr />

        <!-- div that displays all admins that are in the db -->
        <div style="width:400px">

            <% td.setCurrentFunction("Customers"); %>

            <!-- For every Admin in the Database -->
            <!-- Display admin name & details -->
            <h5> You cannot change your fellow admin's details. </h5>
            <br />
            <% for (int i = 0; i < td.returnNoOfAdmins(); i++)  { %> 

                <% td.setCurrentItemToDisplay(i); %>

                <!-- Display admin name & details -->
                <% td.setCurrentFunction("Admins"); %>
                <h5><%=td.getUser("firstName") %> <%=td.getUser("lastName") %> </h5>
                <p> Date of Birth: <%=td.getUser("dateOfBirth") %> </p>      
                <p> Email: <%=td.getUser("emailAddress") %></p>

                <!-- Display the corresponding Admin Account -->
                <p> AdminID: <%=td.getUser("adminID") %></p>
                <p> AdminAccountID: <%=td.getUser("adminAccountID") %></p>

                <% td.setCurrentFunction("AdminAccounts"); %>
                <p> Join Date: <%=td.getUser("joinDate") %> </p>
                <p> Last Accessed: <%=td.getUser("lastAccessed") %> </p>
                <p> Change Log: <%=td.getUser("changeLog") %> </p>
                <p> Company Role: <%=td.getUser("companyRole") %> </p>
                <br />

            <% } %>

        </div>

    </div>

</asp:Content>
