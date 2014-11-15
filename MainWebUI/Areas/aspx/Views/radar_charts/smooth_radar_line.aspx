﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/aspx/Views/Shared/Web.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div class="chart-wrapper">
    <%= Html.Kendo().Chart<FTS.MainWebUI.Models.BudgetReportItem>()
        .Name("chart")
        .Title("Budget report")
        .Legend(legend => legend
            .Position(ChartLegendPosition.Bottom)
        )
        .SeriesDefaults(seriesDefaults => seriesDefaults.RadarLine().Style(ChartRadarLineStyle.Smooth))
        .DataSource(ds => ds.Read(read => read.Action("_BudgetReport", "Radar_Charts")))
        .Series(series =>
        {
            series.RadarLine(model => model.Budget);
            series.RadarLine(model => model.Spending);
        })
        .CategoryAxis(axis => axis
            .Categories(model => model.Unit)
        )
        .ValueAxis(axis => axis.Numeric()
            .Labels(labels => labels.Template("$#= value / 1000 #k"))
        )
    %>
</div>
</asp:Content>
