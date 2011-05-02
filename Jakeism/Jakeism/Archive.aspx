<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Archive.aspx.cs" Inherits="Jakeism.Archive" EnableEventValidation="false" %>
<%@ Register TagPrefix="custom" TagName="EntryList" Src="~/EntryList.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Jakeism | The Archive</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div class="left">
       <h2>The Archive</h2>
   </div>
   <asp:UpdatePanel runat="server" ID="archivePanel">
       <ContentTemplate>
           <div class="right">
               Sort By: 
               <asp:DropDownList runat="server" ID="sortList" OnSelectedIndexChanged="Sort_Changing" AutoPostBack="true">
                   <asp:ListItem Selected="True" Text="Date" Value="Date" />
                   <asp:ListItem Text="Votes" Value="Votes" />
                   <asp:ListItem Text="Favorites" Value="Favorites" />
                   <asp:ListItem Text="Comments" Value="Comments" />
                   <asp:ListItem Text="User" Value="User" />
               </asp:DropDownList>
           </div>
           <div class="left">
               <custom:EntryList runat="server" ID="entryList" />  
           </div>
       </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>
