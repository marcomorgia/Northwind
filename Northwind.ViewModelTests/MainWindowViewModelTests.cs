using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Data;
using System.Collections.Generic;
using Rhino.Mocks;
using Northwind.Application;
using Northwind.Model;

namespace Northwind.ViewModel.Tests
{
    [TestClass()]
    public class MainWindowViewModelTests
    {
        [TestMethod()]
        public void Customers_Always_CallsGetCustomers()
        {
            IList<Customers> expected = GetCustomers();
    

            IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();

            MainWindowViewModel target = new MainWindowViewModel(uiDataProviderMock);
            IList<Customer> customers = target.Customers;

            uiDataProviderMock.VerifyAllExpectations();

        }

        private IList<Customers> GetCustomers()
        {
            const int numberOfCustomer = 10;

            IList<Customers> customers = new List<Customers>();

            for (int i = 0; i < numberOfCustomer; i++)
            {
                customers.Add(new Customers
                {
                    CustomerID = "CustomerID " + i,
                    CompanyName = "Company Name " + i
                });
            }

            return customers;
        }
    }
}