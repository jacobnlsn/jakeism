<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Jakeism.Users.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Users</h2>
    <asp:ListView runat="server" ID="users">
        
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </ul>
        </LayoutTemplate>

        <ItemTemplate>
            <li><a id="A1" runat='server' href='<%# String.Format("~/Users/ViewUser.aspx?id={0}", Eval("Id")) %>'><%# Eval("UserName") %></a></li>
        </ItemTemplate>

        <EmptyDataTemplate>
            <div>No users</div>
        </EmptyDataTemplate>

    </asp:ListView>

</asp:Content>
