<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Jakeism.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Jakeism | Error</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-left">
        <h3>Woops</h3><br />
        <p>The server understood the request but is refusing to fulfill it. <span class="bold">Problem?</span></p><br />
        <p>4 Help, ask <a href="http://jakeism.info/kiran">Kiran</a></p>
    </div>
    <div class="page-right">
        <img src="images/trollface.png" alt="Problem?" class="right-context-image" />
    </div>
</asp:Content>
