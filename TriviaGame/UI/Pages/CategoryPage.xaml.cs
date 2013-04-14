using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using UI.Common;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Application.Domain;
using Application.Model;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI;

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

            int selector = 0;

            Category cat;
            for (int i = 0; i < 5; i++)
            {
                cat = categories.ElementAt(i);
                Button b = new Button();
                b.Content = cat.Name;
                b.FontSize = 75;
                b.Width = 550;
                b.HorizontalAlignment = HorizontalAlignment.Stretch;
                b.Height = 130;
                b.Tag = cat.CategoryId;
                switch (i)
                {
                    case (0):
                        Color purpleishColor = new Color();

                        purpleishColor.R = Convert.ToByte("147");
                        purpleishColor.G = Convert.ToByte("125");
                        purpleishColor.B = Convert.ToByte("211");
                        purpleishColor.A = Convert.ToByte("255");

                        b.Background = new SolidColorBrush(purpleishColor);
                        break;
                    case (1):
                        Color bluenishColor = new Color();

                        bluenishColor.R = Convert.ToByte("124");
                        bluenishColor.G = Convert.ToByte("211");
                        bluenishColor.B = Convert.ToByte("190");
                        bluenishColor.A = Convert.ToByte("255");

                        b.Background = new SolidColorBrush(bluenishColor);
                        break;
                    case (2):
                        Color greenishColor = new Color();

                        greenishColor.R = Convert.ToByte("188");
                        greenishColor.G = Convert.ToByte("211");
                        greenishColor.B = Convert.ToByte("123");
                        greenishColor.A = Convert.ToByte("255");

                        b.Background = new SolidColorBrush(greenishColor);
                        break;
                    case (3):
                        Color renkishColor = new Color();

                        renkishColor.R = Convert.ToByte("211");
                        renkishColor.G = Convert.ToByte("123");
                        renkishColor.B = Convert.ToByte("145");
                        renkishColor.A = Convert.ToByte("255");

                        b.Background = new SolidColorBrush(renkishColor);
                        break;
                    case (4):
                        Color ishColor = new Color();

                        ishColor.R = Convert.ToByte("211");
                        ishColor.G = Convert.ToByte("190");
                        ishColor.B = Convert.ToByte("123");
                        ishColor.A = Convert.ToByte("255");

                        b.Background = new SolidColorBrush(ishColor);
                        break;
                }

                b.Margin = new Thickness(20);
                b.Click += new RoutedEventHandler(ButtonClick);
                if (selector % 2 == 0)
                    CategoryStackPanel1.Children.Add(b);
                else
                    CategoryStackPanel2.Children.Add(b);
                selector++;
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
