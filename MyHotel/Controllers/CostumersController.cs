using Microsoft.AspNetCore.Mvc;
using MyHotel.Core.Services;
using MyHotel.Data;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostumerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CostumerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CostumerController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        // GET api/<CostumerController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(string id)
        {
            //Customer c = dataContext.Costumers.Find(x => x.Id == id);
            //if(c == null)
            //    return NotFound();
            //return c;
            return Ok(_customerService.GetCustomerById(id));
        }

        // POST api/<CostumerController>
        [HttpPost]
        public ActionResult Post([FromBody] Customer c)
        {
            if (c.Id.Length != 9)
                return BadRequest();
            //Customer c1 = dataContext.Costumers.Find(x => x.Id == c.Id);
            //if (c1 != null)
            //    return BadRequest();
            _customerService.AddCustomer(c);    
            return Ok();
        }

        // PUT api/<CostumerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Customer c)
        {
            //Customer c1 = dataContext.Costumers.Find(x => x.Id == id);
            //if (c1 == null)
            //    return NotFound();
            _customerService.UpdateCustomer(id, c);
            return Ok();
        }

        // DELETE api/<CostumerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            //Customer c = dataContext.Costumers.Find(x => x.Id == id);
            //if (c == null)
            //    return NotFound();
            _customerService.DeleteCustomer(id);
            return Ok();    
        }
    }
}
