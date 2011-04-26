<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TopEntries.aspx.cs" Inherits="Jakeism.TopEntries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Jakeism | Top Jakeisms</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Top Jakeisms</h2>

    <asp:ListView runat="server" ID="topEntries">
        
        <LayoutTemplate>   
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />     
        </LayoutTemplate>

        <ItemTemplate>
            <asp:HiddenField ID="HiddenTier" runat="server" Value='<%# Eval("Tier") %>' />
            <asp:HiddenField ID="HiddenId" runat="server" Value='<%# Eval("Id") %>' />
             <div class="entry entry-<%# Eval("Tier") %>">
                 <div class="entry-body">
                     <p><%# Eval("EntryBody") %></p>
                 </div>
                 <div class="entry-vote">
                     <asp:UpdatePanel ID="votePanel" runat="server">
                         <ContentTemplate>
                             <div class="vote-left">
                                 <asp:ImageButton ID="thumb" runat="server" AlternateText="Vote Up" OnClick="Cast_Vote" CommandName='<%# Count %>' CommandArgument='<%# Eval("Id") %>'  />
                             </div>
                             <div class="vote-right">
                                 <span class="votecount"><asp:Label runat="server" ID="votes" Text='<%# Eval("Votes.Count") %>' /></span>
                             </div>
                         </ContentTemplate>
                     </asp:UpdatePanel>
                </div>
                <div class="entry-title">
                    <h2><a title="View Entry" href="ViewEntry.aspx?id=<%# Eval("Id") %>">Jakeism #<%# Eval("Id") %></a></h2>
                </div>
                <div class="meta">
                    <div class="favorite">
                        <asp:UpdatePanel runat="server" ID="favoritePanel">
                            <ContentTemplate>
                                <asp:ImageButton ID="star" runat="server" AlternateText="Favorite" OnClick="Cast_Favorite" CommandName='<%# Count++ %>' CommandArgument='<%# Eval("Id") %>'  />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="info-bar">
                        <p>posted by <a title="View User" href="ViewUser.aspx?id=<%# Eval("User.Id") %>"><%# Eval("User.UserName") %></a>
                         on <%# Eval("FormattedDate") %> at <%# Eval("FormattedTime") %> | <a title="View Comments" href="ViewEntry.aspx?id=<%# Eval("Id") %>#comments">
                         <%# Eval("Comments.Count") %> comments</a></p>
                    </div>
                </div>
            </div>
        </ItemTemplate>

        <EmptyDataTemplate>
            <br />
            <div><p>No entries</p></div>
        </EmptyDataTemplate>

    </asp:ListView>

</asp:Content>
