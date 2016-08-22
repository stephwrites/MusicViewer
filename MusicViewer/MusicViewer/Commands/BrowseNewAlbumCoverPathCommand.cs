using Microsoft.Win32;
using System;
using System.Windows.Input;


namespace MusicViewer.Commands
{
    /// <summary>
    /// Browse for a file when adding a new album
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class BrowseNewAlbumCoverPathCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrowseNewAlbumCoverPathCommand"/> class.
        /// </summary>
        public BrowseNewAlbumCoverPathCommand()
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
        /// Sets the new album cover path to user-selected filename.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
            if (openFileDialog.ShowDialog() == true)
            {
                App.Controller.NewAlbumCoverPath = openFileDialog.FileName;
            }

            if (AlbumAdded != null)
            {
                AlbumAdded(this, EventArgs.Empty);
            }
        }

        public event EventHandler AlbumAdded;

        #pragma warning disable 67
        public event EventHandler CanExecuteChanged;
        #pragma warning restore 67
    }
}
