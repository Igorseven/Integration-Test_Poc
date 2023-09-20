using UserRegistration.API.Business.Domain.Handlers.NotificationHandler;

namespace UserRegistration.API.Business.Domain.Interfaces.OthersContracts;
public interface INotificationHandler
{
    bool CreateNotification(string key, string value);
    void CreateNotification(DomainNotification notification);
    void CreateNotifications(IEnumerable<DomainNotification> notifications);
    bool HasNotification();
    List<DomainNotification> GetNotifications();
}
