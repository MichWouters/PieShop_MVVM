using PieShop_MVVM.Models;
using PieShop_MVVM.Services;
using PieShop_MVVM.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public PieOverviewViewModel()
        {
            repository = new PieRepository();

            RefreshPies();
            AddPieCommand = new Command(AddPie);
        }

        private async void AddPie()
        {
            await Shell.Current.GoToAsync(nameof(PieDetailView));
        }

        private void RefreshPies()
        {
            List<Pie> pies = repository.GetAllPies();
            Pies = new ObservableCollection<Pie>(pies);
        }
    }
}