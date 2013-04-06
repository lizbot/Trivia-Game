using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Application.Domain;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage : Page
    {
        Int32 _NumQuestionsAnswered;
        Int32 _NumQuestionsRight;
        private readonly Int32 _QuestionThreshold;
        Int32    _CurrentQuestionIndex;
        private readonly IQuestionService _QuestionService;

        public QuestionPage()
        {
            InitializeComponent();

            _QuestionService = ServiceLocator.Current.GetInstance<IQuestionService>();

            //_QuestionService = questionService;

            //_NumQuestionsAnswered = 0;
            _QuestionThreshold = 5;
            //_CurrentQuestionIndex = 0;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO Get numQuestionsAnswered on resume game and questionthreshold for every game in this method call
            var questions = _QuestionService.GetQuestions();

            // Possibly change other pages to get questions in order to pass questions parameter to questions page
            
            ////questions = (IEnumerable<QuestionDto>)e.Parameter;
            //var samplequestion = new QuestionDto();

            //samplequestion.QuestionName = "asdf";

            //questions = (IEnumerable<QuestionDto>)samplequestion;
            //currentQuestion = questions.ElementAt(currentQuestionIndex);
            // QuestionText.Text = samplequestion.QuestionName;

            //String[] blah = new String[4];
            //blah[0] = "ASDFASDF";
            //blah[1] = "ertERt";
            //blah[2] = "yui";
            //blah[3] = "sdfd";
            //for(int i = 0; i < _QuestionThreshold; i++)
            //{

            //}
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
            var questions = _QuestionService.GetQuestions();

            AnswerAText.Text = "answerA"; //questionDtos.GetEnumerator().Current.CorrectAnswer.Name;
            //QuestionAnswered(questionDtos.GetEnumerator().Current.CorrectAnswer.AnswerId);
            QuestionAnswered();
        }

        private void AnswerBClick(object sender, RoutedEventArgs e)
        {
            var questions = _QuestionService.GetQuestions();

            AnswerBText.Text = "answerB"; // questionDtos.GetEnumerator().Current.WrongAnswers.GetEnumerator().Current.Name;
           // QuestionAnswered(questionDtos.GetEnumerator().Current.CorrectAnswer.AnswerId);
            QuestionAnswered();

            BButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
        }

        private void AnswerCClick(object sender, RoutedEventArgs e)
        {
            var questions = _QuestionService.GetQuestions();

            AnswerCText.Text = "answerC"; // questionDtos.GetEnumerator().Current.WrongAnswers.GetEnumerator().Current.Name;
            //QuestionAnswered(questionDtos.GetEnumerator().Current.CorrectAnswer.AnswerId);
            QuestionAnswered();
        }

        private void AnswerDClick(object sender, RoutedEventArgs e)
        {
            var questions = _QuestionService.GetQuestions();

            AnswerDText.Text = "answerD"; // questionDtos.GetEnumerator().Current.WrongAnswers.GetEnumerator().Current.Name;
            //QuestionAnswered(questionDtos.GetEnumerator().Current.CorrectAnswer.AnswerId);
            QuestionAnswered();
        }

        private void QuestionAnswered() //Int32 answerId)
        {
            _NumQuestionsAnswered++;

            Boolean answerIsCorrect = true; //_QuestionService.GetQuestions().GetEnumerator().Current.CorrectAnswer.AnswerId == answerId; 

            BButton.Background = answerIsCorrect 
                ? new SolidColorBrush(Windows.UI.Colors.Green) 
                : new SolidColorBrush(Windows.UI.Colors.Red);

            _NumQuestionsRight++;

            if (IsGameOver())
                ShowResultsPopup();
            else
                UpdateQuestion();
        }

        private bool IsGameOver()
        {
            return _NumQuestionsAnswered > _QuestionThreshold;
        }

        private void ShowResultsPopup()
        {
            if (!ResultsPopup.IsOpen) { ResultsPopup.IsOpen = true; }
            Frame.Opacity = 0.3;
        }

        private void ResultsPopupCloseClick(object sender, RoutedEventArgs e)
        {
            Frame.Opacity = 1;
            Frame.GoBack();
        }
    }
}
