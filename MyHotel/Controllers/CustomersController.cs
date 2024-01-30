using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyHotel.Api.models;
using MyHotel.Core.DTOs;
using MyHotel.Core.Services;
using MyHotel.Data;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyHotel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService,IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        // GET: api/<CostumerController>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        // GET api/<CostumerController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> Get(string id)
        {
            //Customer c = dataContext.Costumers.Find(x => x.Id == id);
            //if(c == null)
            //    return NotFound();
            //return c;
            return Ok(_mapper.Map<CustomerDto>( _customerService.GetCustomerById(id)));
        }

        // POST api/<CostumerController>
        [HttpPost]
        public ActionResult Post([FromBody] CustomerPostModel c)
        {
            //if (c.Tz.Length != 9)
            //    return BadRequest();
            //Customer c1 = dataContext.Costumers.Find(x => x.Id == c.Id);
            //if (c1 != null)
            //    return BadRequest();
            var customerToAdd = new Customer { Tz = c.Tz,Name=c.Name,Phone=c.Phone,Address=c.Address };
            var newCustomer = _customerService.AddCustomer(customerToAdd);
            var customerDto = _mapper.Map<CustomerDto>(newCustomer);  
            return Ok(customerDto);
        }

        // PUT api/<CostumerController>/
        // 



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
