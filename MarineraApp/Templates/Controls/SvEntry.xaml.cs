using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarineraApp.Templates.Controls;

public partial class SvEntry : ContentView, INotifyPropertyChanged
{
    public static readonly BindableProperty PlaceholderProperty =
        BindableProperty.Create(
            nameof(Placeholder),
            returnType: typeof(string), declaringType: typeof(SvEntry),
            defaultValue: default(string),
            defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty IsPasswordProperty =
        BindableProperty.Create(
            nameof(IsPassword),
            typeof(bool), typeof(SvEntry), default(bool), BindingMode.TwoWay);
    public static readonly BindableProperty EntryTextProperty =
        BindableProperty.Create(
            nameof(EntryText),
            returnType: typeof(string), declaringType: typeof(SvEntry),
            defaultValue: default(string),
            defaultBindingMode: BindingMode.TwoWay);
    private string _placeholder;
    private bool _isPassword;
    private string _entryText;

    public string EntryText
    {
        get=>(string)GetValue(EntryTextProperty);
        set{SetValue(EntryTextProperty,value);}
    }
    public string Placeholder
    {
      get=>(string)GetValue(PlaceholderProperty);
      set{SetValue(PlaceholderProperty,value);}
    }

    public bool IsPassword
    {
        get=>(bool)GetValue(IsPasswordProperty);
        set{SetValue(IsPasswordProperty,value);}
    }

    public SvEntry()
    {
        InitializeComponent();
    }


}