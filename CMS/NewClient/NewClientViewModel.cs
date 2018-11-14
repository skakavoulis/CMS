using CMS.NewClient.PersonalInfo;
using CMS.Tools;
using System.Windows;

namespace CMS.NewClient
{
    public class NewClientViewModel : BaseViewModel
    {
        private PersonalInfoViewModel _personalInfoViewModel;

        public NewClientViewModel()
        {
            _personalInfoViewModel = new PersonalInfoViewModel();
            _personalInfoViewModel.ErrorsChanged += _personalInfoViewModel_ErrorsChanged;
            ActiveViewModel = _personalInfoViewModel;
            NextStep = new RelayCommand(OnNextStep, CanGoNext);
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

        private void OnNextStep(object param)
        {
            MessageBox.Show("Next step");
        }

        private bool CanGoNext(object param)
        {
            return !ActiveViewModel.HasErrors;
        }
    }
}
