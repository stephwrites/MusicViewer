using MusicViewer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicViewer.Commands
{
    /// <summary>
    /// Clears the album cover path for new album.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class ClearNewAlbumCoverCommand : ICommand, IDisposable
    {
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearNewAlbumCoverCommand"/> class.
        /// </summary>
        public ClearNewAlbumCoverCommand()
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
            if (App.Controller.NewAlbumCoverPath == MainController.defaultAlbumCoverPath)
                return false;

            return true;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// Sets the new album's album cover path to the default.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter) == false)
                return;

            App.Controller.NewAlbumCoverPath = MainController.defaultAlbumCoverPath;
        }

        private void onControllerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "NewAlbumCoverPath")
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
