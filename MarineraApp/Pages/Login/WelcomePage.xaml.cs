using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarineraApp.Pages.Dashboard;
using Microsoft.Maui.Controls;

namespace MarineraApp.Pages.Login;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
        
    }

    async void OnClickButton(object sender, EventArgs e)
    {
        var btn = sender as Button;
        if (btn == null)
        {
            var label = sender as Label;
            if (label != null)
            {
                ContinueLikeGuest();
            }
        }
        else
        {
            switch (btn.Text)
            {
                case "Iniciar Sesión":
                    Login();
                    break;
                case "Registrarse":
                    SignIn();
                    break;
            }
        }

    }

    private async void ContinueLikeGuest()
    {
        await Navigation.PushAsync(new Home());
    }

    private async void Login()
    {
        await Shell.Current.GoToAsync("LogIn");
    }

    async void SignIn()
    {
        await Navigation.PushAsync(new SingIn());
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}