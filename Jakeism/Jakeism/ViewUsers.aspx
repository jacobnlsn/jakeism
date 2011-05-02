<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="Jakeism.ViewUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Jakeism | Users</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Users</h2><br />

    <asp:ListView runat="server" ID="userList">

        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" /> 
        </LayoutTemplate>

        <ItemTemplate>
            <a title="View User" href="ViewUser.aspx?id=<%# Eval("Id") %>"><%# Eval("UserName") %></a><br /><br />
        </ItemTemplate>

        <EmptyDataTemplate>
            <div><p>No users</p></div>
        </EmptyDataTemplate>

    </asp:ListView>

</asp:Content>
