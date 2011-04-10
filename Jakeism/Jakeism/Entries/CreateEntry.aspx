<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateEntry.aspx.cs" Inherits="Jakeism.Entries.CreateEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript" src="../scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../scripts/forms.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <asp:Panel runat="server" ID="loggedOut" Visible="true">
      <p>You must be logged in to create an entry.</p>
  </asp:Panel>

  <asp:Panel runat="server" ID="createPanel" Visible="false">
    <h2>Entry</h2>
    <asp:TextBox runat="server" ID="entryBody" Width="500" Height="100" TextMode="MultiLine" CssClass="word_count" />
    <br /><span class="counter"></span><br />
    <asp:Label runat="server" ID="fail" Visible="false" /><br />
    <asp:Button ID="submit" runat="server" Text="Submit" OnClick="Create_Entry" />
  </asp:Panel>

</asp:Content>
