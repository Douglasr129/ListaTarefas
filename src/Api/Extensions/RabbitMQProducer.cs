using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Api.Extensions
{
    public class RabbitMQProducer
    {
        private readonly ConnectionFactory _factory;

        public RabbitMQProducer()
        {
            _factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };
        }

        public async void SendMessage(object newTask, object oldTask = null)
        {
            using var connection = await _factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "task_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);


            var message = new { OldTask = oldTask, NewTask = newTask }; 
            var messageBody = JsonConvert.SerializeObject(message); 
            var body = Encoding.UTF8.GetBytes(messageBody);

            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "task_queue", body: body);
        }
    }
}
