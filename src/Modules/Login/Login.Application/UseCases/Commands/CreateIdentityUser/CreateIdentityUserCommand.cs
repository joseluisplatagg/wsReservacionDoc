using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Application.UseCases.Commands.CreateIdentityUser
{    public record CreateIdentityUserCommand(
        string Email,
        string Password,
        string FirstName,
        string LastName,
        string Phone) : IRequest<Guid>;
}
