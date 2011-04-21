<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Jakeism._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<asp:ListView runat="server" ID="entries">
        
    <LayoutTemplate>   
        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />     
    </LayoutTemplate>

    <ItemTemplate>
         <div class="entry entry-<%# Eval("Tier") %>">
             <div class="entry-body">
                 <p><%# Eval("EntryBody") %></p>
             </div>
            <div class="entry-vote">
                <div class="vote-left">
                    <a href="#"><img src="images/thumbsup-unclicked-<%# Eval("Tier") %>.gif" alt="Vote Up" /></a>
                </div>
                <div class="vote-right">
                    <span class="votecount"><%# Eval("Votes.Count") %></span>
                </div>
            </div>
            <div class="entry-title">
                <h2><a href="ViewEntry.aspx?id=<%# Eval("Id") %>">Jakeism #<%# Eval("Id") %></a></h2>
            </div>
            <div class="meta">
                <div class="favorite">
                    <a title="Favorite" href="#"><img src="images/favorite-unclicked.png" alt="favorite" /></a>
                </div>
                <div class="info-bar">
                    <p>posted by <a href="ViewUser.aspx?id=<%# Eval("User.Id") %>"><%# Eval("User.UserName") %></a>
                     on <%# Eval("Date") %> | <a href="ViewEntry.aspx?id=<%# Eval("Id") %>#comments">
                     <%# Eval("Comments.Count") %> comments</a></p>
                </div>
            </div>
        </div><!-- end entry --> 
    </ItemTemplate>

    <EmptyDataTemplate>
        <div>No entries</div>
    </EmptyDataTemplate>

</asp:ListView>

</asp:Content>
