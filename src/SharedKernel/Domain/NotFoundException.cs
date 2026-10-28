using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Domain
{
    // Excepción base para recursos no encontrados (HTTP 404)
    public class NotFoundException(string entityTypes, string id) : Exception($"Entity {entityTypes} with ID {id} was not found.")
    {
        public string EntityType { get; } = entityTypes;
        public string Id { get; } = id;
    }
}
