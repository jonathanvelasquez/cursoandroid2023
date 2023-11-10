using cursoandroid2023.Maui.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cursoandroid2023.Maui.MVVM.Models;
using cursoandroid2023.Maui.Services;
using System.Collections.ObjectModel;

namespace cursoandroid2023.Maui.MVVM.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private readonly IApiService _apiService;
        private ObservableCollection<Person> _people;

        public PersonViewModel(IApiService apiService)
        {
            _apiService = apiService;
            LoadPersonAsync();
            
        }

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set
            {
                if (_people != value)
                {
                    _people = value;
                    OnPropertyChanged(nameof(People));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

        private async void LoadPersonAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No tiene internet, verifique sus datos", "Aceptar");
                return;
            }

            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<Person>(url, "/api", "/people");
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            People = new ObservableCollection<Person>((List<Person>)response.Result);
        }


    }
}
