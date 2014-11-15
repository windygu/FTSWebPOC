﻿using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using FTS.MainWebUI.Models.Gantt;

namespace FTS.MainWebUI.Controllers
{﻿
    public partial class GanttController : Controller
    {
        private GanttTaskService taskService;
        private GanttDependencyService dependencyService;

        public GanttController()
        {
            taskService = new GanttTaskService();
            dependencyService = new GanttDependencyService();
        }

        protected override void Dispose(bool disposing)
        {
            taskService.Dispose();
            dependencyService.Dispose();

            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return View();
        }

        public virtual JsonResult ReadTasks([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult DestroyTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult CreateTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult UpdateTask([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult ReadDependencies([DataSourceRequest] DataSourceRequest request)
        {
            return Json(dependencyService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult DestroyDependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel task)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult CreateDependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel task)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult UpdateDependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel task)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }
    }
}