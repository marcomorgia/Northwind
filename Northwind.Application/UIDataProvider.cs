using Northwind.Data;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Application
{
    public class UIDataProvider : IUIDataProvider
    {
        private NORTHWNDEntities _northwindEntities = new NORTHWNDEntities();

        public Customers GetCustomer(string CustomerID)
        {
            return _northwindEntities.Customers.Single(c => c.CustomerID == CustomerID);
        }

        public IList<Customers> GetCustomers()
        {
            return _northwindEntities.Customers.ToList();
        }

    }
}
