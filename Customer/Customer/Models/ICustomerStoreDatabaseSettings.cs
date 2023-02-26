namespace Customer.Models
{
    public interface ICustomerStoreDatabaseSettings
    {
        string CustomerBookingsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
