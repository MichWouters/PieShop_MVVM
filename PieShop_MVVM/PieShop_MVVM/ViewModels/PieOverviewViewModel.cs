using PieShop_MVVM.Models;
using PieShop_MVVM.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PieShop_MVVM.ViewModels
{
    public class PieOverviewViewModel
    {
        // Always initialize lists, even when empty
        public ObservableCollection<Pie> Pies { get; set; } = new ObservableCollection<Pie>();

        private IPieRepository repository;

        public PieOverviewViewModel()
        {
            repository = new PieRepository();

            List<Pie> pies = repository.GetAllPies();
            Pies = new ObservableCollection<Pie>(pies);
        }
    }
}
