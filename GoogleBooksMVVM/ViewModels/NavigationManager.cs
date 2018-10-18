using GoogleBooksMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GoogleBooksMVVM.ViewModels
{
    public enum PageTypes { Search, Favorite, Checker };

    public class NavigationManager
    {
        public static Frame RootFrame = null;

        private static CheckerPage _checkerPage;
        //private static FavoritePage _favoritePage;
        private static SearchPage _searchPage;

        public static void NavigateTo(PageTypes pageType, object viewmodel = null)
        {
            Page newPage = null;

            switch (pageType)
            {
                case PageTypes.Search:
                    newPage = _searchPage = _searchPage ?? new SearchPage();
                    break;
                case PageTypes.Favorite:
                    newPage = new FavoritePage();
                    break;
                case PageTypes.Checker:
                    newPage = _checkerPage = _checkerPage ?? new CheckerPage();
                    break;
                default:
                    break;
            }
            if (newPage == null) return;

            if (viewmodel != null)
                newPage.DataContext = viewmodel;

            RootFrame.Navigate(newPage);
        }
    }
}
