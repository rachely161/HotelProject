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
            _context.Costumers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(string id)
        {
            Customer c = GetCustomerById(id);
            _context.Costumers.Remove(c);
            _context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Costumers.ToList();
        }

        public Customer GetCustomerById(string id)
        {
            return _context.Costumers.Find(id);
        }

        public void UpdateCustomer(string id, Customer customer)
        {
            Customer c1 = GetCustomerById(id);
            c1.Phone = customer.Phone;
            c1.Address = customer.Address;
            c1.Name = customer.Name;
            _context.SaveChanges();

        }
    }
}
