using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketList;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MarketList.View;
using MarketList.VM;



namespace MarketList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AddPage", typeof(AddPage));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("CategoryList", typeof(CategoryList));
        }
    }
}