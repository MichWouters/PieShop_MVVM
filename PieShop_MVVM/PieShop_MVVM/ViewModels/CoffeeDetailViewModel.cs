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
        private GenericRepo<Coffee> coffeeGenericRepo;

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
            coffeeGenericRepo = new GenericRepo<Coffee>();
        }

        private async void LoadCoffee(int value)
        {
            try
            {
                var coffee = await coffeeGenericRepo.FindItemAsync(value);
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
            await coffeeGenericRepo.AddItem(SelectedCoffee);

            await Shell.Current.GoToAsync("..");
        }
    }
}