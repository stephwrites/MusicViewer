using MusicViewer.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace MusicViewer.Commands
{
    /// <summary>
    /// Updates the AlbumName property of an album with user-given data.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class UpdateAlbumNameCommand : ICommand, IDisposable
    {

        public event EventHandler AlbumAdded;
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateAlbumNameCommand"/> class.
        /// </summary>
        public UpdateAlbumNameCommand()
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
            if (String.IsNullOrEmpty(App.Controller.UpdatedAlbumName))
                return false;

            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// New album (newAlbum) is created that contains user-given album name, existing artist name, and existing album cover. newAlbum is added to the
        /// ObservableCollection and old album SelectedItem is removed. Sets the combobox SelectedItem to newAlbum to change the focus.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
           if (CanExecute(parameter) == false)
                return;

           Album newAlbum = new Album(App.Controller.UpdatedAlbumName, App.Controller.SelectedItem.ArtistName, App.Controller.SelectedItem.AlbumCoverPath);
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
            if (e.PropertyName == "UpdatedAlbumName")
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
