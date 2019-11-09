using Galaxy.MVC.Filter.Exceptions;
using Galaxy.MVC.Filter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.MVC.Filter.Filter
{
    public class CustomExceptionFilterAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException)
            {
                ExceptionViewModel model = new ExceptionViewModel
                {
                    Message = context.Exception.Message
                };
                context.Result = new ViewResult
                {                    
                    ViewName = "CustomException",
                    ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                    {
                        Model = model
                    }
                };
            }
        }
    }
}
