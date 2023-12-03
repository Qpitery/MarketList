using System;
using MarketList.VM;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using MarketList.View;



namespace MarketList.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        AddPageVM vm;
        public AddPage()
        {
            InitializeComponent();
            BindingContext = new AddPageVM();
        }
    }
}
