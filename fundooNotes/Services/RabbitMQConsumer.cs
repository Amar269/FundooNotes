using BusinessLogicLayer.Interface;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using ModelLayer.DTO.RabbitMQ;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
namespace fundooNotes.Services
{
    public class RabbitMQConsumer : BackgroundService
    {
        //private readonly IEmailService _emailService;
        private readonly IServiceScopeFactory _scopeFactory;

        public RabbitMQConsumer( IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        //public RabbitMQConsumer (IEmailService emailService)
        //{
        //    _emailService = emailService;
        //}
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory();

            factory.HostName = "localhost";

            var conenction = await factory.CreateConnectionAsync();

            var channel = await conenction.CreateChannelAsync();
            await channel.QueueDeclareAsync(
                queue: "email_queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null
             );

            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (sender, e) =>
            {
                var body = e.Body.ToArray();

                var message = Encoding.UTF8.GetString(body);

                var emailMessage =  JsonSerializer.Deserialize<EmailMessageDTO>(message);

                using var scope = _scopeFactory.CreateScope();
                var emailService =scope.ServiceProvider.GetRequiredService<IEmailService>();


                if (emailMessage != null)
                {
                    await emailService.SendEmail(
                    emailMessage.ToEmail,
                    emailMessage.Subject,
                    emailMessage.Body);
                }
            };
            await channel.BasicConsumeAsync(
             queue: "email_queue",
             autoAck: true,
             consumer: consumer);

            await Task.Delay( Timeout.Infinite,stoppingToken);
        }
    }
}
