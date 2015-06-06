using Eksi.Models;
using Eksi.SDK;
using Eksi.WP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Eksi.WP.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private static HttpClient client = new HttpClient();

        private bool isInProgress;

        public bool IsInProgress
        {
            get { return isInProgress; }
            set { isInProgress = value; NotifyPropertyChanged(); }
        }

        private Popular popularsSelectedItem;

        public Popular PopularsSelectedItem
        {
            get { return popularsSelectedItem; }
            set
            {
                popularsSelectedItem = value;
                NotifyPropertyChanged();
                if (value != null)
                {
                    App.NavigationService.Navigate(typeof(EntryDetailsPage), PopularsSelectedItem);
                }
            }
        }

        private List<Popular> popularsList;

        public List<Popular> PopularsList
        {
            get { return popularsList; }
            set { popularsList = value; NotifyPropertyChanged(); }
        }

        private ICommand iRefreshPopularsList;

        public ICommand IRefreshPopularList
        {
            get { return iRefreshPopularsList; }
            set { iRefreshPopularsList = value; }
        }

        private RelayCommand refreshPopularListRelayCommand;
        public MainPageViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            UpdatePopularsList();
            refreshPopularListRelayCommand = new RelayCommand(UpdatePopularsList);
            IRefreshPopularList = refreshPopularListRelayCommand;
        }

        private void UpdatePopularsList()
        {
            Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Low, async () =>
            {
                IsInProgress = true;
                PopularsList = await GetPopularsAsync();
                IsInProgress = false;
            });
        }

        private async Task<List<Popular>> GetPopularsAsync()
        {
            PopularsClient client = new PopularsClient();
            return await client.GetPopulars();
        }
    }
}
