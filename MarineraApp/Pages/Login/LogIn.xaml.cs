using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarineraApp.Services;
using MarineraApp.ViewModels.Login;

namespace MarineraApp.Pages.Login;

public partial class LogIn : ContentPage
{
      
    public LogIn(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        BindingContext = loginViewModel;
    }

}