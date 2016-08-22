using MusicViewer.Commands;
using MusicViewer.Controllers;
using MusicViewer.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MusicViewer.ViewModels
{
    /// <summary>
    /// ViewModel for UpdateorDeleteView.
    /// </summary>
    /// <seealso cref="MusicViewer.ViewModels.BaseINotify" />
    public class UpdateOrDeleteViewModel : BaseINotify, IDisposable
    {
        #region Commands
        /// <summary>
        /// Gets or sets the remove album command.
        /// </summary>
        /// <value>
        /// The remove album command.
        /// </value>
        public ICommand RemoveAlbumCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the update album name command.
        /// </summary>
        /// <value>
        /// The update album name command.
        /// </value>
        public UpdateAlbumNameCommand UpdateAlbumNameCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the update artist name command.
        /// </summary>
        /// <value>
        /// The update artist name command.
        /// </value>
        public UpdateArtistNameCommand UpdateArtistNameCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the browse update album cover path command.
        /// </summary>
        /// <value>
        /// The browse update album cover path command.
        /// </value>
        public BrowseUpdateAlbumCoverPathCommand BrowseUpdateAlbumCoverPathCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the clear album cover command.
        /// </summary>
        /// <value>
        /// The clear album cover command.
        /// </value>
        public ClearUpdateAlbumCoverCommand ClearUpdateAlbumCoverCommand
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
        /// Gets or sets the new name of the album, notifies of property changed.
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
                //this.NotifyPropertyChanged("NewAlbumName");
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
                //this.NotifyPropertyChanged("NewArtistName");
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
                if (value == null || value == "")
                    App.Controller.NewAlbumCoverPath = MainController.defaultAlbumCoverPath;
                //this.NotifyPropertyChanged("NewAlbumCoverPath");
            }
        }

        public Album SelectedItem 
        {
            get
            {
                return App.Controller.SelectedItem;
            }
            set
            {
                App.Controller.SelectedItem = value;
                //this.NotifyPropertyChanged("SelectedItem");
            }
        }

        public string UpdatedAlbumName
        {
            get
            {
                return App.Controller.UpdatedAlbumName;
            }
            set
            {
                App.Controller.UpdatedAlbumName = value;
                //this.NotifyPropertyChanged("UpdatedAlbumName");
            }
        }

        public string UpdatedArtistName
        {
            get
            {
                return App.Controller.UpdatedArtistName;
            }
            set
            {
                App.Controller.UpdatedArtistName = value;
                //this.NotifyPropertyChanged("UpdatedArtistName");
            }
        }
        #endregion

        #region UpdateOrDeleteViewModel Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOrDeleteViewModel"/> class.
        /// </summary>
        public UpdateOrDeleteViewModel()
        {
            this.RemoveAlbumCommand = new RemoveAlbumCommand();
            this.UpdateAlbumNameCommand = new UpdateAlbumNameCommand();
            this.UpdateArtistNameCommand = new UpdateArtistNameCommand();
            this.BrowseUpdateAlbumCoverPathCommand = new BrowseUpdateAlbumCoverPathCommand();
            this.ClearUpdateAlbumCoverCommand = new ClearUpdateAlbumCoverCommand();

            App.Controller.PropertyChanged += onControllerPropertyChanged;
            UpdateAlbumNameCommand.AlbumAdded += onUpdateAlbumNameCommandAlbumAdded;
            UpdateArtistNameCommand.AlbumAdded += onUpdateArtistNameCommandAlbumAdded;
        }
        #endregion

        #region PropertyChanged Methods
        /// <summary>
        /// On controller property changed, calls NotifyPropertyChanged on PropertyName.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        void onControllerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.NotifyPropertyChanged(e.PropertyName);
        }

        /// <summary>
        /// On AlbumAdded for UpdateArtistName, clears the UpdatedArtistName textbox.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void onUpdateArtistNameCommandAlbumAdded(object sender, EventArgs e)
        {
            UpdatedArtistName = string.Empty;
        }

        /// <summary>
        /// On AlbumAdded for UpdateAlbumName, clears the UpdatedAlbumName textbox.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void onUpdateAlbumNameCommandAlbumAdded(object sender, EventArgs e)
        {
            UpdatedAlbumName = string.Empty;
        }
        #endregion

        public void Dispose()
        {
            if (UpdateAlbumNameCommand != null)
            {
                UpdateAlbumNameCommand.Dispose();
                UpdateAlbumNameCommand = null;
            }

            if (UpdateArtistNameCommand != null)
            {
                UpdateArtistNameCommand.Dispose();
                UpdateArtistNameCommand = null;
            }

            if (ClearUpdateAlbumCoverCommand != null)
            {
                ClearUpdateAlbumCoverCommand.Dispose();
                ClearUpdateAlbumCoverCommand = null;
            }
        }
    }

}
