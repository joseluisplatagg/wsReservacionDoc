using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Domain
{
    // Excepción base para reglas de negocio rotas (HTTP 400 o 422)
    public abstract class BusinessRuleException(string message) : Exception(message);
}
