﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/aspx/Views/Shared/Web.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%= Html.Kendo().Scheduler<FTS.MainWebUI.Models.Scheduler.MeetingViewModel>()
    .Name("scheduler")
    .Date(new DateTime(2013,6 ,13))
    .StartTime(new DateTime(2013, 6, 13, 7, 00, 00))
    .Height(600)
    .Views(views =>
    {
        views.DayView();
        views.WeekView(weekView => weekView.Selected(true));
        views.MonthView();
        views.AgendaView();
    })
    .Timezone("Etc/UTC")
    .Resources(resource =>
         {
            resource.Add(m => m.RoomID)
                .Title("Room")
                .DataTextField("Text")
                .DataValueField("Value")
                .DataColorField("Color")
                .BindTo(new[] { 
                    new { Text = "Meeting Room 101", Value = 1, Color = "#6eb3fa" },
                    new { Text = "Meeting Room 201", Value = 2, Color = "#f58a8a" } 
                });
            resource.Add(m => m.Attendees)
                .Title("Attendees")
                .Multiple(true)
                .DataTextField("Text")
                .DataValueField("Value")
                .DataColorField("Color")
                .BindTo(new[] { 
                    new { Text = "Alex", Value = 1, Color = "#f8a398" },
                    new { Text = "Bob", Value = 2, Color = "#51a0ed" },
                    new { Text = "Charlie", Value = 3, Color = "#56ca85" } 
                });
         })
    .DataSource(d => d
            .Custom()
            .Batch(true)
            .Schema(schema => schema
                .Model(m => { 
                    m.Id(f => f.MeetingID);
                    m.Field("title", typeof(string)).DefaultValue("No title").From("Title");
                    m.Field("start", typeof(DateTime)).From("Start");
                    m.Field("end", typeof(DateTime)).From("End");
                    m.Field("description", typeof(string)).From("Description");
                    m.Field("recurrenceID", typeof(int)).From("RecurrenceID");
                    m.Field("recurrenceRule", typeof(string)).From("RecurrenceRule");
                    m.Field("recurrenceException", typeof(string)).From("RecurrenceException");
                    m.Field("isAllDay", typeof(bool)).From("IsAllDay");
                    m.Field("startTimezone", typeof(string)).From("StartTimezone");
                    m.Field("endTimezone", typeof(string)).From("EndTimezone");
                }))
            .Transport(transport => transport
                .Read(read => read.Url("http://demos.telerik.com/kendo-ui/service/meetings")
                      .DataType("jsonp"))
                .Create(create => create.Url("http://demos.telerik.com/kendo-ui/service/meetings/create")
                      .DataType("jsonp"))
                .Destroy(destroy => destroy.Url("http://demos.telerik.com/kendo-ui/service/meetings/destroy")
                      .DataType("jsonp"))
                .Update(update => update.Url("http://demos.telerik.com/kendo-ui/service/meetings/update")
                      .DataType("jsonp"))
                .ParameterMap("parameterMap"))
    )
%>

<script>
    function parameterMap(options, operation) {
        if (operation !== "read" && options.models) {
            return { models: kendo.stringify(options.models) };
        }
    }
</script>
</asp:Content>

