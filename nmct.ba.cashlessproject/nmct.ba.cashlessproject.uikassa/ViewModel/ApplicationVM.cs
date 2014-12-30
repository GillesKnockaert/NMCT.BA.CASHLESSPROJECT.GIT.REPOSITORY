using GalaSoft.MvvmLight.Command;
using nmct.ba.cashlessproject.model;
using nmct.ba.week7.herhaling.ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace nmct.ba.cashlessproject.uikassa.ViewModel
{
    public class ApplicationVM : ObservableObject
    {
        public static Employee employee = null;

        public ApplicationVM()
        {   
            Pages.Add(new LoginVM());
            Pages.Add(new KassaVM());
            //If you want the PageOne to be visible when started, add the following line of code: CurrentPage = Pages[0];

            CurrentPage = Pages[0];
        }

        private IPage currentPage;
        public IPage CurrentPage
        {
            get { return currentPage; }
            set { currentPage = value; OnPropertyChanged("CurrentPage"); }
        }

        private List<IPage> pages;
        public List<IPage> Pages
        {
            get
            {
                if (pages == null)
                {
                    pages = new List<IPage>();
                }
                return pages;
            }
        }

        public ICommand ChangePageCommand
        {
            get { return new RelayCommand<IPage>(ChangePage); }
        }

        public void ChangePage(IPage page)
        {
            CurrentPage = page;
        }
    }
}
