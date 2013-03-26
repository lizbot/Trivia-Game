using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Infrastructure;
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
        Question[] questions;
        Question currentQuestion;
        int currentQuestionIndex;

        public QuestionPage()
        {
            this.InitializeComponent();
            numQuestionsAnswered = 0;
            questionThreshold = 5;
            currentQuestionIndex = 0;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO Get numQuestionsAnswered on resume game and questionthreshold for every game in this method call
            questions = new Question[questionThreshold];
            String[] blah = new String[4];
            blah[0] = "ASDFASDF";
            blah[1] = "ertERt";
            blah[2] = "yui";
            blah[3] = "sdfd";
            for(int i = 0; i < questionThreshold; i++)
            {
                questions[i] = new Question(i+1 + "QUESTION", blah, (i % 4));
            }
            currentQuestionIndex = -1;

        }

        private void UpdateQuestion()
        {
            currentQuestionIndex++;
            currentQuestion = questions[currentQuestionIndex];

            QuestionText.Text = currentQuestion.QText;
        }

        private void AnswerAClick(object sender, RoutedEventArgs e)
        {
            QuestionAnswered();
        }

        private void AnswerBClick(object sender, RoutedEventArgs e)
        {
            QuestionAnswered();
            BButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
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
                ShowResultsPopup();
            else
                UpdateQuestion();
        }

        private bool isGameOver()
        {
            if (numQuestionsAnswered == questionThreshold)
                return true;
            else
                return false;
        }

        private void ShowResultsPopup()
        {
            if (!ResultsPopup.IsOpen) { ResultsPopup.IsOpen = true; }
            this.Frame.Opacity = 0.3;
        }

        private void ResultsPopupCloseClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Opacity = 1;
            Frame.GoBack();
        }
    }
}
