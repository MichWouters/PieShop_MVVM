using PieShop_MVVM.Models;
using PieShop_MVVM.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PieShop_MVVM.ViewModels
{
    public class PieOverviewViewModel
    {
        public ObservableCollection<Pie> Pies = new ObservableCollection<Pie>();

        private IPieRepository repository;

        public PieOverviewViewModel()
        {
            // Always initialize lists, even when empty
            repository = new PieRepository();

            List<Pie> pies = repository.GetAllPies();
            Pies = new ObservableCollection<Pie>(pies);
        }
    }
}
