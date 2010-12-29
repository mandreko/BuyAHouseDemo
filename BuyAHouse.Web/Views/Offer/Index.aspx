<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<BuyAHouse.Models.OfferModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Make an offer</h2>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(false) %>
    <fieldset>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.BuyerName) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.BuyerName) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.EmailAddress) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.EmailAddress) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Amount) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Amount) %>
        </div>

        <p>
            <input type="submit" value="Make Offer" />
        </p>
    </fieldset>
<% } %>
</asp:Content>
