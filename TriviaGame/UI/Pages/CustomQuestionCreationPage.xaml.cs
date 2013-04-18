using Application.Domain;
using Microsoft.Practices.ServiceLocation;
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

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace UI.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class CustomQuestionCreationPage : UI.Common.LayoutAwarePage
    {
        private readonly IQuestionService _QuestionService;

        public CustomQuestionCreationPage()
        {
            _QuestionService = ServiceLocator.Current.GetInstance<IQuestionService>();

            this.InitializeComponent();
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

        

        private void FinishedButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (CorrectAnswerTextBox.Text.Length == 0 ||
                Answer1TextBox.Text.Length == 0 ||
                Answer2TextBox.Text.Length == 0 ||
                Answer3TextBox.Text.Length == 0)
            {

            }
            else
            {
                List<String> wrongAnswers = new List<String>();

                wrongAnswers.Add(Answer1TextBox.Text);
                wrongAnswers.Add(Answer2TextBox.Text);
                wrongAnswers.Add(Answer3TextBox.Text);

                _QuestionService.StoreCustomQuestionsAndAnswers(QuestionEntryTextBox.Text, CorrectAnswerTextBox.Text, wrongAnswers);
                Frame.GoBack();
            }
        }

        

        
    }
}
