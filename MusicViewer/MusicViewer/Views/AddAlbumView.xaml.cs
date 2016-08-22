using MusicViewer.ViewModels;
using System.Windows;

namespace MusicViewer.Views
{
    /// <summary>
    /// Code-behind for AddAlbumView.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    public partial class AddAlbumView : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddAlbumView"/> class.
        /// </summary>
        public AddAlbumView()
        {
            InitializeComponent();

            AddAlbumViewModel viewModel = new AddAlbumViewModel();
            this.DataContext = viewModel;
        }
    }
}
