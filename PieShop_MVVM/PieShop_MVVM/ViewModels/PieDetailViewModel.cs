using PieShop_MVVM.Models;
using PieShop_MVVM.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PieShop_MVVM.ViewModels
{
    public class PieDetailViewModel: BaseViewModel
    {
        public Pie SelectedPie { get; set; }

        private IPieRepository repository;

        public ICommand SaveCommand => new Command(OnSave);

        public PieDetailViewModel()
        {
            SelectedPie = new Pie();
            repository = PieRepository.GetSingleton();
        }

        private void OnSave()
        {
            if (SelectedPie.ImageUrl == null)
            {
                SelectedPie.ImageUrl = "strawberrypiesmall.jpg";
            }
            repository.AddPie(SelectedPie);
        }
    }
}
