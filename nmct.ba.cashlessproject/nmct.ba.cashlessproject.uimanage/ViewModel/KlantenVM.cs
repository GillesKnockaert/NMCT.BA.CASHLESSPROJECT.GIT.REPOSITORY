using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using Newtonsoft.Json;
using nmct.ba.cashlessproject.model;
using nmct.ba.week7.herhaling.ui.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace nmct.ba.cashlessproject.uimanage.ViewModel
{
    public class KlantenVM : ObservableObject, IPage
    {
        public KlantenVM()
        {
            if (ApplicationVM.token != null)
            {
                GetKlanten();
            }
        }

        private ObservableCollection<Customer> _klanten;

        public ObservableCollection<Customer> Klanten
        {
            get { return _klanten; }
            set { _klanten = value; OnPropertyChanged("Klanten"); }
        }

        private Customer _selected;

        public Customer Selected
        {
            get { return _selected; }
            set { _selected = value; OnPropertyChanged("Selected"); }
        }

        private async void GetKlanten()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.GetAsync("http://localhost:4904//api/klanten");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Klanten = JsonConvert.DeserializeObject<ObservableCollection<Customer>>(json);
                }
            }
        }

        //EDIT
        public ICommand UpdateCommand
        {
            get { return new RelayCommand(Update); }
        }

        private async void Update()
        {
            string input = JsonConvert.SerializeObject(Selected);

            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.PutAsync("http://localhost:4904/api/klanten", new StringContent(input, Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("error");
                }
            }
        }

        public ICommand AddImageCommand
        {
            get { return new RelayCommand(AddImage); }
        }

        private void AddImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                Selected.Picture = GetPhoto(ofd.FileName);
                OnPropertyChanged("Selected");
            }
        }

        private byte[] GetPhoto(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, (int)fs.Length);
            fs.Close();
            return data;
        }


        public string Name
        {
            get { return "Klanten"; }
        }
    }
}
