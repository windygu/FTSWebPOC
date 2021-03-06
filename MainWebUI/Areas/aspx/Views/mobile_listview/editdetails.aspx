﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/aspx/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage<FTS.MainWebUI.Models.ProductViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<% Html.Kendo().MobileView()
       .Name("edit-detailview")
       .Header(() => 
        {
            %>
            <% Html.Kendo().MobileNavBar()
                   .Content(navbar => 
                    {
                        %>
                        <%: Html.Kendo().MobileBackButton()
                                .Name("cancel")
                                .Text("Cancel")                                
                                .Url("Editing", "Mobile_ListView")
                                .Align(MobileButtonAlign.Left)                                
                        %>
                        <%: navbar.ViewTitle("Details")%>
                        <%: Html.Kendo().MobileButton() 
                                .Name("done")
                                .Text("Done")                                
                                .Events(events => events.Click("doneClick"))
                                .Align(MobileButtonAlign.Right)                                
                        %>
                        <%
                    })
                   .Render();
            %>           
            <%
        })
        .Content(() => 
        {
            %>

            <% Html.BeginForm("Editing_Update", "Mobile_ListView", FormMethod.Post); %>
                <%: Html.HiddenFor(product => product.ProductID ) %>
                <% Html.Kendo().MobileListView()
                       .Style("inset")
                       .Items(items =>
                        {
                            items.Add().Content(() =>
                            {
                                %>
                                <label>Product Name
                                    <input type="text" value="<%: Model.ProductName %>" name="ProductName"/>
                                </label>
                                <%
                            });
                            
                            items.Add().Content(() =>
                            {
                                %>
                                Discontinued                           
                                <%: Html.Kendo().MobileSwitch()
                                        .Checked(Model.Discontinued)
                                        .Name("Discontinued")
                                        .HtmlAttributes(new { value = "true" })
                                %>
                                <%
                            });
                            
                            items.Add().Content(() =>
                            {
                                %>
                                <label>Unit Price
                                    <input type="number" value="<%: Model.UnitPrice %>" name="UnitPrice"/>
                                </label>
                                <%
                            });
                        })
                        .Render();
                %>              
            <% Html.EndForm(); %>

            <%
        })
       .Render();
%>

<script>
    function doneClick() {
        $("form").submit();
    }   
</script>

<style scoped>
    .km-ios #edit-listview .km-navbar,
    .km-ios #edit-detailview .km-navbar {
        background: -webkit-gradient(linear, 50% 0, 50% 100%, color-stop(0, rgba(255, 255, 255, 0.5)), color-stop(0.06, rgba(255, 255, 255, 0.45)), color-stop(0.5, rgba(255, 255, 255, 0.2)), color-stop(0.5, rgba(255, 255, 255, 0.15)), color-stop(1, rgba(100, 100, 100, 0))), url(<%=Url.Content("~/content/shared/images/patterns/pattern1.png")%>);
        background: -moz-linear-gradient(center top , rgba(255, 255, 255, 0.5), rgba(255, 255, 255, 0.45) 6%, rgba(255, 255, 255, 0.2) 50%, rgba(255, 255, 255, 0.15) 50%, rgba(100, 100, 100, 0)), url(<%=Url.Content("~/content/shared/images/patterns/pattern1.png")%>);
    }
    .km-ios #edit-listview .km-navbar .km-button,
    .km-ios #edit-detailview .km-navbar .km-button {
        background-color: #000;
    }
    .km-ios #edit-detailview #done {
        background-color: Green;
    }
    .km-tablet .km-ios #edit-listview .km-view-title,
    .km-tablet .km-ios #edit-detailview .km-view-title {
        color: #fff;
        text-shadow: 0 -1px rgba(0,0,0,.5);
    }
    .km-ios #edit-listview .km-content,
    .km-ios #edit-detailview .km-content,
    .km-ios #edit-detailview .km-insetcontent,
    .km-ios #edit-listview li,
    .km-ios #edit-detailview li {
        background: #373737;
    }
    .km-ios #edit-listview li > a,
    .km-ios #edit-detailview li,
    .km-ios #edit-detailview input,
    .km-ios #edit-detailview li > a {
        text-decoration: none;
        color: #fff;
    }

    .km-ios #edit-detailview .km-listinset > li,
    .km-ios #edit-detailview .km-listgroupinset .km-list > li,
    .km-ios #edit-detailview .km-listinset > li:first-child,
    .km-ios #edit-detailview .km-listgroupinset .km-list >  li:first-child,
    .km-ios #edit-detailview .km-listinset > li:last-child,
    .km-ios #edit-detailview .km-listgroupinset .km-list >  li:last-child {
        box-shadow: none;
        -webkit-box-shadow: none;
        border-color: #565656;
    }
    .km-ios #edit-detailview .km-listinset > li:first-child,
    .km-ios #edit-detailview .km-listgroupinset .km-list > li:first-child {
        border-width: 1px;
    }
    .km-ios #edit-detailview .km-listinset > li,
    .km-ios #edit-detailview .km-listgroupinset .km-list > li {
        border-width: 0 1px 1px;
    }
    #edit-listview .delete {
        display:none;
        position: absolute;
        top: .15em;
        right: .5em;
        width: 60px;
        background-color: #bd2729;
    }
</style>

</asp:Content>
