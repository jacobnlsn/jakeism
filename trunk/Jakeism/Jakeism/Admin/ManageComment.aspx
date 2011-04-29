<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ManageComment.aspx.cs" Inherits="Jakeism.Admin.ManageComment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript" src="../scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../scripts/forms.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label runat="server" ID="title" /><br />
    <h2>Modify Comment</h2>
    <asp:TextBox runat="server" ID="commentBody" Width="500" Height="100" TextMode="MultiLine" CssClass="word_count" />
    <br /><span class="counter"></span><br />
    <asp:Label runat="server" ID="fail" Visible="false" /><br />
    <asp:Button ID="submit" runat="server" Text="Modify" OnClick="Modify_Comment" />

</asp:Content>
