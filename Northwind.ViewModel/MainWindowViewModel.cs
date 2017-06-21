using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ViewModel
{
    public class MainWindowViewModel
    {
        private IList<Customers> _customers;

        public IList<Customers> Customers
        {
          get
            {
                if (_customers == null)
                    GetCustomers();

                return _customers;
            }
        }

        private void GetCustomers()
        {
            _customers = new NORTHWNDEntities().Customers.ToList();
        }
    }
}
