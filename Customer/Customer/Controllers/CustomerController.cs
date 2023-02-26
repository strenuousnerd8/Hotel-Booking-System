using Customer.Models;
using Customer.RabbitMQ;
using Customer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IRabbitMQProducer _rabbitMQProducer;

        public CustomerController(ICustomerService customerService, IRabbitMQProducer rabbitMQProducer) {
            this.customerService = customerService;
            _rabbitMQProducer = rabbitMQProducer;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<List<CustomerObj>> Get()
        {
            return customerService.Get();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerObj> Get(string id)
        {
            var customer = customerService.Get(id);
            if (customer == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            string response = customer.HotelId;

            _rabbitMQProducer.SendProductMessage(response);

            return customer;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult<CustomerObj> Post([FromBody] CustomerObj customerObj)
        {
            customerService.Create(customerObj);

            return CreatedAtAction(nameof(Get), new { id = customerObj.Id }, customerObj);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] CustomerObj customerObj)
        {
            var existingCustomer = customerService.Get(id);
            if (existingCustomer == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            customerService.Update(id, customerObj);
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var customer = customerService.Get(id);

            if (customer == null)
            {
                return NotFound($"Customer with Id = {id} not found");
            }

            customerService.Remove(customer.Id);

            return Ok($"Customer with Id = {id} deleted");
        }
    }
}
