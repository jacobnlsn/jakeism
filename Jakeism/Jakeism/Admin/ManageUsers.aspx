<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Jakeism.Admin.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

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

            <asp:TemplateField HeaderText="Username">
                <ItemTemplate><asp:TextBox runat="server" ID="username" Text='<%# Eval("UserName") %>' /></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate><asp:TextBox runat="server" ID="email" Text='<%# Eval("Email") %>' /></ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField
                HeaderText="Date Registered"
                DataField="DateRegistered" />

            <asp:TemplateField HeaderText="Entries">
                <ItemTemplate><%# Eval("Entries.Count") %></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Comments">
                <ItemTemplate><asp:LinkButton ID="CommentsButton" runat="server" OnClick="View_Comments" CommandArgument='<%# Eval("Id") %>'><%# Eval("Comments.Count") %></asp:LinkButton></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Votes">
                <ItemTemplate><%# Eval("Votes.Count") %></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Admin">
                <ItemTemplate><center><asp:CheckBox ID="IsAdmin" runat="server" Checked='<%# Eval("IsAdmin") %>' /></center></ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Password">
                <ItemTemplate><asp:TextBox runat="server" ID="password" TextMode="Password" /></ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

    <asp:Button runat="server" ID="delete" Text="Delete Selected Users" OnClick="Delete_Users" />
    <asp:Button runat="server" ID="update" Text="Update Selected Users" OnClick="Update_Users" />

</asp:Content>
