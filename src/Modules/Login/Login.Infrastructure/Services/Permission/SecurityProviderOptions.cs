using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Infrastructure.Services.Permission
{
    public class SecurityProviderOptions
    {
        public static readonly string SectionName = "Services:Permission";
        public string BaseUrl { get; set; } = string.Empty;
    }
}
