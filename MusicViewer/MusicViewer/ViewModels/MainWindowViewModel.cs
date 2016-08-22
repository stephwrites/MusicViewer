using MusicViewer.Commands;
using System.Windows.Input;

namespace MusicViewer.ViewModels
{
    /// <summary>
    /// ViewModel for MainWindow.
    /// </summary>
    /// <seealso cref="MusicViewer.ViewModels.BaseINotify" />
    public class MainWindowViewModel : BaseINotify
    {
        #region Commands
        /// <summary>
        /// Gets the open add command.
        /// </summary>
        /// <value>
        /// The open add command.
        /// </value>
        public ICommand OpenAddCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the open view command.
        /// </summary>
        /// <value>
        /// The open view command.
        /// </value>
        public ICommand OpenViewCommand
        {
            get;
            private set;
        }
        #endregion

        #region MainWindowViewModel Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {            
            this.OpenAddCommand = new OpenAddCommand();
            this.OpenViewCommand = new OpenViewCommand();
        }
        #endregion
    }
}
