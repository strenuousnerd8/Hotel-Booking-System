namespace Customer.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        public void SendProductMessage(string message);
    }
}
