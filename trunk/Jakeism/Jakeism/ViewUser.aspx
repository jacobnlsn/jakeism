<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUser.aspx.cs" Inherits="Jakeism.Users.ViewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Jakeism | View User</title>
    <script type="text/javascript" src="Scripts/tabs.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2><asp:Label runat="server" ID="userTitle" /></h2><br /><br />

  <asp:Panel runat="server" ID="userPanel">

    <div class="tabs">

        <ul class="tabNavigation">
            <li><a href="#stats-tab">Stats</a></li>
            <li><a href="#jakeisms-tab">Jakeisms</a></li>
            <li><a href="#comments-tab">Comments</a></li>
            <li><a href="#favorites-tab">Favorites</a></li>
        </ul>

        <div id="jakeisms-tab">
            <br />
            <asp:ListView runat="server" ID="entries">
        
                <LayoutTemplate>   
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />     
                </LayoutTemplate>

                <ItemTemplate>
                    <h4><a title="View Entry" href="ViewEntry.aspx?id=<%# Eval("Id") %>">Jakeism #<%# Eval("Id") %></a></h4>
                    <p><%# Eval("EntryBody") %></p><br />
                </ItemTemplate>

                <EmptyDataTemplate>
                    <div><p>No entries</p></div>
                </EmptyDataTemplate>

            </asp:ListView>
        </div>

        <div id="comments-tab">
            <br />
            <asp:ListView runat="server" ID="comments">
        
                <LayoutTemplate>   
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />     
                </LayoutTemplate>

                <ItemTemplate>
                    <h4><a title="View Entry" href="ViewEntry.aspx?id=<%# Eval("Entry.Id") %>#comment-<%# Eval("Id") %>">Jakeism #<%# Eval("Entry.Id") %></a></h4>
                    <p><%# Eval("CommentBody") %></p><br />
                </ItemTemplate>

                <EmptyDataTemplate>
                    <div><p>No comments</p></div>
                </EmptyDataTemplate>

            </asp:ListView>
        </div>

        <div id="favorites-tab">
            <br />
            <asp:ListView runat="server" ID="favorites">
        
                <LayoutTemplate>   
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />     
                </LayoutTemplate>

                <ItemTemplate>
                    <h4><a title="View Entry" href="ViewEntry.aspx?id=<%# Eval("Id") %>">Jakeism #<%# Eval("Id") %></a> posted by <a title="View User" href="ViewUser.aspx?id=<%# Eval("User.Id") %>"><%# Eval("User.UserName") %></a></h4>
                    <p><%# Eval("EntryBody") %></p><br />
                </ItemTemplate>

                <EmptyDataTemplate>
                    <div><p>No favorites</p></div>
                </EmptyDataTemplate>

            </asp:ListView>
        </div>

        <div id="stats-tab">
            <br />
            <table id="stats-table">
                <tr>
                    <td>Member For</td>
                    <td><%= MemberFor %></td>
                </tr>
                <tr>
                    <td>Jakeisms Submitted</td>
                    <td><%= JakeismsSubmitted %></td>
                </tr>
                <tr>
                    <td>Comments Made</td>
                    <td><%= CommentsMade %></td>
                </tr>
                <tr>
                    <td>Votes Casted</td>
                    <td><%= VotesCasted %></td>
                </tr>
                <tr>
                    <td>Favorites Added</td>
                    <td><%= FavoritesAdded %></td>
                </tr>
                <tr>
                    <td>Votes Received</td>
                    <td><%= VotesReceived %></td>
                </tr>
                <tr>
                    <td>Jakeisms Favorited by Others</td>
                    <td><%= FavoritesReceived %></td>
                </tr>
            </table>
        </div>

    </div>

  </asp:Panel>

</asp:Content>
