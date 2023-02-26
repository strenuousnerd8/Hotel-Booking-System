using Microsoft.AspNetCore.Mvc;
using Admin.Models;
using Admin.Services;
using Admin.RabbitMQ;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IRabbitMQConsumer _rabbitMQConsumer;
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService, IRabbitMQConsumer rabbitMQConsumer) {
            this.adminService = adminService;
            _rabbitMQConsumer = rabbitMQConsumer;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public ActionResult<List<Hotel>> Get()
        {
            return adminService.Get();
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(string id)
        {
            var hotel = adminService.Get(id);
            if (hotel == null)
            {
                return NotFound($"Hotel with Id = {id} not found");
            }

            return hotel;
        }

        [HttpGet("[action]/consume")]
        public ActionResult<Hotel> Fetch()
        {
            var id = _rabbitMQConsumer.ReceiveProductMessage()
                .Result.ToString()
                .Replace("\"", "").Trim();

            Console.WriteLine(id);
            var hotel = adminService.Get(id);
            if (hotel == null)
            {
                return NotFound($"Hotel with Id = {id} not found");
            }

            return hotel;
        }

        // POST api/<AdminController>
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel hotel)
        {
            adminService.Create(hotel);

            return CreatedAtAction(nameof(Get), new { id = hotel.Id }, hotel);
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Hotel hotel)
        {
            var existingHotel = adminService.Get(id);
            if (existingHotel == null)
            {
                return NotFound($"Hotel with Id = {id} not found");
            }

            adminService.Update(id, hotel);
            return NoContent();
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var hotel = adminService.Get(id);
            if (hotel == null)
            {
                return NotFound($"Hotel with Id = {id} not found");
            }

            adminService.Remove(hotel.Id);
            return Ok($"Hotel with Id = {id} deleted");
        }
    }
}
