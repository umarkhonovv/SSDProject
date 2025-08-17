
using MassTransit;
using WebApiB.Data;
using WebApiB.Rabbit;
using WebApiB.Services;

namespace WebApiB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("PostgresConnection")));

            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<RabbitConsumer>();

                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("host.docker.internal", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    cfg.ReceiveEndpoint("user-queue", e =>
                    {
                        e.ConfigureConsumer<RabbitConsumer>(ctx);
                    });
                });
            });

            builder.Services.AddMassTransitHostedService();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
