using Microsoft.Extensions.Localization;
using SharedKernel.Application.Exceptions;
using SharedKernel.Application.Resources;
using SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.API.Localization
{
    public class Localizer(
    IStringLocalizer<DomainExceptionMessages> domainExceptionLocalizer,
    IStringLocalizer<UseCaseExceptionMessages> useCaseExceptionLocalizer,
    IStringLocalizer<ValidationExceptionMessages> validationExceptionLocalizer,
    IStringLocalizer<ResponseMessages> responseLocalizer) : ILocalizer
    {
        /// <summary>
        /// Mapea los codigos de error a mensajes localizados. 
        /// Si el tipo de excepción no es reconocido, devuelve un mensaje de error inesperado.
        /// </summary>
        /// <param name="ex">Excepción</param>
        /// <returns>Mensaje localizado</returns>
        public string GetMessage(Exception ex)
        {
            return ex switch
            {
                DomainException de => domainExceptionLocalizer[de.Message],
                UseCaseException uce => useCaseExceptionLocalizer[uce.Message],
                FluentValidation.ValidationException ve => validationExceptionLocalizer[ve.Message],
                _ => responseLocalizer["UnexpectedError"]
            };
        }

        /// <summary>
        /// Obtiene un mensaje localizado basado en la clave proporcionada para API Response.
        /// Si la clave es nula, devuelve un mensaje de éxito.
        /// </summary>
        /// <param name="key">Clave del mensaje</param>
        /// <param name="args">Argumentos para formatear el mensaje</param>
        /// <returns>Mensaje localizado</returns>
        public string GetMessage(string? key, params object[] args)
        {
            if (key == null)
                return "Success";

            return responseLocalizer[key, args];
        }
    }
}
