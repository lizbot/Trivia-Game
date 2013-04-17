using System;
using Domain.Services.Configuration;
using Infrastructure.Initialization;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity.ServiceLocatorAdapter;
using UI.Pages;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UI
{
    using Microsoft.Practices.Unity;


    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// 
        /// This is technically the 'Composite Root.'
        /// </summary>
        public App()
        {

            InitializeComponent();
            Suspending += OnSuspending;

            // Creates a path to store the database at and initializes the database.
            PersistenceConfiguration.ApplicationDirectory = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            DatabaseInitialization.Database();

            // creates a new instance of the Unity Container that'll be used to register all dependencies at the root.
            IUnityContainer unityContainer = new UnityContainer();

            // All layers configured dependencies, interface to concrete type or to self.
            PersistenceConfiguration.ConfigureDependencies(unityContainer);
            DomainConfiguration.ConfigureDependencies(unityContainer);

            // creates the service locator to resolve dependencies each individual pages depends on.
            var provider = new UnityServiceLocator(unityContainer);
            ServiceLocator.SetLocatorProvider(() => provider);
        }


        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {

            //var rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                rootFrame.Style = Resources["RootFrameStyle"] as Style;
                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
