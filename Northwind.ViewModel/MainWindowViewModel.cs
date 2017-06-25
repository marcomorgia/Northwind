using Northwind.Application;
using Northwind.Data;
using Northwind.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Northwind.ViewModel
{
    public class MainWindowViewModel
    {
        private readonly IUIDataProvider _dataProvider;
        public string Name { get { return "Northwind"; } }
        public string ControlPanelName { get { return "Control Panel"; } }

        private IList<Customer> _customers;

        public IList<Customer> Customers
        {
            get
            {
                if (_customers == null)
                    GetCustomers();

                return _customers;
            }
        }

        public ObservableCollection<ToolViewModel> Tools { get; set; }
        public string SelectedCustomerID { get; set; }

        public MainWindowViewModel(IUIDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Tools = new ObservableCollection<ToolViewModel>();
            Tools.Add(new CustomerDetailsViewModel(_dataProvider, "ALFKI"));

        }
        private void GetCustomers()
        {
            _customers = _dataProvider.GetCustomers();
        }

        public void ShowCustomerDetails()
        {
            if (string.IsNullOrEmpty(SelectedCustomerID))
                throw new InvalidOperationException();

            CustomerDetailsViewModel customerDetailsViewModel = GetCustomerDetailsTool(SelectedCustomerID);

            if (customerDetailsViewModel == null)
            {
                customerDetailsViewModel = new CustomerDetailsViewModel(_dataProvider, SelectedCustomerID);
                Tools.Add(customerDetailsViewModel);
            }

            SetCurrentTool(customerDetailsViewModel);
        }

        private void SetCurrentTool(ToolViewModel currentTool)
        {
            ICollectionView collectionView = CollectionViewSource.GetDefaultView(Tools);

            if (collectionView != null)
            {
                if (collectionView.MoveCurrentTo(currentTool) != true)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private CustomerDetailsViewModel GetCustomerDetailsTool(string selectedCustoerID)
        {
            return Tools.OfType<CustomerDetailsViewModel>().FirstOrDefault(c => c.Customer.CustomerID == selectedCustoerID);
        }
    }
}
