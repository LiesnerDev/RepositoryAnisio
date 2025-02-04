using Employee.Domain.SeedWork;

namespace Employee.Application.Common
{
    public abstract class BaseService
    {
        private readonly INotification _notification;

        protected BaseService(INotification notification)
        {
            _notification = notification;
        }

        protected async Task<T> ExecuteAsync<T>(Func<Task<T>> func, string exceptionMessage = "An error occurred.")
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                // Log the exception here if logging is set up
                _notification.AddNotification("Exception", exceptionMessage);
                return default(T)!;
            }
        }

        protected void AddNotification(string key, string message)
        {
            _notification.AddNotification(key, message);
        }
    }
}