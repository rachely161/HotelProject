using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private static List<Costumer> costumers = new List<Costumer>();
        // GET: api/<CostumerController>
        [HttpGet]
        public IEnumerable<Costumer> Get()
        {
            return costumers;
        }

        // GET api/<CostumerController>/5
        [HttpGet("{id}")]
        public Costumer Get(string id)
        {
            Costumer c = costumers.Find(x => x.Id == id);
            return c;
        }

        // POST api/<CostumerController>
        [HttpPost]
        public void Post([FromBody] Costumer c)
        {
            costumers.Add(new Costumer { Id=c.Id, Phone=c.Phone,Address=c.Address,Name=c.Name });
        }

        // PUT api/<CostumerController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Costumer c)
        {
            Costumer c1 = costumers.Find(x => x.Id == id);
            c1.Phone = c.Phone;
            c1.Address = c.Address;
        }

        // DELETE api/<CostumerController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Costumer c = costumers.Find(x => x.Id == id);
            costumers.Remove(c);
        }
    }
}
