using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using UI.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Application.Domain;

namespace UI.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class GameSelectionPage
    {

        private readonly IGameService _GameService;

        public GameSelectionPage()
        {
            _GameService = ServiceLocator.Current.GetInstance<IGameService>();

            InitializeComponent();
        }

        protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {

            //I don't know how this works for the xaml but i was just trying to see if it would get information from the repository and bring it back.
            var gameIsInProgress = _GameService.IsGameInProgress();

            ResumeButton.Visibility = gameIsInProgress ? Visibility.Visible : Visibility.Collapsed;
            base.OnNavigatedTo(e);
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
        
        private void QuickplayClick(object sender, RoutedEventArgs e)
        {
            //var questions = _QuestionService.GetQuestions();

            Frame.Navigate(typeof(QuestionPage), null);
        }

        private void NewGameClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CategoryPage));
        }

        private void ResumeGameClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(QuestionPage), null);
        }
    }
}
