using PieShop_MVVM.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PieShop_MVVM.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}