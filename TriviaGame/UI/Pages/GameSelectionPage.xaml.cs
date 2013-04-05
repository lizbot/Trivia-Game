using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using UI.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Application.Domain;
using Domain.Services;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace UI.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class GameSelectionPage : UI.Common.LayoutAwarePage
    {
        private IQuestionService _QuestionService;

        //QuestionService questionService = new QuestionService(



        //UIServiceHelper helper = new UIServiceHelper();
        

        public GameSelectionPage()
        {
            // do this for all of your dependencies. (this is an anti-pattern... see Mark Seemann)
            _QuestionService = ServiceLocator.Current.GetInstance<IQuestionService>();


            this.InitializeComponent();
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
            //var questions = _QuestionService.GetQuestions(null);

            Frame.Navigate(typeof(QuestionPage)/*, questions*/);
        }

        private void NewGameClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CategoryPage));
        }

        private void ResumeGameClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(QuestionPage));
        }
    }
}
