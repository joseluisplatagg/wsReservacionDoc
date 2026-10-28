using MediatR;

namespace SharedKernel.Domain.Events
{
    public record UserRegisterEvent(
    Guid UserId,
    string Email,
    string FirstName,
    string LastName,
    string Phone) : INotification;
}
