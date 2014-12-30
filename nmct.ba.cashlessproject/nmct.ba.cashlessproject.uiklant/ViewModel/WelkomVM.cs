using be.belgium.eid;
using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using nmct.ba.cashlessproject.model;
using nmct.ba.week7.herhaling.ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace nmct.ba.cashlessproject.uiklant.ViewModel
{
    public class WelkomVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Welkom"; }
        }

        private string _error;
        public string Error
        {
            get { return _error; }
            set { _error = value; OnPropertyChanged("Error"); }
        }

        public ICommand GoToGegevensVM
        {
            get { return new RelayCommand(GoToGegevens); }
        }

        private void GoToGegevens()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;

            Customer c = GetCustomerFromReader();

            if (c == null)
            {
                Error = "Gelieve een geldige kaart in de lezer te stoppen";
            }
            else if (ApplicationVM.customer == null)
            {
                Error = "Gelieve eerst te registreren";
            }
            else
            {
                appvm.ChangePage(new GegevensVM());
            }
        }

        private Customer GetCustomerFromReader()
        {
            Customer customer = new Customer();

            try
            {
                BEID_ReaderSet readerSet = BEID_ReaderSet.instance();
                BEID_ReaderContext reader = readerSet.getReader();

                if (reader.isCardPresent())
                {
                    BEID_EIDCard card = reader.getEIDCard();
                    BEID_EId doc = card.getID();

                    string firstName = doc.getFirstName();
                    string lastName = doc.getSurname();
                    string address = doc.getStreet().Trim();

                    customer.CustomerName = firstName + " " + lastName;
                    customer.Address = address;
                    customer.Picture = card.getPicture().getData().GetBytes();
                }
                else
                {
                    customer = null;
                }

                BEID_ReaderSet.releaseSDK();
            }
            catch (Exception ex)
            {
                Console.Write("Fout bij het lezen van de kaart");
                return null;
            }

            GetCustomer(customer);

            return ApplicationVM.customer;
        }

        private async void GetCustomer(Customer c)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:4904//api/klanten/" + c.CustomerName);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    ApplicationVM.customer = JsonConvert.DeserializeObject<Customer>(json);
                }
            }
        }

        public ICommand GoToRegistrerenVM
        {
            get { return new RelayCommand(GoToRegistreren); }
        }

        private void GoToRegistreren()
        {
            ApplicationVM appvm = App.Current.MainWindow.DataContext as ApplicationVM;

            appvm.ChangePage(new RegistrerenVM());
        }
    }
}
