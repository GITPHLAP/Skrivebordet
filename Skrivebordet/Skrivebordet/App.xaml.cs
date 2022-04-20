using System.Windows;

namespace Skrivebordet
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ImageHandler.Load();
            BackgroundScheduler.Start();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ImageHandler.Save();
        }
    }
}
