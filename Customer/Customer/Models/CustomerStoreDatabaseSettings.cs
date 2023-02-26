namespace Customer.Models
{
    public class CustomerStoreDatabaseSettings : ICustomerStoreDatabaseSettings
    {
        public string CustomerBookingsCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
