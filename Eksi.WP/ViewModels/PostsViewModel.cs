using Eksi.SDK;
using Eksi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Foundation;
using System.Windows.Input;

namespace Eksi.WP.ViewModels
{
    public class PostsViewModel : BaseViewModel
    {

        private bool isInProgress;

        public bool IsInProgress
        {
            get { return isInProgress; }
            set { isInProgress = value; NotifyPropertyChanged(); }
        }

        private Popular selectedPopularItem;

        public Popular SelectedPopularItem
        {
            get { return selectedPopularItem; }
            set { selectedPopularItem = value; NotifyPropertyChanged(); }
        }

        private List<Entry> postsList;
        public List<Entry> PostsList
        {
            get { return postsList; }
            set { postsList = value; NotifyPropertyChanged(); }
        }

        private ICommand iSend;

        public ICommand ISend
        {
            get { return iSend; }
            set { iSend = value; }
        }

        public RelayCommand BackRelayCommand;

        public PostsViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            IsInProgress = true;
            GetPosts();
            BackRelayCommand = new RelayCommand(Share);
            ISend = BackRelayCommand;
        }

        private void Share()
        {
            throw new NotImplementedException();
        }

        private async Task GetPosts()
        {
            Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                PostsClient client = new PostsClient();
                PostsList = await client.GetPostsAsync(SelectedPopularItem);
                IsInProgress = false;
            });
        }
    }
}
