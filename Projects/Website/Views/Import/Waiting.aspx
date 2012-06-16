<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Main.Master" Inherits="System.Web.Mvc.ViewPage<Website.Models.FitsWaitingModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <h2>
        Waiting</h2>
    <% foreach (var file in Model.Files)
       {
    %>

    <a href=""><%=file.Name %></a>
    <%
} 
    %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
