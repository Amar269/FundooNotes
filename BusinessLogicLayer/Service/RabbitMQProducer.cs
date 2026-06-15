using BusinessLogicLayer.Interface;
using ModelLayer.DTO.RabbitMQ;
using RabbitMQ.Client;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class RabbitMQProducer : IRabbitMQProducer
    {

        //public RabbitMQProducer()
        //{

        //}
       

       public async Task PublishEmailMessage(EmailMessageDTO emailMessage)
       {
            var factory = new ConnectionFactory();

            factory.HostName = "localhost";

            var connection = await factory.CreateConnectionAsync();

            var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
            queue: "email_queue",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);


            var message = JsonSerializer.Serialize(emailMessage);
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
            exchange: "",
            routingKey: "email_queue",
            body: body);


       }
    }
}
