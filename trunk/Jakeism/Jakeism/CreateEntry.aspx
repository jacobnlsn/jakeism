<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateEntry.aspx.cs" Inherits="Jakeism.Entries.CreateEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript" src="Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="Scripts/forms.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <h2>Submit a Jakeism</h2>

  <asp:Panel runat="server" ID="loggedOut" Visible="true">
      <br />
      <p>You must be logged in to create an entry.</p>
  </asp:Panel>

  <asp:Panel runat="server" ID="createPanel" Visible="false">
      <div id="page-left">
          <asp:TextBox runat="server" ID="entryBody" TextMode="MultiLine" CssClass="entry-form word_count" />
          <br /><span class="counter"></span><br /><br />
          <asp:Button ID="submit" runat="server" Text="Submit" OnClick="Create_Entry" />
          <asp:Label runat="server" ID="fail" Visible="false" ForeColor="Red" />
      </div> 
      <div id="page-right">
          <p><strong>Wait! Has this Jakeism been submitted before?</strong></p>
          <p>Save yourself some embarrassment and make sure the entry you are submitting has not already been documented by someone else.</p>
      </div>
  </asp:Panel>

</asp:Content>
