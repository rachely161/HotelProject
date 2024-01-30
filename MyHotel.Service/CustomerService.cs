using MyHotel.Core.Repositories;
using MyHotel.Core.Services;

namespace MyHotel.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository=customerRepository;
        }
    
        public Customer AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer); 
        }

        public void DeleteCustomer(string id)
        {
            _customerRepository.DeleteCustomer(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public Customer GetCustomerById(string id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public void UpdateCustomer(string id, Customer customer)
        {
            _customerRepository.UpdateCustomer(id, customer);  
        }
    }
}