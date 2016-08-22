using MusicViewer.Models;
using MusicViewer.ViewModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace MusicViewer.Controllers
{
    /// <summary>
    /// Main controller.
    /// </summary>
    /// <seealso cref="MusicViewer.ViewModels.BaseINotify" />
    public class MainController : BaseINotify
    {
        public const string defaultAlbumCoverPath = "/MusicViewer;component/Images/default.jpg";

        private MusicLibrary musicLibrary;
        public ReadOnlyObservableCollection<Album> AlbumsCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainController"/> class.
        /// </summary>
        /// <param name="musicLibrary">The music library.</param>
        public MainController(MusicLibrary musicLibrary)
        {
            this.musicLibrary = musicLibrary;
            this.AlbumsCollection = new ReadOnlyObservableCollection<Album>(musicLibrary.AlbumsCollection);
            if (this.AlbumsCollection.Count > 0)
                selectedItem = AlbumsCollection[0];
        }

        #region Album Variables
        private string newAlbumName;
        private string newArtistName;
        private string newAlbumCoverPath;
        private string updatedAlbumName;
        private string updatedArtistName;
        private Album selectedItem;
        #endregion

        #region CRUD Methods
        /// <summary>
        /// Adds the album. Shows error messages if album does not contain either an artist name OR an album name.
        /// </summary>
        /// <param name="albumToAdd">The album to add.</param>
        public void AddAlbum(Album albumToAdd)
        {
            this.musicLibrary.AlbumsCollection.Add(albumToAdd);
        }

        /// <summary>
        /// Removes the album.
        /// </summary>
        /// <param name="albumToRemove">The album to remove.</param>
        public void RemoveAlbum(Album albumToRemove)
        {
            this.musicLibrary.AlbumsCollection.Remove(albumToRemove);
        }
        #endregion

        #region Album Properties
        /// <summary>
        /// Gets or sets the new name of the album.
        /// Rest of properties work identically.
        /// </summary>
        /// <value>
        /// The new name of the album.
        /// </value>
        public string NewAlbumName
        {
            get 
            { 
                return newAlbumName; 
            }
            set
            {
                newAlbumName = value;
                this.NotifyPropertyChanged("NewAlbumName");
            }
        }

        public string NewArtistName
        {
            get 
            {
                return newArtistName; 
            }
            set
            {
                newArtistName = value;
                this.NotifyPropertyChanged("NewArtistName");
            }
        }

        public string NewAlbumCoverPath
        {
            get 
            { 
                return newAlbumCoverPath; 
            }
            set
            {
                newAlbumCoverPath = value;
                this.NotifyPropertyChanged("NewAlbumCoverPath");
            }
        }

        public string UpdatedAlbumName
        {
            get 
            { 
                return updatedAlbumName; 
            }
            set
            {
                updatedAlbumName = value;
                this.NotifyPropertyChanged("UpdatedAlbumName");
            }
        }

        public string UpdatedArtistName
        {
            get 
            { 
                return updatedArtistName; 
            }
            set
            {
                updatedArtistName = value;
                this.NotifyPropertyChanged("UpdatedArtistName");
            }
        }
        #endregion

        #region SelectedItem
        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        public Album SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                this.NotifyPropertyChanged("SelectedItem");
            }
        }
        #endregion
    }
}
