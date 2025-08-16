using MassTransit;
using Models;
using WebApiB.Services;

namespace WebApiB.Rabbit
{
    public class RabbitConsumer : IConsumer<User>
    {
        private readonly IUserService _userService;

        public RabbitConsumer(IUserService userService)
        {
            _userService = userService;
        }

        public async Task Consume(ConsumeContext<User> context)
        {
            var user = context.Message;
            await _userService.SaveUserAsync(user);
        }
    }
}
