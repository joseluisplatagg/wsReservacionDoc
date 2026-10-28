using FluentValidation;
using SharedKernel.API.Localization;
using SharedKernel.Domain;
using System.Text.RegularExpressions;

namespace SharedKernel.Application.Exceptions
{
    public static partial class Utility
    {
        [GeneratedRegex(@"(\w*.\w*:\w* \d*)")]
        private static partial Regex ErrorMessagesRegex();

        public static string ParseStackTrace(Exception e)
        {
            if (e == null)
                return string.Empty;

            string[] stackTraceToArrayString = [.. ErrorMessagesRegex().Matches(e.StackTrace!).ToArray().Select(x => x.Value)];

            // Regresamos el arreglo de mensajes de error unidos por la cadena " -> "
            return string.Join(" -> ", stackTraceToArrayString);
        }

        public static string ExceptionMessages(Exception ex, ILocalizer localizer = null!)
        {
            if (ex == null)
                return string.Empty;

            if (ex is DomainException domainException)
                return localizer != null
                    ? localizer.GetMessage(domainException.Message, domainException.Args ?? [])
                    : domainException.Message;

            if (ex is NotFoundException notFoundException)
                return localizer != null
                    ? localizer.GetMessage("NotFound", localizer.GetMessage(notFoundException.EntityType), notFoundException.Id.ToString())
                    : notFoundException.Message;

            if (ex is ValidationException validationException)
                return string.Join("\n", validationException.Errors.Select(e => $"- {e.ErrorMessage}"));

            if (ex.InnerException == null)
                return ex.Message;

            return ex.Message + " -> " + ExceptionMessages(ex.InnerException);
        }
    }
}
