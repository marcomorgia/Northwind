

using Northwind.Model;
using System.Collections.Generic;

namespace Northwind.Application
{
    public interface IUIDataProvider
    {
        IList<Model.Customer> GetCustomers();
        Model.Customer GetCustomer(string CustomerID);
    }
}
