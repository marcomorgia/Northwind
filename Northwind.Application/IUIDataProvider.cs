using Northwind.Data;
using System.Collections.Generic;

namespace Northwind.Application
{
    public interface IUIDataProvider
    {
        IList<Customers> GetCustomers();
    }
}
