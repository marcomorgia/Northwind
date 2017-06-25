using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly NORTHWNDEntities _northwindEntities = new NORTHWNDEntities();
        public Customer GetCustomer(string customerID)
        {
            Northwind.Data.Customers customer = _northwindEntities.Customers.Single(
                c => c.CustomerID == customerID);

            return new Northwind.Service.Customer
            {
                Address = customer.Address,
                City = customer.City,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                Country = customer.Country,
                CustomerID = customer.CustomerID,
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                Region = customer.Region
            };
        }

        public IList<Customer> GetCustomers()
        {
            return _northwindEntities.Customers.Select(
               c => new Northwind.Service.Customer
               {
                   CustomerID = c.CustomerID,
                   CompanyName = c.CompanyName
               }).ToList();
        }
    }
}
