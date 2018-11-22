using CMS.Models;
using CMS.NewClient.AddressInfo;
using CMS.NewClient.PersonalInfo;
using CMS.Tools;
using System;

namespace CMS.NewClient
{
    public class NewClientViewModel : BaseViewModel
    {
        private PersonalInfoViewModel _personalInfoViewModel;
        private AddressInfoViewModel _addressViewModel;

        private BaseViewModel[] _navigationMap;
        private int _navigationIndex = 0;

        public NewClientViewModel()
        {
            _personalInfoViewModel = new PersonalInfoViewModel();
            _addressViewModel = new AddressInfoViewModel();
            _navigationMap = new BaseViewModel[] { _personalInfoViewModel, _addressViewModel };
            _personalInfoViewModel.ErrorsChanged += _personalInfoViewModel_ErrorsChanged;
            ActiveViewModel = _navigationMap[_navigationIndex];
            NextStep = new RelayCommand(OnNextStep, CanGoNext);
            PrevStep = new RelayCommand(OnPrevStep);
        }

        private void _personalInfoViewModel_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
        {
            NextStep.OnCanExecuteChanged();
        }

        private BaseViewModel _activeViewModel;
        public BaseViewModel ActiveViewModel
        {
            get => _activeViewModel;
            set => SetPropertyValue(ref _activeViewModel, value);
        }

        public RelayCommand NextStep { get; set; }

        public RelayCommand PrevStep { get; set; }


        private void OnNextStep(object param)
        {
            if (_navigationIndex == _navigationMap.Length - 1)
            {
                NewClientCreated?.Invoke(this, new Client
                {
                    Name = _personalInfoViewModel.Name,
                    Type = ClientTypeEnum.Ιδιώτης,
                    Birthday = _personalInfoViewModel.Birthday,
                    ClientSince = DateTime.UtcNow,
                    Address = new Address
                    {
                        City = _addressViewModel.City,
                        Country = _addressViewModel.Country,
                        PostCode = _addressViewModel.PostCode,
                        StreetName = _addressViewModel.StreetName,
                    },
                    ClientId = Guid.NewGuid(),
                    Lastname = _personalInfoViewModel.LastName
                });
            }
            else
            {
                _navigationIndex += 1;
                ActiveViewModel = _navigationMap[_navigationIndex];
            }
        }

        private bool CanGoNext(object param)
        {
            //return !ActiveViewModel.HasErrors;
            return true;
        }

        private void OnPrevStep(object param)
        {
            if (_navigationIndex == 0)
            {
                NewClientCancelled?.Invoke(this);
            }
            else
            {
                _navigationIndex -= 1;
                ActiveViewModel = _navigationMap[_navigationIndex];
            }
        }

        public event NewClientCancelledDelegate NewClientCancelled;
        public event NewClientCreatedDelegate NewClientCreated;

    }

    public delegate void NewClientCreatedDelegate(object sender, Client args);

    public delegate void NewClientCancelledDelegate(object sender);
}
