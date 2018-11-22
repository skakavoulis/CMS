using CMS.Tools;

namespace CMS.NewClient.Address
{
    public class AddressViewModel : BaseViewModel
    {
        public AddressViewModel()
        {

        }

        private string _street;
        public string Street
        {
            get => _street;
            set => SetPropertyValue(ref _street, value);
        }

        private int _streetNumber;
        public int StreetNumber
        {
            get => _streetNumber;
            set => SetPropertyValue(ref _streetNumber, value);
        }

        private string _postCode;
        public string PostCode
        {
            get => _postCode;
            set => SetPropertyValue(ref _postCode, value);
        }

        private string _city;
        public string City
        {
            get => _postCode;
            set => SetPropertyValue(ref _city, value);
        }

        private string _country;
        public string Country
        {
            get => _postCode;
            set => SetPropertyValue(ref _country, value);
        }
    }
}
