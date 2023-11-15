using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        DataContext dataContext;
        public CostumerController(DataContext context)
        {
            dataContext= context;
        }
        // GET: api/<CostumerController>
        [HttpGet]
        public IEnumerable<Costumer> Get()
        {
            return dataContext.Costumers;
        }

        // GET api/<CostumerController>/5
        [HttpGet("{id}")]
        public ActionResult<Costumer> Get(string id)
        {
            Costumer c = dataContext.Costumers.Find(x => x.Id == id);
            if(c == null)
                return NotFound();
            return c;
        }

        // POST api/<CostumerController>
        [HttpPost]
        public ActionResult Post([FromBody] Costumer c)
        {
            if (c.Id.Length != 9)
                return BadRequest();
            Costumer c1 = dataContext.Costumers.Find(x => x.Id == c.Id);
            if (c1 != null)
                return BadRequest();
            dataContext.Costumers.Add(new Costumer { Id=c.Id, Phone=c.Phone,Address=c.Address,Name=c.Name });
            return Ok();
        }

        // PUT api/<CostumerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Costumer c)
        {
            Costumer c1 = dataContext.Costumers.Find(x => x.Id == id);
            if (c1 == null)
                return NotFound();
            c1.Phone = c.Phone;
            c1.Address = c.Address;
            return Ok();
        }

        // DELETE api/<CostumerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            Costumer c = dataContext.Costumers.Find(x => x.Id == id);
            if (c == null)
                return NotFound();
            dataContext.Costumers.Remove(c);
            return Ok();    
        }
    }
}
