using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using UI.Common;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Application.Domain;
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

            var selector = 0;

            foreach (var cat in categories)
            {
                var b = new Button
                    {
                        Content = cat.Name,
                        FontSize = 75,
                        Width = 550,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        Height = 130,
                        Tag = cat.CategoryId,
                        Background = new SolidColorBrush(Windows.UI.Colors.DarkSeaGreen),
                        Margin = new Thickness(20)
                    };

                b.Click += ButtonClick;
                if(selector % 2 == 0)
                    CategoryStackPanel1.Children.Add(b);
                else
                    CategoryStackPanel2.Children.Add(b);
                selector++;
            }

            base.OnNavigatedTo(e);
        }


        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
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
