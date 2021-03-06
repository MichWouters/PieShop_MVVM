using PieShop_MVVM.Models;
using PieShop_MVVM.Services;
using PieShop_MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace PieShop_MVVM.ViewModels
{
    public class CoffeeOverviewViewModel : BaseViewModel
    {
        // Always initialize lists, even when empty
        private ObservableCollection<Coffee> coffees;

        public ObservableCollection<Coffee> Coffees
        {
            get { return coffees; }
            set
            {
                coffees = value;
                OnPropertyChanged(nameof(Coffees));
            }
        }

        private ICoffeeRepository repository;
        private GenericRepo<Coffee> coffeeGenericRepo;

        public ICommand AddCoffeeCommand { get; }
        public ICommand LoadCoffeesCommand { get; }
        public Command<Coffee> ItemTapped { get; }

        public CoffeeOverviewViewModel()
        {
            repository = new CoffeeRepository();
            coffeeGenericRepo = new GenericRepo<Coffee>();
            Coffees = new ObservableCollection<Coffee>();

            RefreshCoffees();
            AddCoffeeCommand = new Command(AddCoffee);
            LoadCoffeesCommand = new Command(RefreshCoffees);
            ItemTapped = new Command<Coffee>(OnCoffeeSelected);
        }

        private async void OnCoffeeSelected(Coffee Coffee)
        {
            await Shell.Current.GoToAsync($"{nameof(CoffeeDetailView)}?{nameof(CoffeeDetailViewModel.CoffeeId)}={Coffee.ID}");
        }

        private async void AddCoffee()
        {
            await Shell.Current.GoToAsync(nameof(CoffeeDetailView));
        }

        private async void RefreshCoffees()
        {
            IsBusy = true;

            try
            {
                List<Coffee> coffees = await repository.GetAllCoffeesAsync();
                Coffees = new ObservableCollection<Coffee>(coffees);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}