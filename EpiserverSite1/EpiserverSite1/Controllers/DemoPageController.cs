using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Cms.Shell.UI.Rest.Models.Internal;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EpiserverSite1.Models.Pages;
using EpiserverSite1.Models.ViewModels;

namespace EpiserverSite1.Controllers
{
    public class DemoPageController : Controller
    {
       /* public ActionResult Index(DemoPage currentPage)
        {
            *//* Implementation of action. You can create your own view model class that you pass to the view or
             * you can pass the page type for simpler templates *//*

            return View(currentPage);
        } */ 
        public ViewResult Index(SitePageData currentPage)
        {
            var model = CreateModel(currentPage);
            return View(string.Format("~/Views/DemoPage/Index.cshtml", currentPage.GetOriginalType().Name), model);
        }

        private static IPageViewModel<SitePageData> CreateModel(SitePageData page)
        {
            var type = typeof(PageViewModel<>).MakeGenericType(page.GetOriginalType());
            return Activator.CreateInstance(type, page) as IPageViewModel<SitePageData>;
        }
    }
}