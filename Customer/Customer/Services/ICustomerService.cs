using Customer.Models;

namespace Customer.Services
{
    public interface ICustomerService
    {
        List<CustomerObj> Get();
        CustomerObj Get(string id);
        CustomerObj Create(CustomerObj customerObj);
        void Update(string id, CustomerObj customerObj);
        void Remove(string id);
    }
}
