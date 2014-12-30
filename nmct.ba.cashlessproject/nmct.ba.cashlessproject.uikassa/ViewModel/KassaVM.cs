
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using nmct.ba.cashlessproject.model;
using nmct.ba.week7.herhaling.ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace nmct.ba.cashlessproject.uikassa.ViewModel
{
    public class KassaVM : ObservableObject, IPage
    {
        public KassaVM()
        {
            GetProducten();
        }

        private Employee _employee;

        public Employee Employee
        {
            get { return _employee; }
            set { _employee = ApplicationVM.employee; OnPropertyChanged("Employee"); }
        }
        

        private ObservableCollection<Products> _producten;

        public ObservableCollection<Products> Producten
        {
            get { return _producten; }
            set { _producten = value; OnPropertyChanged("Producten"); }
        }

        private Products _selected;

        public Products Selected
        {
            get { return _selected; }
            set { _selected = value; AddToBestelling(); OnPropertyChanged("Selected"); }
        }

        private void AddToBestelling()
        {
            Bestelling.Add(Selected);
        }

        private ObservableCollection<Products> _bestelling;

        public ObservableCollection<Products> Bestelling
        {
            get { return _bestelling; }
            set { _bestelling = value; OnPropertyChanged("Bestelling"); }
        }

        private async void GetProducten()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:4904//api/Bestelling");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Producten = JsonConvert.DeserializeObject<ObservableCollection<Products>>(json);
                }
            }
        }

        public ICommand AfmeldenCommand
        {
            get { return new RelayCommand(Afmelden); }
        }

        private void Afmelden()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;

            appvm.ChangePage(new LoginVM());
        }

        public string Name
        {
            get { return "Kassa"; }
        }
    }
}
