<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="Jakeism.Users.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2><asp:Label runat="server" ID="userTitle" /></h2>

<asp:Label runat="server" ID="infolbl" Text="<h2>User Info</h2>" />
<asp:Label runat="server" ID="email" /><br />
<asp:Label runat="server" ID="registered" /><br />

<asp:Label runat="server" ID="entrieslbl" Text="<h2>Entries</h2>" />
<asp:ListView runat="server" ID="entries">
        
    <LayoutTemplate>
        <ul>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </ul>
    </LayoutTemplate>

    <ItemTemplate>
        <li><a id="A1" runat='server' href='<%# String.Format("~/Entries/ViewEntry.aspx?id={0}", Eval("Id")) %>'><%# Eval("Title") %></a></li>
    </ItemTemplate>

    <EmptyDataTemplate>
        <div>No entries</div>
    </EmptyDataTemplate>

</asp:ListView>

<asp:Label runat="server" ID="commentslbl" Text="<h2>Comments</h2>" />
<asp:ListView runat="server" ID="comments">
        
    <LayoutTemplate>
        <ul>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </ul>
    </LayoutTemplate>

    <ItemTemplate>
        <li><a id="A1" runat='server' href='<%# String.Format("~/Entries/ViewEntry.aspx?id={0}&cid={1}", Eval("EntryId"), Eval("CommentId")) %>'><%# Eval("CommentBody") %></a></li>
    </ItemTemplate>

    <EmptyDataTemplate>
        <div>No comments</div>
    </EmptyDataTemplate>

</asp:ListView>

</asp:Content>
