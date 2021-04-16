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
    public class PieOverviewViewModel : BaseViewModel
    {
        // Always initialize lists, even when empty
        private ObservableCollection<Pie> pies;

        public ObservableCollection<Pie> Pies
        {
            get { return pies; }
            set
            {
                pies = value;
                OnPropertyChanged(nameof(Pies));
            }
        }


        private IPieRepository repository;

        public ICommand AddPieCommand { get; }
        public ICommand LoadPiesCommand { get; }
        public Command<Pie> ItemTapped { get; }

        public PieOverviewViewModel()
        {
            repository = PieRepository.GetSingleton();

            RefreshPies();
            AddPieCommand = new Command(AddPie);
            LoadPiesCommand = new Command(RefreshPies);
            ItemTapped = new Command<Pie>(OnPieSelected);
        }

        private async void OnPieSelected(Pie pie)
        {
            await Shell.Current.GoToAsync(
                $"{nameof(PieDetailView)}?{nameof(PieDetailViewModel.PieId)}={pie.ID}");
        }

        private async void AddPie()
        {
            await Shell.Current.GoToAsync(nameof(PieDetailView));
        }

        private void RefreshPies()
        {
            IsBusy = true;

            try
            {
                List<Pie> pies = repository.GetAllPies();
                Pies = new ObservableCollection<Pie>(pies);
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