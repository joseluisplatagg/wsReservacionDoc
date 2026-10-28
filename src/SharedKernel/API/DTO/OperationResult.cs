using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.API.DTO
{
    public class OperationResult<T>
    {
        public T Data { get; set; } = default!;
        public string? ResultCode { get; set; }
        public List<string>? Warnings { get; set; }
        public Dictionary<string, object>? Metadata { get; set; }
    }

    public static class OperationResult
    {
        public static OperationResult<T> With<T>(
            T data,
            string? resultCode = null,
            List<string>? warnings = null,
            Dictionary<string, object>? metadata = null) =>
            new() { Data = data, ResultCode = resultCode, Warnings = warnings, Metadata = metadata };
    }
}
