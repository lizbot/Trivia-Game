using Application.Domain;
using Application.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.IO;
using System.Collections.Generic;
using UI.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
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
        MediaElement rootMediaElement;

        public GeneralOptionsPage()
        {
            _OptionsService = ServiceLocator.Current.GetInstance<IOptionsService>();

            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DependencyObject rootGrid = VisualTreeHelper.GetChild(Window.Current.Content, 0);
            rootMediaElement = (MediaElement)VisualTreeHelper.GetChild(rootGrid, 0);

            if (_GenOps.IsMusicOn)
                MusicToggleSwitch.IsOn = true;
            else
                MusicToggleSwitch.IsOn = false;

            if (_GenOps.IsSoundEffectsOn)
                SoundEffectsToggleSwitch.IsOn = true;
            else
                SoundEffectsToggleSwitch.IsOn = false;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _GenOps = _OptionsService.GetGeneralOptions();

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

        private void MusicToggleSwitch_Toggled_1(object sender, RoutedEventArgs e)
        {
            if (MusicToggleSwitch.IsOn)
            {
                _GenOps.IsMusicOn = true;
                rootMediaElement.IsMuted = false;
            }

            else
            {
                _GenOps.IsMusicOn = false;
                rootMediaElement.IsMuted = true;
            }
            
        }

        private void SoundEffectsToggleSwitch_Toggled_1(object sender, RoutedEventArgs e)
        {
            if (SoundEffectsToggleSwitch.IsOn)
                _GenOps.IsSoundEffectsOn = true;
            else
                _GenOps.IsSoundEffectsOn = false;
        }

        private void HowToPlayButton_Click_1(object sender, RoutedEventArgs e)
        {
            UserManualPopup.IsOpen = true;
        }

        private void ClosePopupButton_Click_1(object sender, RoutedEventArgs e)
        {
            UserManualPopup.IsOpen = false;
        }
    }
}
