using MarineraApp.Pages.Login;

namespace MarineraApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            
        }
        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            base.OnAppLinkRequestReceived(uri);

            if (uri.Scheme == "myapp")
            {
                // Aquí puedes manejar la redirección.
                Console.WriteLine("regrese a maui");
            }
        }
    }
  

}
