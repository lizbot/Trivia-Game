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
using Application.Domain;
using Application.DTOs;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage : Page
    {
        int _NumQuestionsAnswered;
        readonly int questionThreshold;
        QuestionDto _CurrentQuestion;
        int _CurrentQuestionIndex;
        private readonly IQuestionService _QuestionService;

        IEnumerable<QuestionDto> _Questions;

        public QuestionPage(/*IQuestionService questionService*/)
        {
            this.InitializeComponent();

            //_QuestionService = questionService;

            _NumQuestionsAnswered = 0;
            questionThreshold = 5;
            _CurrentQuestionIndex = 0;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO Get numQuestionsAnswered on resume game and questionthreshold for every game in this method call

            // Possibly change other pages to get questions in order to pass questions parameter to questions page


            //questions = (IEnumerable<QuestionDto>)e.Parameter;
            var samplequestion = new QuestionDto();

            samplequestion.QuestionName = "asdf";

            //questions = (IEnumerable<QuestionDto>)samplequestion;
            //currentQuestion = questions.ElementAt(currentQuestionIndex);
            QuestionText.Text = samplequestion.QuestionName;

            String[] blah = new String[4];
            blah[0] = "ASDFASDF";
            blah[1] = "ertERt";
            blah[2] = "yui";
            blah[3] = "sdfd";
            for(int i = 0; i < questionThreshold; i++)
            {
                
            }
            //currentQuestionIndex = -1;

        }

        private void UpdateQuestion()
        {
            _CurrentQuestionIndex++;
            //currentQuestion = questions[currentQuestionIndex];

            //QuestionText.Text = currentQuestion.QText;
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
            _NumQuestionsAnswered++;

            if (isGameOver())
                ShowResultsPopup();
            else
                UpdateQuestion();
        }

        private bool isGameOver()
        {
            if (_NumQuestionsAnswered > questionThreshold)
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
