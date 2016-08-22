namespace MusicViewer.Models
{
    /// <summary>
    /// Album model.
    /// </summary>
    public class Album
    {
        #region Album Variables
        private string albumName;
        private string artistName;
        private string albumCoverPath;
        #endregion

        #region Album Properties
        /// <summary>
        /// Gets or sets the name of the album.
        /// Rest of properties work identically.
        /// </summary>
        /// <value>
        /// The name of the album.
        /// </value>
        public string AlbumName
        {
            get { return albumName; }
            set
            {
                if (albumName != value)
                {
                    albumName = value;
                }
            }
        }

        public string ArtistName
        {
            get { return artistName; }
            set
            {
                if (artistName != value)
                {
                    artistName = value;
                }
            }
        }

        public string AlbumCoverPath
        {
            get { return albumCoverPath; }
            set
            {
                if (albumCoverPath != value)
                {
                    albumCoverPath = value;
                }
            }
        }
        #endregion

        #region Album Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Album"/> class.
        /// </summary>
        /// <param name="albumName">Name of the album.</param>
        /// <param name="artistName">Name of the artist.</param>
        /// <param name="albumCoverPath">The album cover path.</param>
        public Album(string albumName, string artistName, string albumCoverPath)
        {
            this.albumName = albumName;
            this.artistName = artistName;
            this.albumCoverPath = albumCoverPath;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Album"/> class.
        /// This is a paramterless constructor for the XML serializer.
        /// </summary>
        public Album()
        {

        }
        #endregion
    }
}
