using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicViewer.Managers
{
    /// <summary>
    /// Manages the windows for AddAlbumWindow and ViewAlbumWindow
    /// </summary>
    public class WindowManager
    {
        /// <summary>
        /// Gets or sets the add album window.
        /// </summary>
        /// <value>
        /// The add album window.
        /// </value>
        public static Window AddAlbumWindow 
        { 
            get;
            set; 
        }

        /// <summary>
        /// Gets or sets the view album window.
        /// </summary>
        /// <value>
        /// The view album window.
        /// </value>
        public static Window ViewAlbumWindow 
        { 
            get; 
            set; 
        }
    }
}
