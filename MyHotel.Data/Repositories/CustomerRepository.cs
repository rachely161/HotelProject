using MyHotel.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Data.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public void AddCustomer(Customer customer)
        {
            _context.Costumers.Add(new Customer { Id = customer.Id, Phone = customer.Phone, Address = customer.Address, Name = customer.Name });
        }

        public void DeleteCustomer(string id)
        {
            Customer c = _context.Costumers.ToList().Find(x => x.Id == id);
            _context.Costumers.Remove(c);
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Costumers.ToList();
        }

        public Customer GetCustomerById(string id)
        {
            return _context.Costumers.First(c => c.Id==id);
        }

        public void UpdateCustomer(string id, Customer customer)
        {
            Customer c1 = _context.Costumers.ToList().Find(x => x.Id == id);
            c1.Phone = customer.Phone;
            c1.Address = customer.Address;
        }
    }
}
