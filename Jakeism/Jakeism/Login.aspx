﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Jakeism.Users.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Jakeism | Login</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Login</h2><br />
    <p>Not yet part of the master race? <a href="Register.aspx">Enlist here!</a></p><br />

    <div class="page-left">
      <asp:Panel runat="server" DefaultButton="login">
        <p>User Name</p>
        <asp:TextBox runat="server" ID="usernameField" /><br /><br />
        <p>Password</p>
        <asp:TextBox runat="server" ID="passwordField" TextMode="Password" />
        <asp:Button runat="server" ID="login" Text="Login" OnClick="User_Login" />
        <asp:CheckBox runat="server" ID="remember" Text="Remember me" />
        <br /><br />
        <asp:Label runat="server" ID="fail" Visible="false" ForeColor="Red" />
      </asp:Panel>
    </div>
    <div class="page-right">
        <img src="images/login.png" alt="Login" class="right-context-image" />
    </div>

</asp:Content>
