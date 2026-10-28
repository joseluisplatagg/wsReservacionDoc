using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Application.Contracts.Data;
using Users.Domain.AggregateRoots;
using Users.Domain.ValueObjects;

namespace Users.Application.UseCases.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork; 

        public RegisterUserCommandHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = UserProfile.Create(new Guid(),FullName.Create(request.FirstName, request.LastName),SystemPhoneNumber.Create(request.Phone));
            var repo = _unitOfWork.GetRepository<UserProfile>();
            await repo.AddAsync(identityUser);
            await _unitOfWork.CompleteAsync(cancellationToken);
            

            return identityUser.Id;
        }
    }
}
