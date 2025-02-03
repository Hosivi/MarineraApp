namespace MarineraApp.Templates.Controls;

public class PrimaryBtn:Button
{
    public PrimaryBtn()
    {
        CornerRadius = 8;
        BackgroundColor = (Color)Application.Current?.Resources["PrimaryDark"]!;
        WidthRequest= 331;
        HeightRequest = 56;
        FontSize = 14;
        Margin=new Thickness(15); 

    }
}

public class SecondaryBtn:PrimaryBtn
{
    public SecondaryBtn()
    {
        CornerRadius = 8;
        BackgroundColor = Colors.White;
        BorderColor= (Color)Application.Current?.Resources["PrimaryDark"]!;
        BorderWidth = 1;
        TextColor = Colors.Black;
    }
}

public class BorderlessEntry:Entry
{

}