<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateEntry.aspx.cs" Inherits="Jakeism.Entries.CreateEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <asp:Panel runat="server" ID="loggedOut" Visible="true">
      <p>You must be logged in to create an entry.</p>
  </asp:Panel>

  <asp:Panel runat="server" ID="createPanel" Visible="false">
    <h2>Entry</h2>
    <asp:TextBox runat="server" ID="entryBody" Width="500" Height="100" TextMode="MultiLine" />
    <br />
    <asp:Label runat="server" ID="noText" Text="Entry field may not be empty" Visible="false" />
    <asp:Button ID="submit" runat="server" Text="Submit" OnClick="Create_Entry" />
  </asp:Panel>

</asp:Content>
