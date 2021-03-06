using PieShop_MVVM.Views;
using System;
using Xamarin.Forms;

namespace PieShop_MVVM
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(PieDetailView), typeof(PieDetailView));
            Routing.RegisterRoute(nameof(CoffeeDetailView), typeof(CoffeeDetailView));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}