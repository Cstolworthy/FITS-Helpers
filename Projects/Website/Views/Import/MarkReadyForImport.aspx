<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<Website.Models.MarkReadyForImportModel>" %>

<%@ Import Namespace="Website" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <% using (Html.BeginForm("SaveNewImport", null, FormMethod.Post, new { id = "myForm" }))
       { %>
    <h1>
        File:
        <%= Request.QueryString["fileid"] %></h1>
    <br />
    <br />
    <label for="ra_select">
        Select RA</label>
    <%= Html.DropDownList("raSelect", Model.ColumnsAsSelect)%>
    <br />
    <br />
    <label for="dec_select">
        Select Dec</label>
    <%= Html.DropDownList("decSelect", Model.ColumnsAsSelect)%>
    <%= Html.TextBox("file", Request.QueryString["fileid"])%>
    <br />
    <br />
    <h2>
        Color Mapping</h2>
    <% for (int i = 2; i < Model.ColumnNames.Count(); i++)
       {%>

       <%= Html.DropDownList("color"+i, Model.ColumnsAsSelect) %>
       <%= Html.TextBox("tbColor"+i) %>
       <br />
    <%} %>
    <input type="submit" name="saveNewImport" value="Save" />
    <% } %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
