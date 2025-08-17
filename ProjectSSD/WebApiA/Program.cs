using MassTransit;
using WebApiA.ExceptionHandling;
using WebApiA.RabbitMQClient;
using WebApiA.Services;

namespace WebApiA;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("host.docker.internal", 5672, "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
            });
        });

        builder.Services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddCors(options =>
            options.AddDefaultPolicy(policy =>
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            )
        );

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseExceptionHandler();
        app.UseCors();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
