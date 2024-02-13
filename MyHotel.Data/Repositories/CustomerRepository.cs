using Microsoft.EntityFrameworkCore;
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

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Costumers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            Customer c = await GetCustomerByIdAsync(id);
            _context.Costumers.Remove(c);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Costumers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _context.Costumers.FindAsync(id);
        }

        public async Task<Customer> UpdateCustomerAsync(int id, Customer customer)
        {
            Customer c1 = await GetCustomerByIdAsync(id);
            c1.Phone = customer.Phone;
            c1.Address = customer.Address;
            c1.Name = customer.Name;
            await _context.SaveChangesAsync();
            return c1;

        }
    }
}
