using MarineraApp.Pages.Dashboard;
using MarineraApp.Pages.Login;

namespace MarineraApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LogIn), typeof(LogIn));
            Routing.RegisterRoute(nameof(Home), typeof(Home));
        }
    }
}
