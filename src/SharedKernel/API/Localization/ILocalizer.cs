using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.API.Localization
{
    public interface ILocalizer
    {
        string GetMessage(Exception ex);
        string GetMessage(string? key, params object[] args);
    }
}
