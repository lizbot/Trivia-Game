using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage : Page
    {
        int numQuestionsAnswered;
        int questionThreshold;

        public QuestionPage()
        {
            this.InitializeComponent();
            numQuestionsAnswered = 0;
            questionThreshold = 5;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO Get numQuestionsAnswered on resume game and questionthreshold for every game in this method call
        }

        private void AnswerAClick(object sender, RoutedEventArgs e)
        {
            QuestionAnswered();
        }

        private void AnswerBClick(object sender, RoutedEventArgs e)
        {
            QuestionAnswered();
        }

        private void AnswerCClick(object sender, RoutedEventArgs e)
        {
            QuestionAnswered();
        }

        private void AnswerDClick(object sender, RoutedEventArgs e)
        {
            QuestionAnswered();
        }

        private void QuestionAnswered()
        {
            numQuestionsAnswered++;

            if (isGameOver())
                Frame.Navigate(typeof(ResultsPage));
        }

        private bool isGameOver()
        {
            if (numQuestionsAnswered == questionThreshold)
                return true;
            else
                return false;
        }
    }
}
