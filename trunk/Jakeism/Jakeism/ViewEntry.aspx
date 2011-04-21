<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewEntry.aspx.cs" Inherits="Jakeism.Entries.ViewEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <script type="text/javascript" src="../scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript" src="../scripts/forms.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<asp:Label runat="server" ID="title" /><br />
<asp:Label runat="server" ID="body" /><br />
<asp:Label runat="server" ID="postedBy" /><br />

<br />

<h3 id="comments"><asp:Label runat="server" ID="commentslbl" Text="Comments" /></h3>
<asp:ListView runat="server" ID="commentsList">
        
    <LayoutTemplate>
        <ul>
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </ul>
    </LayoutTemplate>

    <ItemTemplate>
        <li><%# Eval("CommentBody") %> -<a id="A1" runat='server' href='<%# String.Format("~/Users/ViewUser.aspx?id={0}", Eval("User.Id")) %>'><%# Eval("User.UserName") %></a> (<a href="#comment-<%# Eval("Id") %>" id="#comment-<%# Eval("Id") %>"><%# Eval("Date") %></a>)</li>
    </ItemTemplate>

    <EmptyDataTemplate>
        <div>No comments</div>
    </EmptyDataTemplate>

</asp:ListView>

<br />

<asp:Panel runat="server" ID="commentPanel" Visible="false">
    <asp:Label runat="server" ID="addCommentlbl" Text="Add Comment" /><br />
    <asp:TextBox runat="server" ID="commentBox" Width="300" Height="75" TextMode="MultiLine" CssClass="word_count" />
    <br /><span class="counter"></span><br />
    <asp:Label runat="server" ID="fail" Visible="false" /><br />
    <asp:Button runat="server" ID="submit" Text="Submit Comment" OnClick="Submit_Comment" />
</asp:Panel>

</asp:Content>
