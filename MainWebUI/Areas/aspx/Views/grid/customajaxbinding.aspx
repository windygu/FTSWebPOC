<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/aspx/Views/Shared/Web.Master" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<%: Html.Kendo().Grid<FTS.MainWebUI.Models.Order>()
    .Name("Grid")
    .Columns(columns =>
    {
        columns.Bound(o => o.OrderID).Groupable(false);
        columns.Bound(o => o.ShipCity);
        columns.Bound(o => o.ShipCountry);
        columns.Bound(o => o.ShipName);
    })
    .Pageable()
    .Sortable()
    .Filterable()
    .Scrollable()
    .Groupable()
    .DataSource(dataSource => dataSource
        .Ajax()
        .Read(read => read.Action("CustomAjaxBinding_Read", "Grid"))
    )
%>
</asp:Content>
