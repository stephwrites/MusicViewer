using MusicViewer.ViewModels;
using System.Windows;

namespace MusicViewer
{
    /// <summary>
    /// Code-behind for MainWindow view.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Sets data context to MainWindow.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            
            MainWindowViewModel viewModel = new MainWindowViewModel();

            this.DataContext = viewModel;
        }
    }
}
