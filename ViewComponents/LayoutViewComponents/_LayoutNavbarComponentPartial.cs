﻿using Microsoft.AspNetCore.Mvc;
using MyPortfolioWebsite.DAL.Context;

namespace MyPortfolioWebsite.ViewComponents.LayoutViewComponents
{
    public class _LayoutNavbarComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {


            return View();
        }
    }
}
