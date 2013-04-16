using Application.Domain;
using Application.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using UI.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UI.Pages
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class GeneralOptionsPage
    {
        private readonly IOptionsService _OptionsService;
        private GeneralOptions _GenOps;

        public GeneralOptionsPage()
        {
            _OptionsService = ServiceLocator.Current.GetInstance<IOptionsService>();

            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _GenOps = _OptionsService.GetGeneralOptions();

            if (_GenOps.IsMusicOn)
            {
                MusicCheckBox.Click += MusicOn;
                MusicCheckBox.Checked += MusicOn;
            }

            if (_GenOps.IsSoundEffectsOn)
            {
                SoundEffectsCheckBox.Click += SoundEffectsOn;
                SoundEffectsCheckBox.Checked += SoundEffectsOn;
            }

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _OptionsService.UpdateGeneralOptions(_GenOps);

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

        private void SoundEffectsOn(object sender, RoutedEventArgs e)
        {
            _GenOps.IsSoundEffectsOn = true;
        }
        
        private void MusicOn(object sender, RoutedEventArgs e)
        {
            _GenOps.IsMusicOn = true;
        }
    }
}
