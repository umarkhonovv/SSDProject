using Models;

namespace WebApiA.RabbitClient
{
    public interface IRabbit
    {
        Task SendMessage(User message);
    }
}
