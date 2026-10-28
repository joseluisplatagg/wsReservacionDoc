using Microsoft.AspNetCore.Mvc;
using SharedKernel.API.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.API.Attributes
{
    public class HasPermissionAttribute : TypeFilterAttribute
    {
        public HasPermissionAttribute(string actionName) : base(typeof(HasPermissionFilter))
        {
            Arguments = [actionName];
        }
    }
}
