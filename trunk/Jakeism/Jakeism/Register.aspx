<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Jakeism.Users.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Register</h2>
    <p>User Name</p>
    <asp:TextBox runat="server" ID="usernameField" />
    <p>Email Address</p>
    <asp:TextBox runat="server" ID="emailField" />
    <p>Password</p>
    <asp:TextBox runat="server" ID="passwordField" TextMode="Password" />
    <p>Confirm Password</p>
    <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" />
    <asp:Button runat="server" ID="submit" Text="Submit" OnClick="Register_User" />
</asp:Content>
