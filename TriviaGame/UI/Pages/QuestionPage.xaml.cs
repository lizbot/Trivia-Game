using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Application.Domain;
<<<<<<< HEAD
=======
using Application.DTOs;
using Domain.Model;
using System.Threading;
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage : Page
    {
<<<<<<< HEAD
        Int32 _NumQuestionsAnswered;
        Int32 _NumQuestionsRight;
        private readonly Int32 _QuestionThreshold;
        Int32    _CurrentQuestionIndex;
=======

        int _NumQuestionsAnswered;
        int questionThreshold;
        int _CurrentQuestionIndex;
        int numCorrect;
        int numIncorrect;
        int currentCorrectStreak;
        int bestCorrectStreak;

        bool previousAnswerWasCorrect;

>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
        private readonly IQuestionService _QuestionService;
        Random random = new Random();
        List<QuestionDto> questions;

<<<<<<< HEAD
        public QuestionPage()
=======
        IEnumerable<QuestionDto> _Questions;


        public QuestionPage(/*IQuestionService questionService*/)
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
        {
            InitializeComponent();

            _QuestionService = ServiceLocator.Current.GetInstance<IQuestionService>();

            //_QuestionService = questionService;

<<<<<<< HEAD
            //_NumQuestionsAnswered = 0;
            _QuestionThreshold = 5;
            //_CurrentQuestionIndex = 0;
=======
            _NumQuestionsAnswered = 0;
            questionThreshold = 5;

            _CurrentQuestionIndex = 0;
            numCorrect = 0;
            numIncorrect = 0;
            currentCorrectStreak = 0;
            bestCorrectStreak = 0;
            previousAnswerWasCorrect = false;
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
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

<<<<<<< HEAD
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

=======


            //questions = (IEnumerable<QuestionDto>)e.Parameter;
            var samplequestion = new QuestionDto();

            questions = new List<QuestionDto>();


            for (int i = 0; i < 5; i++)
            {
                QuestionDto q = new QuestionDto();

                q.QuestionName = "This is question " + (i + 1);

                AnswerDto correct = new AnswerDto();
                correct.IsCorrect = true;
                correct.Name = "This is the correct answer";
                q.CorrectAnswer = correct;

                List<AnswerDto> WrongAnswers = new List<AnswerDto>();

                for (int j = 0; j < 3; j++)
                {
                    AnswerDto wrong = new AnswerDto();
                    wrong.Name = "This is wrong answer " + (j + 1);
                    wrong.IsCorrect = false;
                    WrongAnswers.Add(wrong);
                }
                q.WrongAnswers = WrongAnswers;
                questions.Add(q);

                
            }
            AButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            BButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            CButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            DButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            displayQuestion(questions.ElementAt(_CurrentQuestionIndex));
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
        }

        private void UpdateQuestion()
        {
<<<<<<< HEAD
            _CurrentQuestionIndex++;

            //currentQuestion = questions[currentQuestionIndex];
=======
            displayQuestion(questions.ElementAt(++_CurrentQuestionIndex));
        }

        private void displayQuestion(QuestionDto question)
        {
            QuestionText.Text = question.QuestionName;
            _CurrentQuestionIndex = random.Next(0, 4);

            if (_CurrentQuestionIndex == 0)
            {
                AnswerAText.Text = question.CorrectAnswer.Name;
                AnswerBText.Text = question.WrongAnswers.ElementAt(0).Name;
                AnswerCText.Text = question.WrongAnswers.ElementAt(1).Name;
                AnswerDText.Text = question.WrongAnswers.ElementAt(2).Name;

                _CurrentQuestionIndex = 0;
            }
            else if (_CurrentQuestionIndex == 1)
            {
                AnswerAText.Text = question.WrongAnswers.ElementAt(0).Name;
                AnswerBText.Text = question.CorrectAnswer.Name;
                AnswerCText.Text = question.WrongAnswers.ElementAt(1).Name;
                AnswerDText.Text = question.WrongAnswers.ElementAt(2).Name;
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac

                _CurrentQuestionIndex = 1;
            }
            else if (_CurrentQuestionIndex == 2)
            {
                AnswerAText.Text = question.WrongAnswers.ElementAt(0).Name;
                AnswerBText.Text = question.WrongAnswers.ElementAt(1).Name;
                AnswerCText.Text = question.CorrectAnswer.Name;
                AnswerDText.Text = question.WrongAnswers.ElementAt(2).Name;

                _CurrentQuestionIndex = 2;
            }
            else if (_CurrentQuestionIndex == 3)
            {
                AnswerAText.Text = question.WrongAnswers.ElementAt(0).Name;
                AnswerBText.Text = question.WrongAnswers.ElementAt(2).Name;
                AnswerCText.Text = question.WrongAnswers.ElementAt(1).Name;
                AnswerDText.Text = question.CorrectAnswer.Name;

                _CurrentQuestionIndex = 3;
            }
            else
                QuestionText.Text = "I didn't work!";
        }

        private void AnswerAClick(object sender, RoutedEventArgs e) { QuestionAnswered(0); }

        private void AnswerBClick(object sender, RoutedEventArgs e) { QuestionAnswered(1); }

        private void AnswerCClick(object sender, RoutedEventArgs e) { QuestionAnswered(2); }

        private void AnswerDClick(object sender, RoutedEventArgs e) { QuestionAnswered(3); }

        private void QuestionAnswered(int buttonIndex)
        {
<<<<<<< HEAD
            var questions = _QuestionService.GetQuestions();

            AnswerAText.Text = "answerA"; //questionDtos.GetEnumerator().Current.CorrectAnswer.Name;
            //QuestionAnswered(questionDtos.GetEnumerator().Current.CorrectAnswer.AnswerId);
            QuestionAnswered();
=======
            _NumQuestionsAnswered++;
            isAnswerCorrect(buttonIndex);
            updateCorrectQuestionStreak();
            drawRightWrong();

            if (isGameOver())
            {
                resetColors();
                ShowResultsPopup();
                disableButtons();
            }
            else
            {
                resetColors();
                UpdateQuestion();
            }
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
        }

        private void isAnswerCorrect(int buttonIndex)
        {
<<<<<<< HEAD
            var questions = _QuestionService.GetQuestions();

            AnswerBText.Text = "answerB"; // questionDtos.GetEnumerator().Current.WrongAnswers.GetEnumerator().Current.Name;
           // QuestionAnswered(questionDtos.GetEnumerator().Current.CorrectAnswer.AnswerId);
            QuestionAnswered();

            BButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
=======
            if (buttonIndex == _CurrentQuestionIndex)
            {
                questions.ElementAt(_CurrentQuestionIndex).TimesCorrect++;
                previousAnswerWasCorrect = true;
                numCorrect++;
            }
            else
            {
                //questions.ElementAt(currentQuestionIndex).TimesIncorrect++;
                previousAnswerWasCorrect = false;
                numIncorrect++;
            }
            questions.ElementAt(_CurrentQuestionIndex).TimesViewed++;
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
        }

        private void updateCorrectQuestionStreak()
        {
<<<<<<< HEAD
            var questions = _QuestionService.GetQuestions();

            AnswerCText.Text = "answerC"; // questionDtos.GetEnumerator().Current.WrongAnswers.GetEnumerator().Current.Name;
            //QuestionAnswered(questionDtos.GetEnumerator().Current.CorrectAnswer.AnswerId);
            QuestionAnswered();
=======
            if (previousAnswerWasCorrect)
            {
                currentCorrectStreak++;
                if (currentCorrectStreak > bestCorrectStreak)
                    bestCorrectStreak = currentCorrectStreak;
            }
            else
                currentCorrectStreak = 0;
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
        }

        private void drawRightWrong()
        {
<<<<<<< HEAD
            var questions = _QuestionService.GetQuestions();

            AnswerDText.Text = "answerD"; // questionDtos.GetEnumerator().Current.WrongAnswers.GetEnumerator().Current.Name;
            //QuestionAnswered(questionDtos.GetEnumerator().Current.CorrectAnswer.AnswerId);
            QuestionAnswered();
        }

        private void QuestionAnswered() //Int32 answerId)
=======
            switch (_CurrentQuestionIndex)
            {
                case 0: 
                    AButton.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    if (AButton.IsPointerOver)
                        AButton.Background = new SolidColorBrush(Windows.UI.Colors.Green);

                    BButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (BButton.IsPointerOver)
                        BButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);

                    CButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (CButton.IsPointerOver)
                        CButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);

                    DButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (DButton.IsPointerOver)
                        DButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;

                case 1:
                    AButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (AButton.IsPointerOver)
                        AButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);

                    BButton.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    if (BButton.IsPointerOver)
                        BButton.Background = new SolidColorBrush(Windows.UI.Colors.Green);

                    CButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (CButton.IsPointerOver)
                        CButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);

                    DButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (DButton.IsPointerOver)
                        DButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;

                case 2:
                    AButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (AButton.IsPointerOver)
                        AButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);

                    BButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (BButton.IsPointerOver)
                        BButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);

                    CButton.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    if (CButton.IsPointerOver)
                        CButton.Background = new SolidColorBrush(Windows.UI.Colors.Green);

                    DButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (DButton.IsPointerOver)
                        DButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;

                case 3:
                    AButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (AButton.IsPointerOver)
                        AButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);

                    BButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (BButton.IsPointerOver)
                        BButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);

                    CButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                    if (CButton.IsPointerOver)
                        CButton.Background = new SolidColorBrush(Windows.UI.Colors.Red);

                    DButton.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    if (DButton.IsPointerOver)
                        DButton.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    break;
                default:
                    break;   
            }
            
        }

        async private void waitForUser()
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
        {
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
        }

<<<<<<< HEAD
            Boolean answerIsCorrect = true; //_QuestionService.GetQuestions().GetEnumerator().Current.CorrectAnswer.AnswerId == answerId; 

            BButton.Background = answerIsCorrect 
                ? new SolidColorBrush(Windows.UI.Colors.Green) 
                : new SolidColorBrush(Windows.UI.Colors.Red);

            _NumQuestionsRight++;

            if (IsGameOver())
                ShowResultsPopup();
            else
                UpdateQuestion();
=======
        private void resetColors()
        {
            AButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            BButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            CButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            DButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
        }

        private bool IsGameOver()
        {
<<<<<<< HEAD
            return _NumQuestionsAnswered > _QuestionThreshold;
=======
            if (_NumQuestionsAnswered == questionThreshold)
                return true;
            else
                return false;
>>>>>>> 8dd02a7f7e2c711cfb22f7aa632725dc6252e5ac
        }

        private void ShowResultsPopup()
        {
            AnswerTextBlock.Text = "You got " + numCorrect + " questions right and " + numIncorrect + " questions wrong!\n  And your best streak was " + bestCorrectStreak + "!";

            if (!ResultsPopup.IsOpen) { ResultsPopup.IsOpen = true; }
            Frame.Opacity = 0.3;
        }

        private void disableButtons()
        {
            AButton.IsEnabled = false;
            BButton.IsEnabled = false;
            CButton.IsEnabled = false;
            DButton.IsEnabled = false;
        }

        private void ResultsPopupCloseClick(object sender, RoutedEventArgs e)
        {
            Frame.Opacity = 1;
            Frame.GoBack();
        }
    }
}
