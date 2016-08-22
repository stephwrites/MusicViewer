using MusicViewer.Controllers;
using MusicViewer.Models;
using System.Windows;

namespace MusicViewer
{
    /// <summary>
    /// Code-behind for App view.
    /// </summary>
    /// <seealso cref="System.Windows.Application" />
    public partial class App : Application
    {
        public static MainController Controller;
        private static MusicLibrary musicLibrary;

        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// Sets musicLibrary to be shared throughout application.
        /// When the app opens, loads the XML file to populate ObservableCollection.
        /// </summary>
        public App()
        {
            App.musicLibrary = new MusicLibrary();
            App.musicLibrary.Load();

            App.Controller = new MainController(App.musicLibrary);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Exit" /> event.
        /// When the app closes, saves contents of ObservableCollection to XML file.
        /// </summary>
        /// <param name="e">An <see cref="T:System.Windows.ExitEventArgs" /> that contains the event data.</param>
        protected override void OnExit(ExitEventArgs e)
        {
            App.musicLibrary.Save();
            base.OnExit(e);
        }
    }
}
