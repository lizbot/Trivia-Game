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
        MediaElement music = new MediaElement();
        bool isMusicPlaying;
        MediaElement rootMediaElement; 

        public MainPage()
        {
            //isMusicPlaying = false;
            

            this.InitializeComponent();
            this.Loaded += OnLoaded;
        }

        public async void PlayMusic()
        {
            Windows.Storage.StorageFolder _Folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Infrastructure\Sound");

            Windows.Storage.StorageFile _File = await _Folder.GetFileAsync("DigitalStream.wav");

            var stream = await _File.OpenReadAsync();
            music.SetSource(stream, _File.ContentType);
            isMusicPlaying = true;
        }
        
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DependencyObject rootGrid = VisualTreeHelper.GetChild(Window.Current.Content, 0);
            rootMediaElement = (MediaElement)VisualTreeHelper.GetChild(rootGrid, 0);
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
