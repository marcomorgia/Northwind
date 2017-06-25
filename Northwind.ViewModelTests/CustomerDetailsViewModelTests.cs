using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Application;
using Rhino.Mocks;
using Northwind.ViewModel;
using Northwind.Model;

namespace Northwind.ViewModelTests
{
    [TestClass]
    public class CustomerDetailsViewModelTests
    {
        [TestMethod]
        public void Ctor_Always_CallsGetCustomer()
        {
            IUIDataProvider uiDataProviderMock = MockRepository.GenerateMock<IUIDataProvider>();
            const string expectedID = "EXPECTEDID";

            uiDataProviderMock.Expect(c => c.GetCustomer(expectedID)).Return(new Customer());

            CustomerDetailsViewModel target = new CustomerDetailsViewModel(uiDataProviderMock, expectedID);

            uiDataProviderMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void Customer_Always_ReturnCustomerFromGetCustomer()
        {
            IUIDataProvider uiDataProviderStub = MockRepository.GenerateStub<IUIDataProvider>();
            const string expectedID = "EXPECTEDID";
            Customer expectedCustomer = new Customer
            {
                CustomerID = expectedID
            };

        }
    }
}
