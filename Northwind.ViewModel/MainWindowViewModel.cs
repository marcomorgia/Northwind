using Northwind.Application;
using Northwind.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Northwind.ViewModel
{
    public class MainWindowViewModel
    {
        private readonly IUIDataProvider _dataProvider;
        public string Name { get { return "Northwind"; } }
        public string ControlPanelName { get { return "Control Panel"; } }

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

        public ObservableCollection<ToolViewModel> Tools { get; set; }

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
    }
}
