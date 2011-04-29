<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageComments.aspx.cs" Inherits="Jakeism.Admin.ManageComments" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p><a href="Default.aspx">admin panel</a> > manage comments</p>
    <h2>Manage Entries</h2>

    <br /><br />

    <asp:ListView runat="server" ID="comments">

        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </LayoutTemplate>

        <ItemTemplate>
            <asp:CheckBox runat="server" ID="check" />
            ID: <%# Eval("Id") %><br />
            <%# Eval("CommentBody") %><br />
            Author: <%# Eval("User.UserName") %><br />
            Date: <%# Eval("Date") %><br />
            <asp:Button ID="ModifyCommentButton" runat="server" Text="Modify Comment" OnClick="Modify_Comment" CommandArgument='<%# Eval("Id") %>' />
            <br />
        </ItemTemplate>

        <EmptyDataTemplate>
        <div>No comments</div>
    </EmptyDataTemplate>

    </asp:ListView>

    <asp:Button runat="server" ID="delete" Text="Delete Selected Comments" OnClick="Delete_Comments" />
</asp:Content>
