<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Jakeism._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<asp:ListView runat="server" ID="entries">
        
    <LayoutTemplate>
        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
    </LayoutTemplate>

    <ItemTemplate>
        <h3><a href="/Entries/ViewEntry.aspx?id=<%# Eval("Id") %>">Jakeism #<%# Eval("Id") %></a></h3>
        <p><%# Eval("EntryBody") %></p>
        <p>posted by <a href="/Users/ViewUser.aspx?id=<%# Eval("User.Id") %>"><%# Eval("User.UserName") %></a> on <%# Eval("Date") %> | <a href="/Entries/ViewEntry.aspx?id=<%# Eval("Id") %>#comments"><%# Eval("Comments.Count") %> comments</a></p>
    </ItemTemplate>

    <EmptyDataTemplate>
        <div>No entries</div>
    </EmptyDataTemplate>

</asp:ListView>

</asp:Content>
