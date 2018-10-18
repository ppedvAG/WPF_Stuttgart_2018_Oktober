using Models;
using MVVMHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GoogleBooksMVVM.ViewModels
{
    public class SearchPageVM : INotifyPropertyChanged
    {
        public string Suchbegriff { get; set; }

        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand AddFavoriteBookCommand { get; set; }

        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Books)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SearchPageVM()
        {
            SearchCommand = new DelegateCommand(SucheBuch, p => Suchbegriff != string.Empty);
            AddFavoriteBookCommand = new DelegateCommand(FügeBuchHinzu);
        }

        private void FügeBuchHinzu(object parameter)
        {
            if(parameter is Book book)
            {
                var result = FavoriteBooksManager.AddFavoriteBook(book);
                if(result.success)
                {
                    MessageBox.Show($"Buch {book.volumeInfo.title} wurde hinzugefügt!");
                }
                else
                    MessageBox.Show(result.errorString);
            }
        }

        private async void SucheBuch(object parameter)
        {
            IList<Book> books = await BookSearchService.SucheBücherAsync(Suchbegriff);



            Books = new ObservableCollection<Book>(books);
        }
    }
}
