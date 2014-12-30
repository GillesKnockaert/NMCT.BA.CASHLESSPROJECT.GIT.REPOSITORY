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

namespace nmct.ba.cashlessproject.uimanage.ViewModel
{
    public class KassaVM : ObservableObject, IPage
    {
        public KassaVM()
        {
            if (ApplicationVM.token != null)
            {
                GetKassas();
            }
        }

        private ObservableCollection<Kassa> _kassas;

        public ObservableCollection<Kassa> Kassas
        {
            get { return _kassas; }
            set { _kassas = value; OnPropertyChanged("Kassas"); }
        }
        
        private Kassa _selected;

        public Kassa Selected
        {
            get { return _selected; }
            set { _selected = value; GetEmployees(); OnPropertyChanged("Selected"); }
        }

        private ObservableCollection<Employee> _employees;

        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; OnPropertyChanged("Employees"); }
        }
        

        private async void GetKassas()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.GetAsync("http://localhost:4904//api/kassaWPF");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Kassas = JsonConvert.DeserializeObject<ObservableCollection<Kassa>>(json);
                }
            }
        }

        private async void GetEmployees()
        {
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(ApplicationVM.token.AccessToken);
                HttpResponseMessage response = await client.GetAsync("http://localhost:4904//api/kassaWPF/" + Selected.ID);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    Employees = JsonConvert.DeserializeObject<ObservableCollection<Employee>>(json);
                }
            }
        }

        public string Name
        {
            get { return "Kassa"; }
        }
    }
}
