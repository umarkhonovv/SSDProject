using MassTransit;
using Models;

namespace WebApiA.RabbitClient
{
    public class Rabbit : IRabbit
    {
        private readonly IPublishEndpoint _publish;

        public Rabbit(IPublishEndpoint publish)
        {
            _publish = publish;
        }

        public async Task SendMessage(User message)
        {
            await _publish.Publish(message);
        }
    }
}
