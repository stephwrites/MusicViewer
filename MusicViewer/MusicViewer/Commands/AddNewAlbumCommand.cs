using MusicViewer.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace MusicViewer.Commands
{
    /// <summary>
    /// Add a new album from user-given data.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class AddNewAlbumCommand : ICommand
    {
        public event EventHandler AlbumAdded;
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddNewAlbumCommand"/> class.
        /// </summary>
        public AddNewAlbumCommand()
        {
            App.Controller.PropertyChanged += onControllerPropertyChanged;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (String.IsNullOrEmpty(App.Controller.NewAlbumName) || String.IsNullOrEmpty(App.Controller.NewArtistName))
                return false;

            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// New album (newAlbum) is created that contains user-given album name, user-given artist name, and user-given album cover. newAlbum is then added
        /// to the ObservableCollection. If newAlbum is null or if artist name or album name are missing, an error is shown.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter) == false)
                return;
            
            Album newAlbum = new Album(App.Controller.NewAlbumName, App.Controller.NewArtistName, App.Controller.NewAlbumCoverPath);

            App.Controller.AddAlbum(newAlbum);

            if (AlbumAdded != null)
            {
                AlbumAdded(this, EventArgs.Empty);
            }
        }

        private void onControllerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "NewArtistName" || e.PropertyName == "NewAlbumName")
            {
                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, EventArgs.Empty);
                }
            }
        }

        public void Dispose()
        {
            App.Controller.PropertyChanged -= onControllerPropertyChanged;
        }
    }
}
