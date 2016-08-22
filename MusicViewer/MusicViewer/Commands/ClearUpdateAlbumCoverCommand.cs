using MusicViewer.Controllers;
using MusicViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MusicViewer.Commands
{
    /// <summary>
    /// Clears the selected album art.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class ClearUpdateAlbumCoverCommand : ICommand, IDisposable
    {
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearUpdateAlbumCoverCommand"/> class.
        /// </summary>
        public ClearUpdateAlbumCoverCommand()
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
            if (App.Controller.SelectedItem.AlbumCoverPath == MainController.defaultAlbumCoverPath)
                return false;

            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// New album (newAlbum) is created that contains existing album name, existing artist name, and the newly cleared (nulled) album cover path. newAlbum
        /// is added to the ObservableCollection and old album SelectedItem is removed. ComboBox SelectedItem is then set to newAlbum to change focus.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter) == false)
                return;
            
            App.Controller.SelectedItem.AlbumCoverPath = MainController.defaultAlbumCoverPath;

            Album newAlbum = new Album(App.Controller.SelectedItem.AlbumName, App.Controller.SelectedItem.ArtistName, App.Controller.SelectedItem.AlbumCoverPath);

            Album oldSelectedItem = App.Controller.SelectedItem;

            App.Controller.AddAlbum(newAlbum);
            App.Controller.SelectedItem = newAlbum;
            App.Controller.RemoveAlbum(oldSelectedItem);
        }

        private void onControllerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedItem")
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
