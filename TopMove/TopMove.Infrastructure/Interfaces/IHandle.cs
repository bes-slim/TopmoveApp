
namespace RealEstate.Genie.Infrastructure.Domain.Interfaces
{
    public interface IHandle<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}
