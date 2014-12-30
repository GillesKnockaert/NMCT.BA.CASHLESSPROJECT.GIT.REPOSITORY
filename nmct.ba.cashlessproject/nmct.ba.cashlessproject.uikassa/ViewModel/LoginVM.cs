using GalaSoft.MvvmLight.CommandWpf;
using nmct.ba.week7.herhaling.ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace nmct.ba.cashlessproject.uikassa.ViewModel
{
    public class LoginVM : ObservableObject, IPage
    {
        public ICommand InloggenCommand
        {
            get { return new RelayCommand(Inloggen); }
        }
        
        private void Inloggen()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;

            appvm.ChangePage(new KassaVM());
        }

        public string Name
        {
            get { return "Login"; }
        }
    }
}
