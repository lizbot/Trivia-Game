using Application.Domain;
using Application.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using UI.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

namespace UI.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class CustomOptionsPage
    {
        private readonly IOptionsService _OptionsService;

        private readonly CustomOptions _CusOps;

        private IQuestionService _QuestionsService;

        public CustomOptionsPage()
        {
            _OptionsService = ServiceLocator.Current.GetInstance<IOptionsService>();
            _QuestionsService = ServiceLocator.Current.GetInstance<IQuestionService>();
            
            _CusOps = _OptionsService.GetCustomOptions();

            InitializeComponent();

            // To be able to program against, Daniel.
            // _QuestionsService.StoreCustomQuestionsAndAnswers(questionString, rightAnswerString, WrongAnswerListOfStrings);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            QuestionNumSlider.Value = _CusOps.NumberOfQuestionsDesired;
            AnswerNumSlider.Value = _CusOps.NumberOfAnswersDisplayed;

            if (_CusOps.IsTimerOn)
                TimerToggleSwitch.IsOn = true;
            else
                TimerToggleSwitch.IsOn = false;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _OptionsService.UpdateCustomOptions(_CusOps);

            base.OnNavigatedFrom(e);
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

        private void AnswerNumSlider_ValueChanged_1(object sender, RangeBaseValueChangedEventArgs e)
        {
            _CusOps.NumberOfAnswersDisplayed = AnswerNumSlider != null ? (Int32)AnswerNumSlider.Value : 20;
        }

        private void QuestionNumSlider_ValueChanged_1(object sender, RangeBaseValueChangedEventArgs e)
        {
            _CusOps.NumberOfQuestionsDesired = QuestionNumSlider != null ? (Int32)QuestionNumSlider.Value : 20;
        }

        private void TimerToggleSwitch_Toggled_1(object sender, RoutedEventArgs e)
        {
            if (TimerToggleSwitch.IsOn)
                _CusOps.IsTimerOn = true;
            else
                _CusOps.IsTimerOn = false;
        }
    }
}
