using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace nmct.ba.cashlessproject.uiklant.ViewModel
{
    public class RegistrerenVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Registreren"; }
        }

        public ICommand GoToGegevensVM
        {
            get { return new RelayCommand(GoToGegevens); }
        }

        private void GoToGegevens()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;

            appvm.ChangePage(new GegevensVM());
        }

        public ICommand GoToWelkomVM
        {
            get { return new RelayCommand(GoToWelkom); }
        }

        private void GoToWelkom()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;

            appvm.ChangePage(new WelkomVM());
        }
    }
}
