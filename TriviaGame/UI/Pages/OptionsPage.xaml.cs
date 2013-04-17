using System;
using System.Collections.Generic;
using UI.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Application.Domain;
using Microsoft.Practices.ServiceLocation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace UI.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class OptionsPage : UI.Common.LayoutAwarePage
    {
        private readonly IOptionsService _OptionsService;

        public OptionsPage()
        {
            this.InitializeComponent();
            _OptionsService = ServiceLocator.Current.GetInstance<IOptionsService>();

            //This is for testing so we can make sure that if the user changes the options, they are going to be
            //updated in the general and custom options tables

            //This was can be use to pass the new options from the UI to the db in order to update the changes and save them.

            //var opsGen = new GeneralOptions
            //{
            //    GeneralOptionsId = 2,
            //    IsMusicOn = true,
            //    IsSoundEffectsOn = true,
            //};

            //_OptionsService.UpdateGeneralOptions(opsGen);

            //var opsCust = new CustomOptions
            //{
            //    CustomOptionId = 2,
            //    IsTimerOn = true,
            //    NumberOfAnswersDisplayed = 2,
            //    NumberOfQuestionsDesired = 15,
            //};

            //_OptionsService.UpdateCustomOptions(opsCust); 

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

        private void GeneralOptionsClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GeneralOptionsPage));
        }
        private void CustomOptionsClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CustomOptionsPage));
        }
    }
}
