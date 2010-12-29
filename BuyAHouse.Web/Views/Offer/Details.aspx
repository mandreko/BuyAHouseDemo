<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BuyAHouse.Models.OfferModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Details of your offer</h2>

<fieldset>
    <legend>Offer Info</legend>

    <div class="display-label"><%: Html.LabelFor(m => m.BuyerName) %></div>
    <div class="display-field"><%: Html.DisplayFor(m => m.BuyerName) %></div>

    <div class="display-label"><%: Html.LabelFor(m => m.EmailAddress) %></div>
    <div class="display-field"><%: Html.DisplayFor(m => m.EmailAddress) %></div>

    <div class="display-label"><%: Html.LabelFor(m => m.Amount) %></div>
    <div class="display-field"><%: Html.DisplayFor(m => m.Amount) %></div>

    <% using (Html.BeginForm()) { %>

    <div>Do you want to accept this offer?</div>

    

    <%: Html.RadioButton("accept", "Yes", true) %><label>Yes</label>
    <%: Html.RadioButton("accept", "No", false)%><label>No</label>
    <%--<%: Html.RadioButton("accept", "Counter", false)%><label>Counter</label>--%>

    <input type="submit" value="Submit" />
    <% } %>

</fieldset>

</asp:Content>

