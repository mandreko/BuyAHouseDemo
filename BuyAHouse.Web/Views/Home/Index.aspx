<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<BuyAHouse.Models.PropertyModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Select a property to make an offer on:</h2>

<ul>
    <% foreach (var item in Model) { %>
    <li><a href="/Offer/Index/<%: item.PropertyId %>"><%: item.Address %></a></li>
<% } %>
</ul>

</asp:Content>

