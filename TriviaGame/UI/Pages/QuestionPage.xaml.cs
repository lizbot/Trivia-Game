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
using Domain.Model;
using System.Threading;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuestionPage : Page
    {

        int _NumQuestionsAnswered;
        int questionThreshold;
        int _CurrentQuestionIndex;
        int _CorrectAnswerIndex;
        int numCorrect;
        int numIncorrect;
        int currentCorrectStreak;
        int bestCorrectStreak;

        bool previousAnswerWasCorrect;

        private readonly IQuestionService _QuestionService;
        Random random = new Random();
        List<QuestionDto> questions;

        IEnumerable<QuestionDto> _Questions;


        public QuestionPage(/*IQuestionService questionService*/)
        {
            this.InitializeComponent();

            //_QuestionService = questionService;

            _NumQuestionsAnswered = 0;
            questionThreshold = 5;

            _CurrentQuestionIndex = 0;
            numCorrect = 0;
            numIncorrect = 0;
            currentCorrectStreak = 0;
            bestCorrectStreak = 0;
            previousAnswerWasCorrect = false;
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

            //_Questions = questions;
        }

        private void UpdateQuestion()
        {
            _CurrentQuestionIndex++;

            displayQuestion(questions.ElementAt(_CurrentQuestionIndex));
        }

        private void displayQuestion(QuestionDto question)
        {
            QuestionText.Text = question.QuestionName;
            int randomIndex = random.Next(0, 4);

            if (randomIndex == 0)
            {
                AnswerAText.Text = question.CorrectAnswer.Name;
                AnswerBText.Text = question.WrongAnswers.ElementAt(0).Name;
                AnswerCText.Text = question.WrongAnswers.ElementAt(1).Name;
                AnswerDText.Text = question.WrongAnswers.ElementAt(2).Name;

                _CorrectAnswerIndex = 0;
            }
            else if (randomIndex == 1)
            {
                AnswerAText.Text = question.WrongAnswers.ElementAt(0).Name;
                AnswerBText.Text = question.CorrectAnswer.Name;
                AnswerCText.Text = question.WrongAnswers.ElementAt(1).Name;
                AnswerDText.Text = question.WrongAnswers.ElementAt(2).Name;

                _CorrectAnswerIndex = 1;
            }
            else if (randomIndex == 2)
            {
                AnswerAText.Text = question.WrongAnswers.ElementAt(0).Name;
                AnswerBText.Text = question.WrongAnswers.ElementAt(1).Name;
                AnswerCText.Text = question.CorrectAnswer.Name;
                AnswerDText.Text = question.WrongAnswers.ElementAt(2).Name;

                _CorrectAnswerIndex = 2;
            }
            else if (randomIndex == 3)
            {
                AnswerAText.Text = question.WrongAnswers.ElementAt(0).Name;
                AnswerBText.Text = question.WrongAnswers.ElementAt(2).Name;
                AnswerCText.Text = question.WrongAnswers.ElementAt(1).Name;
                AnswerDText.Text = question.CorrectAnswer.Name;

                _CorrectAnswerIndex = 3;
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
        }

        private void isAnswerCorrect(int buttonIndex)
        {
            if (buttonIndex == _CorrectAnswerIndex)
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
        }

        private void updateCorrectQuestionStreak()
        {
            if (previousAnswerWasCorrect)
            {
                currentCorrectStreak++;
                if (currentCorrectStreak > bestCorrectStreak)
                    bestCorrectStreak = currentCorrectStreak;
            }
            else
                currentCorrectStreak = 0;
        }

        private void drawRightWrong()
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
                default:
                    break;   
            }
            
        }

        async private void waitForUser()
        {
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(2));
        }

        private void resetColors()
        {
            AButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            BButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            CButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            DButton.Background = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private bool isGameOver()
        {
            if (_NumQuestionsAnswered == questionThreshold)
                return true;
            else
                return false;
        }

        private void ShowResultsPopup()
        {
            AnswerTextBlock.Text = "You got " + numCorrect + " questions right and " + numIncorrect + " questions wrong!\n  And your best streak was " + bestCorrectStreak + "!";

            if (!ResultsPopup.IsOpen) { ResultsPopup.IsOpen = true; }
            this.Frame.Opacity = 0.3;
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
            this.Frame.Opacity = 1;
            Frame.GoBack();
        }
    }
}
