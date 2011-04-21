<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="Jakeism.Users.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2><asp:Label runat="server" ID="userTitle" /></h2>

<asp:Label runat="server" ID="infolbl" Text="<h2>User Info</h2>" />
<asp:Label runat="server" ID="email" /><br />
<asp:Label runat="server" ID="registered" /><br />

<asp:Label runat="server" ID="entrieslbl" Text="<h2>Jakeisms</h2>" />
<asp:ListView runat="server" ID="entries">
        
    <LayoutTemplate>
        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
    </LayoutTemplate>

    <ItemTemplate>
        <a runat='server' href='<%# String.Format("~/Entries/ViewEntry.aspx?id={0}", Eval("Id")) %>'>Jakeism #<%# Eval("Id") %></a><br />
        <%# Eval("EntryBody") %><br /><br />
    </ItemTemplate>

    <EmptyDataTemplate>
        <div>No entries</div>
    </EmptyDataTemplate>

</asp:ListView>

<asp:Label runat="server" ID="commentslbl" Text="<h2>Comments</h2>" />
<asp:ListView runat="server" ID="comments">
        
    <LayoutTemplate>
        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
    </LayoutTemplate>

    <ItemTemplate>
        <a runat='server' href='<%# String.Format("~/Entries/ViewEntry.aspx?id={0}#comment-{1}", Eval("Entry.Id"), Eval("Id")) %>'>Jakeism #<%# Eval("Entry.Id") %></a><br />
        <%# Eval("CommentBody") %><br /><br />
    </ItemTemplate>

    <EmptyDataTemplate>
        <div>No comments</div>
    </EmptyDataTemplate>

</asp:ListView>

</asp:Content>
