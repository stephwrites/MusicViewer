using MusicViewer.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace MusicViewer.Commands
{
    /// <summary>
    /// Updates the ArtistName property of an album.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class UpdateArtistNameCommand : ICommand, IDisposable
    {

        public event EventHandler AlbumAdded;
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateArtistNameCommand"/> class.
        /// </summary>
       public UpdateArtistNameCommand()
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
            if (String.IsNullOrEmpty(App.Controller.UpdatedArtistName))
                return false;

            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// New album (newAlbum) is created that contains existing album name, user-given artist name, and existing album cover. newAlbum is added to the
        /// ObservableCollection and SelectedItem album is removed. Combobox SelectedItem is set to newAlbum to change focus.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            // Code below not necessary?
            //if (CanExecute(parameter) == false)
            //    return;

            Album newAlbum = new Album(App.Controller.SelectedItem.AlbumName, App.Controller.UpdatedArtistName, App.Controller.SelectedItem.AlbumCoverPath);
            Album oldSelectedItem = App.Controller.SelectedItem;

            App.Controller.AddAlbum(newAlbum);
            App.Controller.SelectedItem = newAlbum;
            App.Controller.RemoveAlbum(oldSelectedItem);

            if (AlbumAdded != null)
            {
                AlbumAdded(this, EventArgs.Empty);
            }
        }

        private void onControllerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "UpdatedArtistName")
            {
                if (CanExecuteChanged != null)
                {
                    CanExecuteChanged(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            App.Controller.PropertyChanged -= onControllerPropertyChanged;
        }
    }
}
