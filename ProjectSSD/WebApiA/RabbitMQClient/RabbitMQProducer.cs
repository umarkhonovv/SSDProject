﻿using MassTransit;
using Models;

namespace WebApiA.RabbitMQClient;

public class RabbitMQProducer : IRabbitMQProducer
{
    private readonly IPublishEndpoint _publish;

    public RabbitMQProducer(IPublishEndpoint publish)
    {
        _publish = publish;
    }

    public async Task SendMessage(User message)
    {
        await _publish.Publish(message);
    }
}