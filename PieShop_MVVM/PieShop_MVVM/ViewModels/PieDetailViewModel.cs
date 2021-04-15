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

        public ICommand SaveCommand;

        public PieDetailViewModel()
        {
            SelectedPie = new Pie();
            repository = new PieRepository();
            SaveCommand = new Command(OnSave);
        }

        private void OnSave()
        {
            // TODO
        }
    }
}
