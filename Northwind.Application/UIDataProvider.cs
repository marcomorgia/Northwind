

using Northwind.Application.CustomerService;
using Northwind.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Application
{
    public class UIDataProvider : IUIDataProvider
    {

        private IList<Model.Customer> _customers;

        private readonly ICustomerService _customerServiceClient;

        public UIDataProvider(ICustomerService customerService)
        {
            _customerServiceClient = customerService;
        }

        public Customer GetCustomer(string CustomerID)
        {
            return CustomerTranslator.Instance.UpdateModel(_customers.First(c => c.CustomerID == CustomerID), _customerServiceClient.GetCustomer(CustomerID));
        }

        public IList<Customer> GetCustomers()
        {
            return _customers ?? (_customers = _customerServiceClient.GetCustomers().Select(c => CustomerTranslator.Instance.CreateModel(c)).ToList());
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }

    internal static class CustomerExtensions
    {
        public static Customer Update(this Customer customer, Customer existingCustomer)
        {
            customer.Address = existingCustomer.Address;
            customer.City = existingCustomer.City;
            customer.CompanyName = existingCustomer.CompanyName;
            customer.ContactName = existingCustomer.ContactName;
            customer.Country = existingCustomer.Country;
            customer.CustomerID = existingCustomer.CustomerID;
            customer.Phone = existingCustomer.Phone;
            customer.PostalCode = existingCustomer.PostalCode;
            customer.Region = existingCustomer.Region;

            return customer;
        }
    }
}
