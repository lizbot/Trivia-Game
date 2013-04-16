using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.ApplicationModel;
using System;
using System.Collections.Generic;



namespace UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

/*
        private async void PlaySound(object sender, RoutedEventArgs e)
        {
            MediaElement sound = new MediaElement();
            StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync("Assets/sounds");
            StorageFile file = await folder.GetFileAsync("mission2.wav");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            sound.SetSource(stream, file.ContentType);
            sound.Play();

        }

  */      
        public MainPage()
        {

        //    sound.MediaOpened += PlaySound;
         //   sound.Play();
           
            this.InitializeComponent();
        }
 
        
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void StartGameClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GameSelectionPage));
        }

        private void StatisticsClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(StatisticsPage));
        }

        private void OptionsClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(OptionsPage));
        }
    }
}
