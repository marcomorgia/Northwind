namespace Northwind.Model
{
    public class Customer : ModelBase
    {
        private string _customerID;

        public string CustomerID
        {
            get { return _customerID; }
            set
            {
                if (_customerID == value)
                    return;

                _customerID = value;

                RaisePropertyChanged();
            }
        }

        private string _companyName;

        public string CompanyName
        {
            get { return _companyName; }
            set
            {

                if (_companyName == value)
                    return;

                _companyName = value;

                RaisePropertyChanged();
            }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {

                if (_address == value)
                    return;

                _address = value;

                RaisePropertyChanged();

            }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set
            {

                if (_city == value)
                    return;

                _city = value;

                RaisePropertyChanged();
            }
        }


        private string _contactName;

        public string ContactName
        {
            get { return _contactName; }
            set
            {

                if (_contactName == value)
                    return;

                _contactName = value;

                RaisePropertyChanged();
            }
        }

        private string _country;

        public string Country
        {
            get { return _country; }
            set
            {

                if (_country == value)
                    return;

                _country = value;

                RaisePropertyChanged();

            }
        }


        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {

                if (_phone == value)
                    return;

                _phone = value;

                RaisePropertyChanged();

            }
        }

        private string _postaCode;

        public string PostalCode
        {
            get { return _postaCode; }
            set
            {

                if (_postaCode == value)
                    return;
                _postaCode = value;

                RaisePropertyChanged();
            }
        }

        private string _region;

        public string Region
        {
            get { return _region; }
            set
            {

                if (_region == value)
                    return;

                _region = value;

                RaisePropertyChanged();
            }
        }


    }
}
