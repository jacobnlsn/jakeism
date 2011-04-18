<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageEntries.aspx.cs" Inherits="Jakeism.Admin.ManageEntries" %>
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
    <p><a href="Default.aspx">admin panel</a> > manage entries</p>
    <h2>Manage Users</h2>

    <br /><br />

    <asp:ListView runat="server" ID="entries">

        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </LayoutTemplate>

        <ItemTemplate>
            <asp:CheckBox runat="server" ID="check" />
            ID: <%# Eval("Id") %><br />
            <%# Eval("EntryBody") %><br />
            Author: <%# Eval("User.UserName") %><br />
            Date: <%# Eval("Date") %><br />
            <asp:Button ID="ModifyButton" runat="server" Text="Modify" OnClick="Modify_Entry" CommandArgument='<%# Eval("Id") %>' /><br />
            <br />
        </ItemTemplate>

        <EmptyDataTemplate>
        <div>No entries</div>
    </EmptyDataTemplate>

    </asp:ListView>

    <asp:Button runat="server" ID="delete" Text="Delete Selected Entries" OnClick="Delete_Entries" />
    <asp:Button runat="server" ID="update" Text="Update Selected Entries" OnClick="Update_Entries" />

</asp:Panel>

</asp:Content>
