<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TopEntries.aspx.cs" Inherits="Jakeism.TopEntries" EnableEventValidation="false" %>
<%@ Register TagPrefix="custom" TagName="EntryList" Src="~/EntryList.ascx" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Jakeism | Top Jakeisms</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Top Jakeisms</h2><br />
    <custom:EntryList runat="server" ID="entryList" /> 

</asp:Content>
