using MVP.Commands;
using MVP.Models;
using MVP.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVP.VewModels
{
    public class AppViewModel : BaseViewModel
    {
        public FakeRepo BeerRepository { get; set; }
        public ObservableCollection<Beer> Beers { get; set; }
        public RelayCommand IncreaseCommand { get; set; }
        public RelayCommand DecreaseCommand { get; set; }
        public RelayCommand EditCommand { get; set; }


        private Beer beer;

        public Beer Beer
        {
            get { return beer; }
            set { beer = value; OnPropertyChanged(); }
        }
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }
        void EditMethod(object sender)
        {
            var selectionItem = sender as Beer;
            Beer = selectionItem;
        }
        public AppViewModel()
        {
            BeerRepository = new FakeRepo();
            EditCommand = new RelayCommand(EditMethod);
            IncreaseCommand = new RelayCommand(x =>
            {
                Count++;
            });
            DecreaseCommand = new RelayCommand(x =>
            {
                if (Count > 0)
                    --Count;
            });
            Beers = new ObservableCollection<Beer>(BeerRepository.GetAll());
            Beer = new Beer
            {
                ImagePath = @"../Images/beer4.jpg",
                Name = "Philsnerurq",
                Price = "7.50",
                Volume = "1.5"
            };
        }


    }
}
