using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Application.UseCases.Commands.RegisterUser
{
    public record RegisterUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string Phone) : IRequest<Guid>;
}
