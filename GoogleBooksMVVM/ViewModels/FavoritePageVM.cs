using Models;
using MVVMHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleBooksMVVM.ViewModels
{
    public class FavoritePageVM : INotifyPropertyChanged
    {
        private ObservableCollection<Book> _favoriteBooks;

        public ObservableCollection<Book> FavoriteBooks
        {
            get { return _favoriteBooks; }
            set { _favoriteBooks = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FavoriteBooks)));
            }
        }

        public DelegateCommand AddFavoriteCommand { get; set; }
        public DelegateCommand RemoveFavoriteCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public FavoritePageVM()
        {
            FavoriteBooks = new ObservableCollection<Book>(FavoriteBooksManager.FavoriteBooks);
            AddFavoriteCommand = new DelegateCommand(param => FavoriteBooksManager.AddFavoriteBook(param as Book));
            RemoveFavoriteCommand = new DelegateCommand(param => FavoriteBooksManager.RemoveFavoriteBook(param as Book));
        }

    }
}
