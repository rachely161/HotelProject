using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Core.Services
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(string id);
        Customer AddCustomer(Customer customer);
        void UpdateCustomer(string id, Customer customer);
        void DeleteCustomer(string id);
    }
}
