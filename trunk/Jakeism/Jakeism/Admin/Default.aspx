<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Jakeism.Admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<asp:Panel runat="server" ID="loginPanel">
    <h2><asp:Label runat="server" ID="login" Text="Administrator Login" /></h2>
    <p>Username</p>
    <asp:TextBox runat="server" ID="usernameField" /><br />
    <p>Password</p>
    <asp:TextBox runat="server" ID="passwordField" TextMode="Password" />
    <asp:Label runat="server" ID="fail" Text="Invalid username/password" Visible="false" /><br /><br />
    <asp:Button runat="server" ID="submit" Text="Login" OnClick="Admin_Login" />
</asp:Panel>

<asp:Panel runat="server" ID="adminPanel" Visible="false">
    <h2>Administrator Panel</h2>

    <p><a href="ManageUsers.aspx">Manage Users</a></p>
    <p><a href="ManageEntries.aspx">Manage Entries</a></p>
    <p>Manage Comments</p>

</asp:Panel>

</asp:Content>
