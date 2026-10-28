using Login.Application.Contracts.Data;
using Login.Domain.AggregateRoots;
using Login.Domain.ValueObjects;
using MediatR;
using SharedKernel.Domain.Events;

namespace Login.Application.UseCases.Commands.CreateIdentityUser
{
    public class CreateIdentityUserCommandHandler : IRequestHandler<CreateIdentityUserCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CreateIdentityUserCommandHandler(
            IMediator mediator,
            IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateIdentityUserCommand request, CancellationToken cancellationToken)
        {
            var userId = Guid.NewGuid();

            var identityUser = IdentityUser.Create(userId, Email.Create(request.Email),PasswordHash.FromHash(request.Password));
            var userRepository = _unitOfWork.GetRepository<IdentityUser>();

            await userRepository.AddAsync(identityUser);
            await _unitOfWork.CompleteAsync();

            await _mediator.Publish(new UserRegisterEvent(
                userId,
                request.Email,
                request.FirstName,
                request.LastName,
                request.Phone
            ), cancellationToken);

            return userId;
        }
    }

}
