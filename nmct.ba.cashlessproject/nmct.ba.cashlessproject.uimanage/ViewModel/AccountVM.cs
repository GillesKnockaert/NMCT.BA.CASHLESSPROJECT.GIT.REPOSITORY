using GalaSoft.MvvmLight.CommandWpf;
using nmct.ba.week7.herhaling.ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace nmct.ba.cashlessproject.uimanage.ViewModel
{
    public class AccountVM : ObservableObject, IPage
    {
        
        
        public ICommand SignOutCommand
        {
            get { return new RelayCommand(SignOut); }
        }

        private void SignOut()
        {
            //SIGN OUT!
            ApplicationVM.token = null;

            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;
            appvm.ChangePage(new LoginVM());
        }

        public string Name
        {
            get { return "Account"; }
        }
    }
}
