using Models;
using System.ComponentModel.DataAnnotations;
using WebApiA.DTOs;
using WebApiA.FluentValidation;
using WebApiA.RabbitClient;

namespace WebApiA.Services
{
    public class UserService : IUserService
    {
        private readonly IRabbit _rabbit;

        public UserService(IRabbit rabbit)
        {
            _rabbit = rabbit;
        }

        public async Task CreateUser(UserDto userDto)
        {
            var validator = new UserDtoValidator();
            var result = validator.Validate(userDto);
            if (!result.IsValid)
            {
                var errors = string.Concat(result.Errors.Select(e => e.ErrorMessage + " "));
                throw new ValidationException(errors);
            }

            var message = new User
            {
                Id = 0,
                Name = userDto.Name,
                Email = userDto.Email
            };

            await _rabbit.SendMessage(message);
        }
    }
}
