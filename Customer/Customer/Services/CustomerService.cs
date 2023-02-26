using Customer.Models;
using MongoDB.Driver;

namespace Customer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<CustomerObj> _bookings;

        public CustomerService(ICustomerStoreDatabaseSettings settings, IMongoClient mongoClient) {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _bookings = database.GetCollection<CustomerObj>(settings.CustomerBookingsCollectionName);
        }
        public CustomerObj Create(CustomerObj customerObj)
        {
            _bookings.InsertOne(customerObj);
            return customerObj;
        }

        public List<CustomerObj> Get()
        {
            return _bookings.Find(customerObj => true).ToList();
        }

        public CustomerObj Get(string id)
        {
            return _bookings.Find(customerObj => customerObj.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _bookings.DeleteOne(customerObj => customerObj.Id == id);
        }

        public void Update(string id, CustomerObj customerObj)
        {
            _bookings.ReplaceOne(customerObj => customerObj.Id == id, customerObj);
        }
    }
}
