using System;
using System.Collections.Generic;
using System.Linq;
using Application.Model;
using Microsoft.Practices.ServiceLocation;
using Windows.UI.Xaml;
using Application.Domain;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage
    {
        Int32 _NumQuestionsAnswered;
        Int32    _CurrentQuestionIndex;
        private readonly Int32 _QuestionThreshold;

        Int32 _NumCorrect;
        Int32 _NumIncorrect;
        Int32 _CurrentCorrectStreak;
        Int32 _BestCorrectStreak;

        Boolean _PreviousAnswerWasCorrect;

        private readonly IQuestionService _QuestionService;

        readonly Random _Random = new Random();
        List<Question> _Questions;
        private readonly IGameService _GameService;

        public QuestionPage()
        {
            InitializeComponent();

            _QuestionService = ServiceLocator.Current.GetInstance<IQuestionService>();
            _GameService = ServiceLocator.Current.GetInstance<IGameService>();

            _NumQuestionsAnswered = 0;
            _QuestionThreshold = 5;

            _CurrentQuestionIndex = 0;
            _NumCorrect = 0;
            _NumIncorrect = 0;
            _CurrentCorrectStreak = 0;
            _BestCorrectStreak = 0;
            _PreviousAnswerWasCorrect = false;
        }

        public int QuestionThreshold { get; set; }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO Get numQuestionsAnswered on resume game and questionthreshold for every game in this method call
            // Liz: Daniel, this call will actually return you questions now. :-)  With the right and wrong answers.
            var questions = _QuestionService.GetQuestions();
            
            // Possibly change other pages to get questions in order to pass questions parameter to questions page

            //questions = (IEnumerable<QuestionDto>)e.Parameter;

            _Questions = new List<Question>();


            for (int i = 0; i < 5; i++)
            {
                var correct = new Answer
                    {
                        IsCorrect = true,
                        Name = "This is the correct answer"
                    };

                var q = new Question
                    {
                        QuestionName = "This is question " + (i + 1),
                        CorrectAnswer = correct
                    };


                var wrongAnswers = new List<Answer>();

                for (var j = 0; j < 3; j++)
                {
                    var wrong = new Answer
                        {
                            Name = "This is wrong answer " + (j + 1), 
                            IsCorrect = false
                        };

                    wrongAnswers.Add(wrong);
                }
                q.WrongAnswers = wrongAnswers;
                _Questions.Add(q);

                
            }
            AButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            BButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            CButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            DButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            DisplayQuestion(_Questions.ElementAt(_CurrentQuestionIndex));
        }

        private void UpdateQuestion()
        {
            //currentQuestion = questions[currentQuestionIndex];
       
            DisplayQuestion(_Questions.ElementAt(++_CurrentQuestionIndex));
        }

        private void DisplayQuestion(Question question)
        {
            QuestionText.Text = question.QuestionName;
            _CurrentQuestionIndex = _Random.Next(0, 4);

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

        private void QuestionAnswered(Int32 buttonIndex)
        {
           // var questions = _QuestionService.GetQuestions();

            // hey daniel! i don't know how you see what was answered and 
            // with what but i mapped how to pass it down so i can store a game in progress for you.
            var questionAnswered = new AnsweredQuestion
                {
                    QuestionId = 1, SelectedAnswerId = 1
                };

            _QuestionService.StoreAnsweredQuestion(questionAnswered);

            _NumQuestionsAnswered++;
            IsAnswerCorrect(buttonIndex);
            UpdateCorrectQuestionStreak();
            DrawRightWrong();

            if (IsGameOver())
            {
                ResetColors();
                ShowResultsPopup();
                DisableButtons();
                _GameService.DeleteGameInProgress();
            }
            else
            {
                ResetColors();
                UpdateQuestion();
            }
        }

        private void IsAnswerCorrect(Int32 buttonIndex)
        {
            //var questions = _QuestionService.GetQuestions();

            if (buttonIndex == _CurrentQuestionIndex)
            {
                _Questions.ElementAt(_CurrentQuestionIndex).TimesCorrect++;
                _PreviousAnswerWasCorrect = true;
                _NumCorrect++;
            }
            else
            {
                //questions.ElementAt(currentQuestionIndex).TimesIncorrect++;
                _PreviousAnswerWasCorrect = false;
                _NumIncorrect++;
            }
            _Questions.ElementAt(_CurrentQuestionIndex).TimesViewed++;
        }

        private void UpdateCorrectQuestionStreak()
        {
            //var questions = _QuestionService.GetQuestions();

            if (_PreviousAnswerWasCorrect)
            {
                _CurrentCorrectStreak++;
                if (_CurrentCorrectStreak > _BestCorrectStreak)
                    _BestCorrectStreak = _CurrentCorrectStreak;
            }
            else
                _CurrentCorrectStreak = 0;
        }

        private void DrawRightWrong()
        {
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
            }
            
        }

        async private void WaitForUser()
        {
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
        }

        private void ResetColors()
        {
            AButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            BButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            CButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            DButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private bool IsGameOver()
        {
            return _NumQuestionsAnswered == _QuestionThreshold;
        }

        private void ShowResultsPopup()
        {
            AnswerTextBlock.Text =
                String.Format("You got {0} questions right and {1} questions wrong!\n Your best streak was {2}",
                              _NumCorrect, 
                              _NumIncorrect, 
                              _BestCorrectStreak);

            if (!ResultsPopup.IsOpen) { ResultsPopup.IsOpen = true; }
            Frame.Opacity = 0.3;
        }

        private void DisableButtons()
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
