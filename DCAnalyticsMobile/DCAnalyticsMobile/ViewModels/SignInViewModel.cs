using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DCAnalyticsMobile.ViewModels
{
    class SignInViewModel : BaseViewModel
    {
        private bool _hidePassword = true;
        public Command HideShowPassWordCommand { get; set; }
        public SignInViewModel()
        {
            HideShowPassWordCommand = new Command(ShowHidePassword);
        }

        public bool HidePassword
        {
            set
            {
                if (_hidePassword != value)
                {
                    _hidePassword = value;

                    OnPropertyChanged();
                }
            }
            get => _hidePassword;
        }

        private void ShowHidePassword()
        {
            HidePassword = !HidePassword;
        }
    }
}
