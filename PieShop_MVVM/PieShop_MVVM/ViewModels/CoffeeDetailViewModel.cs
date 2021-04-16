using PieShop_MVVM.Models;
using PieShop_MVVM.Services;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace PieShop_MVVM.ViewModels
{
    [QueryProperty(nameof(CoffeeId), nameof(CoffeeId))]
    public class CoffeeDetailViewModel : BaseViewModel
    {
        private Coffee selectedCoffee;

        public Coffee SelectedCoffee
        {
            get
            {
                return selectedCoffee;
            }
            set
            {
                selectedCoffee = value;
                OnPropertyChanged(nameof(SelectedCoffee));
            }
        }

        private ICoffeeRepository repository;

        public ICommand SaveCommand => new Command(OnSave);

        private int coffeeId;

        public int CoffeeId
        {
            get
            {
                return coffeeId;
            }
            set
            {
                coffeeId = value;
                LoadCoffee(value);
            }
        }

        public CoffeeDetailViewModel()
        {
            SelectedCoffee = new Coffee();
            repository = new CoffeeRepository();
        }

        private async void LoadCoffee(int value)
        {
            try
            {
                var coffee = await repository.GetCoffeeAsync(value);
                SelectedCoffee = coffee;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load item");
            }
        }

        private async void OnSave()
        {
            if (SelectedCoffee.ImageUrl == null)
            {
                SelectedCoffee.ImageUrl = "lavazza.jpg";
            }
            await repository.AddCoffeeAsync(SelectedCoffee);

            await Shell.Current.GoToAsync("..");
        }
    }
}