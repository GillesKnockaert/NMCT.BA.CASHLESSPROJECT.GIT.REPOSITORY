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

namespace nmct.ba.cashlessproject.uimanage.ViewModel
{
    public class ProductenVM : ObservableObject, IPage
    {
        public ProductenVM()
        {
            if (ApplicationVM.token != null)
            {
                GetProducts();
            }
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
            set { _selected = value; OnPropertyChanged("Selected"); }
        }
        

        private async void GetProducts()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.GetAsync("http://localhost:4904//api/product");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Producten = JsonConvert.DeserializeObject<ObservableCollection<Products>>(json);
                }
            }
        }

        //NEW
        public ICommand InsertCommand
        {
            get { return new RelayCommand(Insert); }
        }

        private void Insert()
        {
            Products p = new Products();
            Producten.Add(p);
            Selected = p;
        }

        //EDIT
        public ICommand UpdateCommand
        {
            get { return new RelayCommand(Update); }
        }

        private async void Update()
        {
            string input = JsonConvert.SerializeObject(Selected);

            //controleer of selected nieuw is of al reeds is aangemaakt in database
            if (Selected.ID == 0)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.SetBearerToken(ApplicationVM.token.AccessToken);
                    HttpResponseMessage response = await client.PostAsync("http://localhost:4904/api/product", new StringContent(input, Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        string output = await response.Content.ReadAsStringAsync();
                        Selected.ID = Int32.Parse(output);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
            }
            else
            {
                using (HttpClient client = new HttpClient())
                {
                    client.SetBearerToken(ApplicationVM.token.AccessToken);
                    HttpResponseMessage response = await client.PutAsync("http://localhost:4904/api/product", new StringContent(input, Encoding.UTF8, "application/json"));
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("error");
                    }
                }
            }
        }

        //DELETE
        public ICommand DeleteCommand
        {
            get { return new RelayCommand(Delete); }
        }

        private async void Delete()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.DeleteAsync("http://localhost:4904/api/product/" + Selected.ID);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("error");
                }
                else
                {
                    Producten.Remove(Selected);
                }
            }
        }

        public string Name
        {
            get { return "Producten"; }
        }
    }
}
