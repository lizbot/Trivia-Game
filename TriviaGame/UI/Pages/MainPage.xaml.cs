using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.ApplicationModel;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media;



namespace UI.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        //private async void OnLoaded()
        //{

        //    string file_name = "background_music.wav";
        //    MediaElement _mySound = new MediaElement();
        //    Windows.Storage.StorageFolder _Folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Infrastructure\Sound");

        //    Windows.Storage.StorageFile _File = await _Folder.GetFileAsync(file_name);

        //    var stream = await _File.OpenReadAsync();
        //    _mySound.SetSource(stream, _File.ContentType);

        //    _mySound.Play();
        //}

        public MainPage()
        {
            this.InitializeComponent();
            //this.Loaded += OnLoaded;
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
