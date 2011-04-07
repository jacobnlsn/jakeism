<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Jakeism._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <asp:TextBox ID="JakeismEntry" runat="server"></asp:TextBox>
   <asp:Button ID="SubmitEntry" runat="server" Text="Submit" 
        onclick="SubmitEntry_Click" />
        <asp:BulletedList ID="ListOfEntries" runat="server" DataTextField="entryBody">
        </asp:BulletedList>
</asp:Content>
