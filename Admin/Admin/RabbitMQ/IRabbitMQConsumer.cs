namespace Admin.RabbitMQ
{
    public interface IRabbitMQConsumer
    {
        public Task<string> ReceiveProductMessage();
    }
}
