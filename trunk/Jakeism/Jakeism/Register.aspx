<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Jakeism.Users.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Jakeism | Register</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Register</h2><br />
    <p>Already registered? <a href="Login.aspx">Login here!</a></p><br />

    <div class="page-left">
        <p>User Name</p>
        <asp:TextBox runat="server" ID="usernameField" />
        <asp:Label runat="server" ID="badName" ForeColor="Red" Visible="false" Text="User name is already taken" /><br /><br />
        <p>Email Address</p>
        <asp:TextBox runat="server" ID="emailField" />
        <asp:Label runat="server" ID="badEmail" ForeColor="Red" Visible="false" Text="Invalid email address" /><br /><br />
        <p>Password</p>
        <asp:TextBox runat="server" ID="passwordField" TextMode="Password" />
        <asp:Label runat="server" ID="badPassword" ForeColor="Red" Visible="false" Text="Passwords must match" /><br /><br />
        <p>Confirm Password</p>
        <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" />
        <asp:Button runat="server" ID="submit" Text="Submit" OnClick="Register_User" />
    </div>
</asp:Content>
