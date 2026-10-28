using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Infrastructure.Common
{
    public static class StorageHelper
    {
        public static string ToPascalCase(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return text;
            var words = text.Split(new[] { '_', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join("", words.Select(w => char.ToUpper(w[0]) + w.Substring(1).ToLower()));
        }

        public static string GetExtension(string contentType) =>
            contentType.ToLower() switch
            {
                "application/pdf" => "pdf",
                "image/jpeg" => "jpg",
                "image/png" => "png",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document" => "docx",
                _ => "bin"
            };
    }
}
