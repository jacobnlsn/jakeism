<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Jakeism.Users.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <p>User Name</p>
    <asp:TextBox runat="server" ID="usernameField" />
    <p>Password</p>
    <asp:TextBox runat="server" ID="passwordField" TextMode="Password" />
    <asp:Button runat="server" ID="login" Text="Login" OnClick="User_Login" />
    <br />
    <asp:Label runat="server" ID="notFound" />

</asp:Content>
