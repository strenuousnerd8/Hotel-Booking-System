using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Admin.RabbitMQ
{
    public class RabbitMQConsumer : IRabbitMQConsumer
    {
        public async Task<string> ReceiveProductMessage()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            var tcs = new TaskCompletionSource<string>();

            channel.QueueDeclare(queue: "respondanceQueue", exclusive: false);

            Console.WriteLine(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($" [x] Received {message}");
                    tcs.TrySetResult(message);
                }
                catch (Exception ex)
                {
                    tcs.TrySetException(ex);
                }
            };
            channel.BasicConsume(queue: "respondanceQueue",
                                 autoAck: true,
                                 consumer: consumer);
            return await tcs.Task;
        }
    }
}
