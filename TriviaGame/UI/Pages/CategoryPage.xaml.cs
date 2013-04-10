using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using UI.Common;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Application.Domain;
using Application.Model;
using Microsoft.Practices.ServiceLocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace UI.Pages
{
    /// <summary>
    /// This page renders the categories to the user.
    /// </summary>
    public sealed partial class CategoryPage
    {

        private readonly ICategoryService _CategoryService;

        //private readonly ICategoryService _CategoryService;


        public CategoryPage()
        {
            _CategoryService = ServiceLocator.Current.GetInstance<ICategoryService>();

            InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var categories = _CategoryService.GetCategories();


            foreach (Category cat in categories)
            {
                Button b = new Button();
                b.Content = cat.Name;
                b.FontSize = 80;
                b.Width = 1000;
                b.Height = 150;
                b.Tag = cat.CategoryId;
                b.Background = new SolidColorBrush(Windows.UI.Colors.DarkSeaGreen);
                b.Margin = new Thickness(20);
                b.Click += new RoutedEventHandler(ButtonClick);
                CategoryStackPanel.Children.Add(b);
            }



            //var categories = _CategoryService.GetCategories();
            base.OnNavigatedTo(e);
        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            b.Name.Trim();

            Frame.Navigate(typeof(QuestionPage), b.Tag);
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
    }
}
