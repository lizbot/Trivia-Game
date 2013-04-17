﻿using Application.Domain;
using Application.Model;
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
    public sealed partial class GeneralOptionsPage : UI.Common.LayoutAwarePage
    {
        private readonly IOptionsService _OptionsService;
        private GeneralOptions GenOps;

        public GeneralOptionsPage()
        {
            _OptionsService = ServiceLocator.Current.GetInstance<IOptionsService>();

            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //GenOps = _OptionsService.GetGeneralOptions();

            //if (GenOps.IsMusicOn)
                //MusicToggleSwitch.IsOn = true;
            //else
                //MusicToggleSwitch.IsOn = false;

            //if (GenOps.IsSoundEffectsOn)
                //SoundEffectsToggleSwitch.IsOn = true;
            //else
                //SoundEffectsToggleSwitch.IsOn = false;
            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //_OptionsService.UpdateGeneralOptions(GenOps);

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
            //if (MusicToggleSwitch.IsOn)
            //    GenOps.IsMusicOn = true;
            //else
            //    GenOps.IsMusicOn = false;
        }

        private void SoundEffectsToggleSwitch_Toggled_1(object sender, RoutedEventArgs e)
        {
            //if (SoundEffectsToggleSwitch.IsOn)
            //    GenOps.IsSoundEffectsOn = true;
            //else
            //    GenOps.IsSoundEffectsOn = false;
        }

        private void HowToPlayButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
