using GalaSoft.MvvmLight.Command;
using Northwind.Application;
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

        private string _selectedCustomerID;
        public string SelectedCustomerID
        {
            get
            {
                return _selectedCustomerID;
            }
            set
            {
                _selectedCustomerID = value;
                ShowDetailsCommand.RaiseCanExecuteChanged();
            }
        }

        private RelayCommand _showDetailsCommand;
        public RelayCommand ShowDetailsCommand
        {
            get
            {
                return _showDetailsCommand ?? (_showDetailsCommand = new RelayCommand(ShowCustomerDetails, IsCustomerSelected));
            }
        }

        private bool IsCustomerSelected()
        {
            return !string.IsNullOrEmpty(SelectedCustomerID);
        }

        public MainWindowViewModel(IUIDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            Tools = new ObservableCollection<ToolViewModel>();
            //Tools.Add(new CustomerDetailsViewModel(_dataProvider, "ALFKI"));

        }
        private void GetCustomers()
        {
            _customers = _dataProvider.GetCustomers();
        }

        public void ShowCustomerDetails()
        {
            if (!IsCustomerSelected())
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
