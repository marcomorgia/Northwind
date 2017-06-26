

using Northwind.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace Northwind.Application
{
    public interface IUIDataProvider
    {
        IList<Model.Customer> GetCustomers();
        Model.Customer GetCustomer(string CustomerID);

        [OperationContract]
        void Update(Customer customer);
    }
}
