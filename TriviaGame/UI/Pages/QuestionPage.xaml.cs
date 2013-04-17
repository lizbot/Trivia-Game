using System;
using System.Collections.Generic;
using System.Linq;
using Application.Model;
using Microsoft.Practices.ServiceLocation;
using Windows.UI.Xaml;
using Application.Domain;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UI.Common;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using System.IO;
using Windows.Storage;



namespace UI.Pages 
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage
    {
        #region class variables
        Int32 _NumQuestionsAnswered;
        Int32 _CurrentQuestionIndex;
        Int32 _QuestionThreshold;

        Int32 _CorrectAnswerIndex;
        Int32 _QuestionAnsweredId;

        Int32 _NumCorrect;
        Int32 _NumIncorrect;
        Int32 _CurrentCorrectStreak;
        Int32 _BestCorrectStreak;

        Boolean _PreviousAnswerWasCorrect;

        private readonly IQuestionService _QuestionService;

        readonly Random _Random = new Random();
        private readonly IGameService _GameService;

        #endregion

        List<Question> _Questions = new List<Question>();
        private readonly IStatisticsService _StatisticsService;

        public Int32 QuestionThreshold { get; set; }
        Stopwatch timer = new Stopwatch();

        DispatcherTimer dispatcherTimer;
        int timesTicked = 0;
        int timesToTick = 1;
        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }

        public QuestionPage()
        {
            InitializeComponent();

            _QuestionService = ServiceLocator.Current.GetInstance<IQuestionService>();
            _GameService = ServiceLocator.Current.GetInstance<IGameService>();
            _StatisticsService = ServiceLocator.Current.GetInstance<IStatisticsService>();

            _CurrentQuestionIndex = 0;
            _NumQuestionsAnswered = 0;
            _NumCorrect = 0;
            _NumIncorrect = 0;
            _PreviousAnswerWasCorrect = false;
            DispatcherTimerSetup();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ResetColors();
            var gameExists = _GameService.IsGameInProgress();
            var gameInProgress = new GameSaved();
            if (gameExists)
            {
                gameInProgress = _GameService.GetGameInProgress();
            
                foreach (var question in gameInProgress.Questions)
                {
                    _Questions.Add(question);
                }
            }

            else
            {
                if (e.Parameter == null)
                    _Questions = _QuestionService.GetQuestions() as List<Question>;
                else
                    _Questions = _QuestionService.GetQuestions((int?) e.Parameter) as List<Question>;
            }

            if (gameExists)
            {
                var list = gameInProgress.Questions as List<Question>;
                _QuestionThreshold = gameInProgress.Questions.Count();

                _CurrentQuestionIndex = list.FindIndex(q => q.QuestionId == gameInProgress.QuestionToResumeId);
                _NumQuestionsAnswered = _CurrentQuestionIndex;

                DisplayQuestion(_Questions.ElementAt(_CurrentQuestionIndex));
            }
                
            else
            {
                _QuestionThreshold = _Questions.Count();

                DisplayQuestion(_Questions.ElementAt(_CurrentQuestionIndex));
            }
            base.OnNavigatedTo(e);
            ResetColors();
            timer.Start();
            
        }

        private void UpdateQuestion()
        {
            _CurrentQuestionIndex++;

            DisplayQuestion(_Questions.ElementAt(_CurrentQuestionIndex));
        }

        private void DisplayQuestion(Question question)
        {
            QuestionText.Text = question.QuestionName;
            QuestionNumTextBlock.Text = "Question " + (_CurrentQuestionIndex+1) + " of " + _Questions.Count();

            var randomIndex = _Random.Next(0, 4);
            _QuestionAnsweredId = question.QuestionId;

            switch (randomIndex)
            {
                case 0:
                    AnswerAText.Text = question.CorrectAnswer.Name;
                    AnswerBText.Text = question.WrongAnswers.ElementAt(0).Name;
                    AnswerCText.Text = question.WrongAnswers.ElementAt(1).Name;
                    AnswerDText.Text = question.WrongAnswers.ElementAt(2).Name;

                    AButton.CommandParameter = question.CorrectAnswer.AnswerId;
                    BButton.CommandParameter = question.WrongAnswers.ElementAt(0).AnswerId;
                    CButton.CommandParameter = question.WrongAnswers.ElementAt(1).AnswerId;
                    DButton.CommandParameter = question.WrongAnswers.ElementAt(2).AnswerId;

                    _CorrectAnswerIndex = 0;
                    break;
                case 1:
                    AnswerAText.Text = question.WrongAnswers.ElementAt(0).Name;
                    AnswerBText.Text = question.CorrectAnswer.Name;
                    AnswerCText.Text = question.WrongAnswers.ElementAt(1).Name;
                    AnswerDText.Text = question.WrongAnswers.ElementAt(2).Name;

                    AButton.CommandParameter = question.WrongAnswers.ElementAt(0).AnswerId;
                    BButton.CommandParameter = question.CorrectAnswer.AnswerId;
                    CButton.CommandParameter = question.WrongAnswers.ElementAt(1).AnswerId;
                    DButton.CommandParameter = question.WrongAnswers.ElementAt(2).AnswerId;

                    _CorrectAnswerIndex = 1;
                    break;
                case 2:
                    AnswerAText.Text = question.WrongAnswers.ElementAt(0).Name;
                    AnswerBText.Text = question.WrongAnswers.ElementAt(1).Name;
                    AnswerCText.Text = question.CorrectAnswer.Name;
                    AnswerDText.Text = question.WrongAnswers.ElementAt(2).Name;


                    AButton.CommandParameter = question.WrongAnswers.ElementAt(0).AnswerId;
                    BButton.CommandParameter = question.WrongAnswers.ElementAt(1).AnswerId;
                    CButton.CommandParameter = question.CorrectAnswer.AnswerId;
                    DButton.CommandParameter = question.WrongAnswers.ElementAt(2).AnswerId;

                    _CorrectAnswerIndex = 2;
                    break;
                case 3:
                    AnswerAText.Text = question.WrongAnswers.ElementAt(0).Name;
                    AnswerBText.Text = question.WrongAnswers.ElementAt(1).Name;
                    AnswerCText.Text = question.WrongAnswers.ElementAt(2).Name;
                    AnswerDText.Text = question.CorrectAnswer.Name;

                    AButton.CommandParameter = question.WrongAnswers.ElementAt(0).AnswerId;
                    BButton.CommandParameter = question.WrongAnswers.ElementAt(1).AnswerId;
                    CButton.CommandParameter = question.WrongAnswers.ElementAt(2).AnswerId;
                    DButton.CommandParameter = question.CorrectAnswer.AnswerId;

                    _CorrectAnswerIndex = 3;
                    break;
                default:
                    QuestionText.Text = "I didn't work!";
                    break;
            }

            QuestionFadeInStoryboard.Begin();
            AnswerFadeInStoryboard.Begin();
        }

        private void AnswerAClick(object sender, RoutedEventArgs e) { QuestionAnswered(0); }

        private void AnswerBClick(object sender, RoutedEventArgs e) { QuestionAnswered(1); }

        private void AnswerCClick(object sender, RoutedEventArgs e) { QuestionAnswered(2); }

        private void AnswerDClick(object sender, RoutedEventArgs e) { QuestionAnswered(3); }

        private void QuestionAnswered(Int32 buttonIndex)
        {
            DisableButtons();
            _NumQuestionsAnswered++;
            IsAnswerCorrect(buttonIndex);
            UpdateCorrectQuestionStreak();
            DrawRightWrong();
            dispatcherTimer.Start();
            

            _Questions.ElementAt(_CurrentQuestionIndex).IncreaseTimesViewedAndOrTimesCorrect(_QuestionService);
            if (IsGameOver())
            {
                dispatcherTimer.Stop();
                timer.Stop();
                ShowResultsPopup();
                DisableButtons();

                //Store Statistics Here

                //Does this happen before or after the results are being shown?
                _StatisticsService.AnalyzeEndOfGameData();
                _GameService.DeleteGameInProgressIfExists();
            }
            else
            {
                
            }
        }


        private async void playsound(string result)
        {

            string file_name; 
            MediaElement _mySound = new MediaElement();
            Windows.Storage.StorageFolder _Folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Infrastructure\Sound");

            if (result == "correct")
                file_name = "right.wav";
            else if (result == "incorrect")
                file_name = "wrong.wav";
            else
                file_name = "applause.wav";

            Windows.Storage.StorageFile _File = await _Folder.GetFileAsync(file_name);

            var stream = await _File.OpenReadAsync();
            _mySound.SetSource(stream, _File.ContentType);

            _mySound.Play();
        }

        private void IsAnswerCorrect(Int32 buttonIndex)
        {
            if (buttonIndex == _CorrectAnswerIndex)
            {
                playsound("correct");
                _Questions.ElementAt(_CurrentQuestionIndex).TimesCorrect++;
                _PreviousAnswerWasCorrect = true;
                
                if (buttonIndex == 0)
                    _QuestionService.StoreAnsweredQuestion(_QuestionAnsweredId, Convert.ToInt32(AButton.CommandParameter));
                if (buttonIndex == 1)
                    _QuestionService.StoreAnsweredQuestion(_QuestionAnsweredId, Convert.ToInt32(BButton.CommandParameter));
                if (buttonIndex == 2)
                    _QuestionService.StoreAnsweredQuestion(_QuestionAnsweredId, Convert.ToInt32(CButton.CommandParameter));
                if (buttonIndex == 3)
                    _QuestionService.StoreAnsweredQuestion(_QuestionAnsweredId, Convert.ToInt32(DButton.CommandParameter));

                _GameService.MarkCorrectOrIncorrect(_Questions.ElementAt(_CurrentQuestionIndex).QuestionId, true);

            }
            else
            {
                playsound("incorrect");
                _PreviousAnswerWasCorrect = false;
                
                if(buttonIndex == 0)
                    _QuestionService.StoreAnsweredQuestion(_QuestionAnsweredId, Convert.ToInt32(AButton.CommandParameter));
                if(buttonIndex == 1)
                    _QuestionService.StoreAnsweredQuestion(_QuestionAnsweredId, Convert.ToInt32(BButton.CommandParameter));
                if(buttonIndex == 2)
                    _QuestionService.StoreAnsweredQuestion(_QuestionAnsweredId, Convert.ToInt32(CButton.CommandParameter));
                if(buttonIndex == 3)
                    _QuestionService.StoreAnsweredQuestion(_QuestionAnsweredId, Convert.ToInt32(DButton.CommandParameter));

                _GameService.MarkCorrectOrIncorrect(_Questions.ElementAt(_CurrentQuestionIndex).QuestionId, false);
            }

            _Questions.ElementAt(_CurrentQuestionIndex).TimesViewed++;
        }

        

        private void UpdateCorrectQuestionStreak()
        {
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
            switch (_CorrectAnswerIndex)
            {
                case 0:
                    AnswerAText.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                    AnswerBText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    AnswerCText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    AnswerDText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;

                case 1:
                    AnswerAText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    AnswerBText.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                    AnswerCText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    AnswerDText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;

                case 2:
                    AnswerAText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    AnswerBText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    AnswerCText.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                    AnswerDText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    break;

                case 3:
                    AnswerAText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    AnswerBText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    AnswerCText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                    AnswerDText.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                    break;
            }
        }


        void dispatcherTimer_Tick(object sender, object e)
        {
            timesTicked++;

            if (timesTicked == timesToTick)
            {
                QuestionFadeOutStoryboard.Begin();
                AnswerFadeOutStoryboard.Begin();
            }
            if (timesTicked > timesToTick)
            {
                dispatcherTimer.Stop();
                timesTicked = 0;
                ResetTextColors();
                UpdateQuestion();
                EnableButtons();
            }
        }

        private void ResetTextColors()
        {
            AnswerAText.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
            AnswerBText.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
            AnswerCText.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
            AnswerDText.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
        }
        //async private void WaitForUser()
        //{
        //    await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
        //}

        private void ResetColors()
        {
            AButton.Background = new SolidColorBrush(ColorsUse.ColorToUse("ishColor"));
            BButton.Background = new SolidColorBrush(ColorsUse.ColorToUse("ishColor"));
            CButton.Background = new SolidColorBrush(ColorsUse.ColorToUse("ishColor"));
            DButton.Background = new SolidColorBrush(ColorsUse.ColorToUse("ishColor"));
        }

        private bool IsGameOver()
        {
            return _NumQuestionsAnswered == _QuestionThreshold;
        }

        private void ShowResultsPopup()
        {
            double elapsedTime = timer.ElapsedMilliseconds / 1000;
            string questionsRightNum = "questions";
            string questionsWrongNum = "questions";
            string correctStreakNum = "questions";

            if (_NumCorrect == 1)
                questionsRightNum = "question";
            else if (_NumIncorrect == 1)
                questionsWrongNum = "question";

            if (_BestCorrectStreak == 1)
                correctStreakNum = "question";

            string Sad = "\t\t:(\tBetter read some 'pedia and try again...";
            string Happy = "\t\t:D\tYou must be related to Ken Jennings!";

            bool happy = true;
            bool sad = true;

            if (_NumCorrect == 0)
                happy = false;
            else if (_NumIncorrect == 0)
                sad = false;
            
            if(!happy)
                AnswerTextBlock.Text =
                    String.Format("\n  You got {0} {1} right and {2} {3} wrong!\n\n\n  Your best streak was {4} {5} answered correctly in a row.  \n\n\n{6}",

                                _NumCorrect,
                                questionsRightNum,
                                _NumIncorrect,
                                questionsWrongNum,
                                _BestCorrectStreak,
                                correctStreakNum,
                                Sad);
            else if(!sad)
                AnswerTextBlock.Text =
                    String.Format("\n  You got {0} {1} right and {2} {3} wrong!\n\n\n  Your best streak was {4} {5} answered correctly in a row.  \n\n\n{6}",
                                _NumCorrect,
                                questionsRightNum,
                                _NumIncorrect,
                                questionsWrongNum,
                                _BestCorrectStreak,
                                correctStreakNum,
                                Happy);
            else
                AnswerTextBlock.Text =
                    String.Format("\n  You got {0} {1} right and {2} {3} wrong!\n\n\n  Your best streak was {4} {5} answered correctly in a row.\t\n\n\n",

                                _NumCorrect,
                                questionsRightNum,
                                _NumIncorrect, 
                                questionsWrongNum,
                                _BestCorrectStreak,
                                correctStreakNum,
                                elapsedTime);

            playsound("complete");
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

        private void EnableButtons()
        {
            AButton.IsEnabled = true;
            BButton.IsEnabled = true;
            CButton.IsEnabled = true;
            DButton.IsEnabled = true;
        }

        private void ResultsPopupCloseClick(object sender, RoutedEventArgs e)
        {
            Frame.Opacity = 1;
            if (this.Frame != null)
            {
                while (this.Frame.CanGoBack) this.Frame.GoBack();
            }
            
        }
    }
}
