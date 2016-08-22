using MusicViewer.Commands;
using MusicViewer.Controllers;
using MusicViewer.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MusicViewer.ViewModels
{
    /// <summary>
    /// AddAlbum ViewModel.
    /// </summary>
    /// <seealso cref="MusicViewer.ViewModels.BaseINotify" />
    public class AddAlbumViewModel : BaseINotify, IDisposable
    {
        #region Commands
        /// <summary>
        /// Gets or sets the add new album command.
        /// </summary>
        /// <value>
        /// The add new album command.
        /// </value>
        public AddNewAlbumCommand AddNewAlbumCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the browse new album cover path command.
        /// </summary>
        /// <value>
        /// The browse new album cover path command.
        /// </value>
        public BrowseNewAlbumCoverPathCommand BrowseNewAlbumCoverPathCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the clear new album cover command.
        /// </summary>
        /// <value>
        /// The clear new album cover command.
        /// </value>
        public ClearNewAlbumCoverCommand ClearNewAlbumCoverCommand
        {
            get;
            private set;
        }
        #endregion

        /// <summary>
        /// Gets the new albums collection.
        /// </summary>
        /// <value>
        /// The new albums collection.
        /// </value>
        public ReadOnlyObservableCollection<Album> NewAlbumsCollection
        {
            get
            {
                return App.Controller.AlbumsCollection;
            }
        }

        #region NewAlbum Properties
        /// <summary>
        /// Gets or sets the new name of the album.
        /// Rest of the properties work identically.
        /// </summary>
        /// <value>
        /// The new name of the album.
        /// </value>
        public string NewAlbumName
        {
            get
            {
                return App.Controller.NewAlbumName;
            }

            set
            {
                App.Controller.NewAlbumName = value;
            }
        }

        public string NewArtistName
        {
            get
            {
                return App.Controller.NewArtistName;
            }
            set
            {
                App.Controller.NewArtistName = value;
            }
        }

        public string NewAlbumCoverPath
        {
            get
            {
                return App.Controller.NewAlbumCoverPath;
            }
            set
            {
                App.Controller.NewAlbumCoverPath = value;
            }
        }
        #endregion

        #region AddAlbumViewModel Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AddAlbumViewModel"/> class.
        /// Sets the album cover to the default.
        /// </summary>
        public AddAlbumViewModel()
        {
            this.NewAlbumCoverPath = MainController.defaultAlbumCoverPath;
            
            this.AddNewAlbumCommand = new AddNewAlbumCommand();
            this.BrowseNewAlbumCoverPathCommand = new BrowseNewAlbumCoverPathCommand();
            this.ClearNewAlbumCoverCommand = new ClearNewAlbumCoverCommand();

            App.Controller.PropertyChanged += onControllerPropertyChanged;
            AddNewAlbumCommand.AlbumAdded += onAddNewAlbumCommandAlbumAdded;
        }
        #endregion

        #region PropertyChanged Methods
        /// <summary>
        /// On controller property changed, call NotifyPropertyChanged for PropertyName.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        void onControllerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.NotifyPropertyChanged(e.PropertyName);
        }

        /// <summary>
        /// On AlbumAdded for AddNewAlbumCommand, clears the NewArtistName and NewAlbumsName textboxes, and sets NewAlbumCoverPath to 
        /// default value.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void onAddNewAlbumCommandAlbumAdded(object sender, EventArgs e)
        {
            NewArtistName = string.Empty;
            NewAlbumName = string.Empty;
            NewAlbumCoverPath = MainController.defaultAlbumCoverPath;
        }
        #endregion

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (AddNewAlbumCommand != null)
            {
                AddNewAlbumCommand.Dispose();
                AddNewAlbumCommand = null;
            }

            if (ClearNewAlbumCoverCommand != null)
            {
                ClearNewAlbumCoverCommand.Dispose();
                ClearNewAlbumCoverCommand = null;
            }
        }
    }
}
