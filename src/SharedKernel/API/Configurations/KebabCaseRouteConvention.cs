using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SharedKernel.API.Configurations
{
    public class KebabCaseRouteConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var controllerName = ToKebabCase(controller.ControllerName);

                foreach (var selector in controller.Selectors)
                {

                    if (selector.AttributeRouteModel == null)
                    {
                        selector.AttributeRouteModel = new AttributeRouteModel
                        {
                            Template = $"/api/v{{version:apiVersion}}/{controllerName}"
                        };
                    }
                    else
                    {
                        selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template!
                            .Replace("[controller]", controllerName);
                    }
                }
            }
        }

        private static string ToKebabCase(string input)
        {
            return Regex.Replace(input, "(?<!^)([A-Z])", "-$1").ToLowerInvariant();
        }
    }
}
