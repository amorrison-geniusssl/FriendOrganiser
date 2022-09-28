using Autofac;
using FriendOrganiser.UI.Startup;
using System;
using System.Windows;

namespace FriendOrganiser.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unexpted error occured. Please infrom the admin."
                + Environment.NewLine + e.Exception.Message, "Unexpected error!");

            e.Handled = true;
        }
    }
}
