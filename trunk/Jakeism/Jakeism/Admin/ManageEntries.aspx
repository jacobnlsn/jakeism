<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageEntries.aspx.cs" Inherits="Jakeism.Admin.ManageEntries" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p><a href="Default.aspx">admin panel</a> > manage entries</p>
    <h2>Manage Entries</h2>

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
            <asp:Button ID="ViewCommentsButton" runat="server" Text="View Comments" OnClick="View_Comments" CommandArgument='<%# Eval("Id") %>' /><asp:Button ID="ModifyButton" runat="server" Text="Modify" OnClick="Modify_Entry" CommandArgument='<%# Eval("Id") %>' /><br />
            <br />
        </ItemTemplate>

        <EmptyDataTemplate>
        <div>No entries</div>
    </EmptyDataTemplate>

    </asp:ListView>

    <asp:Button runat="server" ID="delete" Text="Delete Selected Entries" OnClick="Delete_Entries" />

</asp:Content>
