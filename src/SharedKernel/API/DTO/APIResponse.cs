using SharedKernel.API.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.API.DTO
{
    public class APIResponse<T>
    {
        public string? Message { get; set; }
        public OperationResult<T> Result { get; set; } = default!;
    }

    public static class APIResponseExtensions
    {
        public static APIResponse<T> ToAPIResponse<T>(
            this OperationResult<T> result,
            ILocalizer localizer)
        {
            string message = localizer.GetMessage(result.ResultCode) ?? "Success";

            return new APIResponse<T>
            {
                Message = message,
                Result = result
            };
        }
    }
}
