

using Northwind.Application.CustomerService;

using System.Collections.Generic;
using System.Linq;
using Northwind.Model;
using System;

namespace Northwind.Application
{
    public class UIDataProvider : IUIDataProvider
    {



        private readonly CustomerServiceClient _customerServiceClient = new CustomerServiceClient();

        public IList<Model.Customer> GetCustomers()
        {
            return _customerServiceClient.GetCustomers().Select(c => new Model.Customer().Update(c)).ToList();
        }

        public Model.Customer GetCustomer(string customerID)
        {
            return new Model.Customer().Update(_customerServiceClient.GetCustomer(customerID));
        }
    }

    //internal static class CustomerExtensions
    //{
    //    public static Customer Update(this Customer customer, Customer existingCustomer)
    //    {
    //        customer.Address = existingCustomer.Address;
    //        customer.City = existingCustomer.City;
    //        customer.CompanyName = existingCustomer.CompanyName;
    //        customer.ContactName = existingCustomer.ContactName;
    //        customer.Country = existingCustomer.Country;
    //        customer.CustomerID = existingCustomer.CustomerID;
    //        customer.Phone = existingCustomer.Phone;
    //        customer.PostalCode = existingCustomer.PostalCode;
    //        customer.Region = existingCustomer.Region;

    //        return customer;
    //    }
    //}
}
