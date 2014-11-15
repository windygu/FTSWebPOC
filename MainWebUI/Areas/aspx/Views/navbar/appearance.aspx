﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/aspx/Views/Shared/Mobile.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<% Html.Kendo().MobileView()
        .Name("dark-theme")
        .Title("Dark")
        .Header(() =>
            {
                Html.Kendo().MobileNavBar()
                    .Content(navbar =>
                    {
                    %> 
                    <%: Html.Kendo().MobileBackButton()
                            .Align(MobileButtonAlign.Left)
                            .HtmlAttributes(new { @class = "nav-button" })
                            .Url(Url.RouteUrl(new { controller = "suite" }))
                            .Text("Back")
                    %>                   
                    <%: navbar.ViewTitle("Dark Theme")%>                    
                    <%: Html.Kendo().MobileButton()
                            .Align(MobileButtonAlign.Right)
                            .Text("Light Theme")
                            .Url("#light-theme")
                    %>
                    <%
                    })
                    .Render();
            }
        )
        .Content(obj =>
            Html.Kendo().MobileScrollView()
                .Items(items =>
                {
                    items.Add().HtmlAttributes(new { @class = "photo photo1" });
                    items.Add().HtmlAttributes(new { @class = "photo photo2" });
                    items.Add().HtmlAttributes(new { @class = "photo photo3" });
                    items.Add().HtmlAttributes(new { @class = "photo photo4" });
                    items.Add().HtmlAttributes(new { @class = "photo photo5" });
                    items.Add().HtmlAttributes(new { @class = "photo photo6" });
                    items.Add().HtmlAttributes(new { @class = "photo photo7" });
                    items.Add().HtmlAttributes(new { @class = "photo photo8" });
                    items.Add().HtmlAttributes(new { @class = "photo photo9" });
                    items.Add().HtmlAttributes(new { @class = "photo photo10" });
                })
        )
        .Render();
%>

<% Html.Kendo().MobileView()
        .Name("light-theme")
        .Title("Light")
        .Header(() =>
            {
                Html.Kendo().MobileNavBar()
                    .Content(navbar =>
                    {
                    %>    
                    <%: Html.Kendo().MobileBackButton()
                            .Align(MobileButtonAlign.Left)
                            .HtmlAttributes(new { @class = "nav-button" })
                            .Url(Url.RouteUrl(new { controller = "suite" }))
                            .Text("Back")
                    %>               
                    <%: navbar.ViewTitle("Light Theme")%>                    
                    <%: Html.Kendo().MobileButton()
                            .Align(MobileButtonAlign.Right)
                            .Text("Dark Theme")
                            .Url("#dark-theme")
                    %>
                    <%
                    })
                    .Render();
                }
        )
        .Content(obj =>
            Html.Kendo().MobileScrollView()
                .Items(items => {
                    items.Add().HtmlAttributes(new { @class = "photo photo1" });
                    items.Add().HtmlAttributes(new { @class = "photo photo2" });
                    items.Add().HtmlAttributes(new { @class = "photo photo3" });
                    items.Add().HtmlAttributes(new { @class = "photo photo4" });
                    items.Add().HtmlAttributes(new { @class = "photo photo5" });
                    items.Add().HtmlAttributes(new { @class = "photo photo6" });
                    items.Add().HtmlAttributes(new { @class = "photo photo7" });
                    items.Add().HtmlAttributes(new { @class = "photo photo8" });
                    items.Add().HtmlAttributes(new { @class = "photo photo9" });
                    items.Add().HtmlAttributes(new { @class = "photo photo10" });
                })
        )
        .Render();
%>

<style scoped>
        #dark-theme .km-content, #dark-theme .km-navbar {
	    background-color: #111;
    }

    /* iOS pager */
    .km-ios #dark-theme .km-pages .km-current-page {
	    background: #ff009c;
    }

    #light-theme .km-content, #light-theme .km-navbar {
	    background-color: #ddd;
    }

    /* WP8 pager */
    .km-wp-dark #light-theme .km-content, .km-wp-dark  #light-theme .km-navbar {
	    background-color: #fff;
    }
    .km-wp-dark #light-theme .km-pages > li {
	    background-color: #000;
    }
    
    /* Flat pager */
    .km-flat #dark-theme .km-navbar {
	    color: #fff;
    }
    .km-flat #dark-theme .km-pages li {
	    background-color: rgba(255, 255, 255, 0.3);
    }
    .km-flat #dark-theme .km-pages .km-current-page {
    background: #10c4b2;
    }

    #light-theme .km-view-title {
	    color: #666;
	    text-shadow: 0 1px rgba(255, 255, 255, 0.6);
    }
    .km-tablet .km-ios #dark-theme .km-view-title {
        color: #fff;
        text-shadow: 0 -1px rgba(0,0,0,.5);
    }
    .km-android #light-theme .km-text {
	    color: #666;
    }

    #dark-theme .photo,
    #light-theme .photo {
        width: 15em;
        margin: 7em 20px 7px;
        height: 15em;
        display: inline-block;
        -webkit-background-size: auto 100%;
        -webkit-transform: translatez(0);
        background-size: auto 100%;
        background-repeat: no-repeat;
        background-position: center center;
    }

    .photo1 {background-image: url("<%=Url.Content("~/content/mobile/cities/220/sydney.jpg")%>");}
    .photo2 {background-image: url("<%=Url.Content("~/content/mobile/cities/220/bonn.jpg")%>");}
    .photo3 {background-image: url("<%=Url.Content("~/content/mobile/cities/220/boston.jpg")%>");}
    .photo4 {background-image: url("<%=Url.Content("~/content/mobile/cities/220/cairo.jpg")%>");}
    .photo5 {background-image: url("<%=Url.Content("~/content/mobile/cities/220/cancun.jpg")%>");}
    .photo6 {background-image: url("<%=Url.Content("~/content/mobile/cities/220/cape-town.jpg")%>");}
    .photo7 {background-image: url("<%=Url.Content("~/content/mobile/cities/220/liverpool.jpg")%>");}
    .photo8 {background-image: url("<%=Url.Content("~/content/mobile/cities/220/london.jpg")%>");}
    .photo9 {background-image: url("<%=Url.Content("~/content/mobile/cities/220/melbourne.jpg")%>");}
    .photo10 {background-image: url("<%=Url.Content("~/content/mobile/cities/220/san-francisco.jpg")%>");}
</style>

</asp:Content>
