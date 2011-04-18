﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Jakeism.Admin.ManageUsers" %>
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
    <p><a href="Default.aspx">admin panel</a> > manage users</p>
    <h2>Manage Users</h2>
    <br />
    <asp:TextBox runat="server" ID="username" Text="Username" />
    <asp:TextBox runat="server" ID="email" Text="Email" />
    <asp:TextBox runat="server" ID="password" Text="Password" TextMode="Password" />
    <asp:CheckBox runat="server" ID="isAdmin" Text="Admin" />
    <asp:Button runat="server" ID="createUser" Text="Create User" OnClick="Create_User" />

    <br /><br />

    <asp:GridView
        runat="server"
        ID="users"
        OnRowEditing="GridView_RowEditing"
        OnRowCancelingEdit="GridView_RowCancelingEdit"
        OnRowUpdating="GridView_RowUpdating"
        AutoGenerateColumns="false">
        
        <Columns>
            <asp:TemplateField>
                <ItemTemplate><asp:CheckBox runat="server" ID="check" /></ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField
                HeaderText="ID"
                DataField="Id" />

            <asp:BoundField
                HeaderText="Username"
                DataField="UserName" />

            <asp:BoundField
                HeaderText="Email"
                DataField="Email" />

            <asp:BoundField
                HeaderText="Date Registered"
                DataField="DateRegistered" />

            <asp:TemplateField HeaderText="Entries">
                <ItemTemplate><%# Eval("Entries.Count") %></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Comments">
                <ItemTemplate><%# Eval("Comments.Count") %></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Votes">
                <ItemTemplate><%# Eval("Votes.Count") %></ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField
                HeaderText="Admin"
                DataField="IsAdmin" />

            <asp:TemplateField HeaderText="Password">
                <ItemTemplate><asp:TextBox runat="server" ID="password" TextMode="Password" /></ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

    <asp:Button runat="server" ID="delete" Text="Delete Selected Users" OnClick="Delete_Users" />
    <asp:Button runat="server" ID="update" Text="Update Selected Users" OnClick="Update_Users" />

</asp:Panel>

</asp:Content>