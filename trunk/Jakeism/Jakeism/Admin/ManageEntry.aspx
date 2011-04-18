<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageEntry.aspx.cs" Inherits="Jakeism.Admin.ManageEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript" src="../scripts/forms.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<asp:Panel runat="server" ID="loginPanel">
    <h2><asp:Label runat="server" ID="login" Text="Administrator Login" /></h2>
    <p>Username</p>
    <asp:TextBox runat="server" ID="usernameField" /><br />
    <p>Password</p>
    <asp:TextBox runat="server" ID="passwordField" TextMode="Password" />
    <asp:Label runat="server" ID="Label1" Text="Invalid username/password" Visible="false" /><br /><br />
    <asp:Button runat="server" ID="Button1" Text="Login" OnClick="Admin_Login" />
</asp:Panel>

<asp:Panel runat="server" ID="modifyPanel" Visible="false">
    <asp:Label runat="server" ID="title" /><br />
    <h2>Modify Entry</h2>
    <asp:TextBox runat="server" ID="entryBody" Width="500" Height="100" TextMode="MultiLine" CssClass="word_count" />
    <br /><span class="counter"></span><br />
    <asp:Label runat="server" ID="fail" Visible="false" /><br />
    <asp:Button ID="submit" runat="server" Text="Modify" OnClick="Modify_Entry" />
  </asp:Panel>

</asp:Content>
