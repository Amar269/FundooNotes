using ModelLayer.DTO.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interface
{
    public interface IRabbitMQProducer
    {
        Task PublishEmailMessage(EmailMessageDTO emailMessage);
    }
}
