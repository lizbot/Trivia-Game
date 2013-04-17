using Application.Domain;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using UI.Common;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace UI.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class StatisticsPage
    {
        private readonly IStatisticsService _StatisticsService;

        public StatisticsPage()
        {
            _StatisticsService = ServiceLocator.Current.GetInstance<IStatisticsService>();

            InitializeComponent();
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var numCorrect = _StatisticsService.GetOverallAnsweredCorrectly();
            var numTotal = _StatisticsService.GetOverallQuestionsAnswered();
            var longestStreak = _StatisticsService.GetLongestStreak();

            AnswersCorrectTextBlock.Text = "Total Answers Correct: " + numCorrect;
            AnswersIncorrectTextBlock.Text = "Total Answers Incorrect: " + (numTotal - numCorrect);
            LongestStreakTextBlock.Text = "Longest Correct Streak: " + longestStreak;

            if (numCorrect != 0)
                OverallStatisticsTextBlock.Text = "Overall Statistics: " + _StatisticsService.GetPercentageOfOverallStatistics() + "%";

            base.OnNavigatedTo(e);

            //CallStoryboard();
        }

        public void CallStoryboard()
        {
            StatisticsFadeInStoryboard.Begin();
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
