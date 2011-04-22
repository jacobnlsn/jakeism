<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="Jakeism.Users.EditProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Jakeism | Edit Profile</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <asp:Panel runat="server" ID="loggedOut" Visible="true">
      <p>You must be <a href="Login.aspx">logged in</a> to edit your profile.</p>
  </asp:Panel>

  <asp:Panel runat="server" ID="editPanel" Visible="false">

    <h2>Edit Profile</h2><br />

    <p>Email Address</p>
    <asp:TextBox runat="server" ID="emailField" /><br /><br />

    <p>Password</p>
    <asp:TextBox runat="server" ID="passwordField" TextMode="Password" /><br /><br />

    <p>Confirm Password</p>
    <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" />
    <asp:Label runat="server" ID="matchfail" Text="Passwords must match" ForeColor="Red" Visible="false" />

    <br /><br />

    <asp:Button runat="server" ID="submit" OnClick="Edit_User" Text="Update" />

  </asp:Panel>

</asp:Content>
