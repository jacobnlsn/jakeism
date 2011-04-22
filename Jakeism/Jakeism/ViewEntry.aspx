<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewEntry.aspx.cs" Inherits="Jakeism.Entries.ViewEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <title>Jakeism | View Entry</title>
    <script type="text/javascript" src="scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="scripts/forms.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="entry entry-<%= Tier %>">
    <div class="entry-body">
        <p><asp:Label runat="server" ID="body" /></p>
    </div>
    <div class="entry-vote">
        <div class="vote-left">
            <a href="#"><img src="images/thumbsup-unclicked-<%= Tier %>.gif" alt="Vote Up" /></a>
        </div>
        <div class="vote-right">
            <span class="votecount"><%= Votes %></span>
        </div>
    </div>
    <div class="entry-title">
        <h2><asp:Label runat="server" ID="title" /></h2>
    </div>
    <div class="meta">
        <div class="favorite">
            <a title="Favorite" href="#"><img src="images/favorite-unclicked.png" alt="favorite" /></a>
        </div>
        <div class="info-bar">
            <p><asp:Label runat="server" ID="postedBy" /></p>
        </div>
    </div>
</div>

<br />

<h3 id="comments"><asp:Label runat="server" ID="commentslbl" Text="Comments" /></h3>
<asp:ListView runat="server" ID="commentsList">
        
    <LayoutTemplate>
        <div id="comments-wrapper">
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </div>
    </LayoutTemplate>

    <ItemTemplate>
        <div class="comment">
          <div class="comment-body">
            <p><%# Eval("CommentBody") %></p>
          </div>
            <div class="comment-meta">
                <a id="A1" runat='server' href='<%# String.Format("ViewUser.aspx?id={0}", Eval("User.Id")) %>'><%# Eval("User.UserName") %></a> on <a href="#comment-<%# Eval("Id") %>" id="#comment-<%# Eval("Id") %>"><%# Eval("Date") %></a>
            </div>
        </div>
    </ItemTemplate>

    <AlternatingItemTemplate>
        <div class="comment-alt">
          <div class="comment-body">
            <p><%# Eval("CommentBody") %></p>
          </div>
            <div class="comment-meta">
                <a id="A1" runat='server' href='<%# String.Format("ViewUser.aspx?id={0}", Eval("User.Id")) %>'><%# Eval("User.UserName") %></a> on <a href="#comment-<%# Eval("Id") %>" id="#comment-<%# Eval("Id") %>"><%# Eval("Date") %></a>
            </div>
        </div>
    </AlternatingItemTemplate>

    <EmptyDataTemplate>
        <div>No comments</div>
    </EmptyDataTemplate>

</asp:ListView>

<br />

<asp:Panel runat="server" ID="commentPanel" Visible="false">
  <div class="left">
    <div id="addcomment">
        <span class="bold"><asp:Label runat="server" ID="addCommentlbl" Text="Add Comment" /></span><br />
        <asp:TextBox runat="server" ID="commentBox" Width="395" Height="75" TextMode="MultiLine" CssClass="word_count" />
        <br /><span class="counter"></span><br />
        <asp:Label runat="server" ID="fail" Visible="false" /><br />
        <asp:Button runat="server" ID="submit" Text="Submit Comment" OnClick="Submit_Comment" />
    </div>
  </div>
</asp:Panel>

</asp:Content>
