<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateEntry.aspx.cs" Inherits="Jakeism.Entries.CreateEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <title>Jakeism | Add Jakeism</title>
    <script type="text/javascript" src="Scripts/forms.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <h2>Submit a Jakeism</h2>

  <asp:Panel runat="server" ID="loggedOut" Visible="true">
      <div class="page-left">
          <br />
          <p>You must be <a href="Login.aspx">logged in</a> to create an entry.</p>
      </div>
      <div class="page-right">
        <img src="images/sadtroll.png" alt="You must be logged in to submit a Jakeism" class="right-context-image" />
    </div>
  </asp:Panel>

  <asp:Panel runat="server" ID="createPanel" Visible="false">
      <div class="page-left">
          <asp:TextBox runat="server" ID="entryBody" TextMode="MultiLine" CssClass="entry-form word_count" />
          <br /><span class="counter"></span><br /><br />
          <asp:Button ID="submit" runat="server" Text="Submit" OnClick="Create_Entry" />
          <asp:Label runat="server" ID="fail" Visible="false" ForeColor="Red" />
      </div> 
      <div class="page-right">
          <p><strong>Wait! Has this Jakeism been submitted before?</strong></p>
          <p>Save yourself some embarrassment and make sure the entry you are submitting has not already been documented by someone else.</p>
      </div>
  </asp:Panel>

</asp:Content>
