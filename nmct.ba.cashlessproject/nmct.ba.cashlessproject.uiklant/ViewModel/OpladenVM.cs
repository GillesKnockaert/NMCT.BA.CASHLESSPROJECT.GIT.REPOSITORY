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
    public class OpladenVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Opladen"; }
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
    }
}
