<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<Website.Models.MarkReadyForImportModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">

<h2>MarkReadyForImport</h2>
<p><%= Request.QueryString["fileid"] %></p>

<% foreach (var column in Model.ColumnNames)
{ %>
  <p><%=column %></p>
<%} %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
