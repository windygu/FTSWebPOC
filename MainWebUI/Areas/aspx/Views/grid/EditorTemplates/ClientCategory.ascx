<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<FTS.MainWebUI.Models.CategoryViewModel>" %>

<%= Html.Kendo().DropDownListFor(m => m)
        .DataValueField("CategoryID")
        .DataTextField("CategoryName")
        .BindTo((System.Collections.IEnumerable)ViewData["categories"])
%>