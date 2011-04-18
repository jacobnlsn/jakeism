<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Jakeism.Admin.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><asp:Label runat="server" ID="login" Text="Administrator Login" /></h2>
    <p>Username</p>
    <asp:TextBox runat="server" ID="usernameField" /><br />
    <p>Password</p>
    <asp:TextBox runat="server" ID="passwordField" TextMode="Password" />
    <asp:Label runat="server" ID="fail" Text="Invalid username/password" Visible="false" /><br /><br />
    <asp:Button runat="server" ID="submit" Text="Login" OnClick="Admin_Login" />

</asp:Content>
