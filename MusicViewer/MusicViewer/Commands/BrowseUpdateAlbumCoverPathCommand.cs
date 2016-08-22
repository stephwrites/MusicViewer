using Microsoft.Win32;
using MusicViewer.Models;
using System;
using System.Windows;
using System.Windows.Input;

namespace MusicViewer.Commands
{
    /// <summary>
    /// Browse for a new file when updating the album cover path
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class BrowseUpdateAlbumCoverPathCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowseUpdateAlbumCoverPathCommand"/> class.
        /// </summary>
        public BrowseUpdateAlbumCoverPathCommand()
        {

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
            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// New album (newAlbum) is created that contains existing album name, existing artist name, and the newly set album cover path. newAlbum is added
        /// to the ObservableCollection and old album SelectedItem is removed. ComboBox SelectedItem is then set to newAlbum to change focus.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (App.Controller.SelectedItem == null)
            {
                MessageBox.Show("Please select an album to update", "Simple Music Viewer v1.0", MessageBoxButton.OK);
            }

            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (openFileDialog.ShowDialog() == true)
                {
                    App.Controller.SelectedItem.AlbumCoverPath = openFileDialog.FileName;
                }

                if (AlbumAdded != null)
                {
                    AlbumAdded(this, EventArgs.Empty);
                }

                Album newAlbum = new Album(App.Controller.SelectedItem.AlbumName, App.Controller.SelectedItem.ArtistName, App.Controller.SelectedItem.AlbumCoverPath);
                Album oldSelectedItem = App.Controller.SelectedItem;

                App.Controller.AddAlbum(newAlbum);
                App.Controller.SelectedItem = newAlbum;
                App.Controller.RemoveAlbum(oldSelectedItem);
            }
        }

        public event EventHandler AlbumAdded;

        #pragma warning disable 67
        public event EventHandler CanExecuteChanged;
        #pragma warning restore 67
    }
}
