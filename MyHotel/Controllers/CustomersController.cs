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
        public async Task<ActionResult> Get()
        {
            return Ok(await _customerService.GetAllCustomersAsync());
        }

        // GET api/<CostumerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            //Customer c = dataContext.Costumers.Find(x => x.Id == id);
            //if(c == null)
            //    return NotFound();
            //return c;
            return Ok(_mapper.Map<CustomerDto>(await _customerService.GetCustomerByIdAsync(id)));
        }

        // POST api/<CostumerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomerPostModel c)
        {
            //if (c.Tz.Length != 9)
            //    return BadRequest();
            //Customer c1 = dataContext.Costumers.Find(x => x.Id == c.Id);
            //if (c1 != null)
            //    return BadRequest();
            var customerToAdd = new Customer { Tz = c.Tz,Name=c.Name,Phone=c.Phone,Address=c.Address };
            var newCustomer = await _customerService.AddCustomerAsync(customerToAdd);
            var customerDto = _mapper.Map<CustomerDto>(newCustomer);  
            return Ok(customerDto);
        }

        // PUT api/<CostumerController>/
        // 



        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Customer c)
        {
            //Customer c1 = dataContext.Costumers.Find(x => x.Id == id);
            //if (c1 == null)
            //    return NotFound();
            await _customerService.UpdateCustomerAsync(id, c);
            return Ok();
        }

        // DELETE api/<CostumerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            //Customer c = dataContext.Costumers.Find(x => x.Id == id);
            //if (c == null)
            //    return NotFound();
            await _customerService.DeleteCustomerAsync(id);
            return Ok();    
        }
    }
}
