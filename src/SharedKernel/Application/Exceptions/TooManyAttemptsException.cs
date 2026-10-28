using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Application.Exceptions
{
    public class TooManyAttemptsException(int maxAttempts, int windowMinutes)
    : Exception(
        $"Se ha excedido el número máximo de intentos  ({maxAttempts}). " +
        $"Intente de nuevo en {windowMinutes} minuto(s).")
    {
        public string ErrorCode => "MaxAttemptsExceeded";
        public int MaxAttempts { get; } = maxAttempts;

        /// <summary>Minutos que debe esperar el usuario antes de poder reintentar.</summary>
        public int WindowMinutes { get; } = windowMinutes;
    }
}
