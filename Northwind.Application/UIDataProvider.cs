using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Data;

namespace Northwind.Application
{
    public class UIDataProvider : IUIDataProvider
    {
        public IList<Customers> GetCustomers()
        {
            return new NORTHWNDEntities().Customers.ToList();
        }
    }
}
