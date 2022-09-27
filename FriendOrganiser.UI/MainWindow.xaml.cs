using FriendOrganiser.UI.ViewModel;
using System.Threading.Tasks;
using System.Windows;

namespace FriendOrganiser.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow(INavigationViewModel navigationViewModel)
        {
            NavigationViewModel = navigationViewModel;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await NavigationViewModel.LoadAsync();
        }

        public INavigationViewModel NavigationViewModel { get;}
    }
}
