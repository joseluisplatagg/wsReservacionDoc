using MediatR;
using SharedKernel.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Users.Application.Contracts.Data;
using Users.Domain.AggregateRoots;
using Users.Domain.ValueObjects;

namespace Users.Application.UseCases.EventHandlers
{
    public class CreateProfileOnUserRegistered : INotificationHandler<UserRegisterEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProfileOnUserRegistered(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UserRegisterEvent notification, CancellationToken cancellationToken)
        {
            var userId = notification.UserId;
            var firstName = notification.FirstName;
            var lastName = notification.LastName;
            var phone = notification.Phone;

            // Aggregate Root usando los datos del evento
            var userProfile = UserProfile.Create(
                userId,
                FullName.Create(firstName, lastName),
                SystemPhoneNumber.Create(phone)
            );

            var userRepository = _unitOfWork.GetRepository<UserProfile>();
            await userRepository.AddAsync(userProfile);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }
    }

}
