﻿using AdvertisementApp.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseRedirectoAction(this Controller controller, IResponse<T> response, string actionName)
        {
            if (response.ResponseType == ResponseType.NotFound)
                return controller.NotFound();
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var item in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(item.PropertyName, item.ErrorMessage)
                }
                return controller.View(response.Data);
            }
            return controller.RedirectToAction(actionName);
        }
        public static IActionResult ResponseView<T>(this Controller controller,)
    }
}
