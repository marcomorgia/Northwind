using GalaSoft.MvvmLight.Command;
using Northwind.Application;
using Northwind.Model;
using System.ComponentModel;

namespace Northwind.ViewModel
{
    public class CustomerDetailsViewModel : ToolViewModel
    {
        private readonly IUIDataProvider _dataProvider;

        public Customer Customer { get; set; }

        private bool _isDirty;

        private RelayCommand _updateCommand;

        public RelayCommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new RelayCommand(UpdateCustomer, CanUpdateCustomer));
            }
        }

        private bool CanUpdateCustomer()
        {
            return _isDirty;
        }

        private void UpdateCustomer()
        {
            _dataProvider.Update(Customer);
        }

        public CustomerDetailsViewModel(IUIDataProvider dataProvider, string customerID)
        {
            _dataProvider = dataProvider;
            Customer = _dataProvider.GetCustomer(customerID);
            Customer.PropertyChanged += Customer_PropertyChanged;
            DisplayName = Customer.CompanyName;
        }

        private void Customer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _isDirty = true;
            UpdateCommand.RaiseCanExecuteChanged();
        }
    }
}
