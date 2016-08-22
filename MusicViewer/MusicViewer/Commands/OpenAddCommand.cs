using MusicViewer.Managers;
using MusicViewer.ViewModels;
using MusicViewer.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace MusicViewer.Commands
{
    /// <summary>
    /// Opens the Add New Album window
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class OpenAddCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenAddCommand"/> class.
        /// </summary>
        public OpenAddCommand()
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
        /// Opens Add New Album window.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            Window newAddAlbumView = new AddAlbumView();
            WindowManager.AddAlbumWindow = newAddAlbumView;

            AddAlbumViewModel newAddAlbumViewModel = new AddAlbumViewModel();
            newAddAlbumView.DataContext = newAddAlbumViewModel;

            newAddAlbumView.ShowDialog();

            newAddAlbumView.DataContext = null;
            newAddAlbumViewModel.Dispose();
        }

        #pragma warning disable 67
        public event EventHandler CanExecuteChanged;
        #pragma warning restore 67
    }
}
