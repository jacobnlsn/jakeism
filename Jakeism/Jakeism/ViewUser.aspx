<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="Jakeism.Users.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Jakeism | View User</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2><asp:Label runat="server" ID="userTitle" /></h2><br /><br />

    <div class="page-left">
        <asp:Label runat="server" ID="entrieslbl" Text="<h3>Jakeisms</h3>" /><br />
        <asp:ListView runat="server" ID="entries">
        
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </LayoutTemplate>

            <ItemTemplate>
                <a runat='server' href='<%# String.Format("ViewEntry.aspx?id={0}", Eval("Id")) %>'>Jakeism #<%# Eval("Id") %></a><br />
                <%# Eval("EntryBody") %><br /><br />
            </ItemTemplate>

            <EmptyDataTemplate>
                <div>No entries</div>
            </EmptyDataTemplate>

        </asp:ListView>
    </div>

    <div class="page-right">
        <asp:Label runat="server" ID="commentslbl" Text="<h3>Comments</h3>" /><br />
        <asp:ListView runat="server" ID="comments">
        
            <LayoutTemplate>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </LayoutTemplate>

            <ItemTemplate>
                <a runat='server' href='<%# String.Format("ViewEntry.aspx?id={0}#comment-{1}", Eval("Entry.Id"), Eval("Id")) %>'>Jakeism #<%# Eval("Entry.Id") %></a><br />
                <%# Eval("CommentBody") %><br /><br />
            </ItemTemplate>

            <EmptyDataTemplate>
                <div>No comments</div>
            </EmptyDataTemplate>

        </asp:ListView>
    </div>

</asp:Content>
