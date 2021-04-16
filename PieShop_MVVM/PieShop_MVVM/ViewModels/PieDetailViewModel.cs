using PieShop_MVVM.Models;
using PieShop_MVVM.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PieShop_MVVM.ViewModels
{
    [QueryProperty(nameof(PieId), nameof(PieId))]
    public class PieDetailViewModel : BaseViewModel
    {
        private Pie selectedPie;

        public Pie SelectedPie
        {
            get
            {
                return selectedPie;
            }
            set
            {
                selectedPie = value;
                OnPropertyChanged(nameof(SelectedPie));
            }
        }


        private IPieRepository repository;
        private GenericRepo<Pie> pieGenericRepo;

        public ICommand SaveCommand => new Command(OnSave);

        private int pieId;

        public int PieId
        {
            get
            {
                return pieId;
            }
            set
            {
                pieId = value;
                LoadPie(value);
            }
        }

        public PieDetailViewModel()
        {
            SelectedPie = new Pie();
            repository = new PieRepository();
            pieGenericRepo = new GenericRepo<Pie>();
        }

        private async void LoadPie(int value)
        {
            try
            {
                var pie = await pieGenericRepo.FindItemAsync(value);
                SelectedPie = pie;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load item");
            }
        }

        private async void OnSave()
        {
            if (SelectedPie.ImageUrl == null)
            {
                SelectedPie.ImageUrl = "strawberrypiesmall.jpg";
            }
            await pieGenericRepo.AddItem(SelectedPie);

            await Shell.Current.GoToAsync("..");
        }
    }
}
