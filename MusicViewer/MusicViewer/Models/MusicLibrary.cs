using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace MusicViewer.Models
{
    /// <summary>
    /// MusicLibrary model.
    /// </summary>
    public class MusicLibrary
    {
        private string userLibraryFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UserLibrary_MusicViewer.xml");

        #region MusicLibrary Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicLibrary"/> class.
        /// </summary>
        public MusicLibrary()
        {
            
        }
        #endregion

        #region ObservableCollection of Albums
        private ObservableCollection<Album> albumsCollection = new ObservableCollection<Album>();

        /// <summary>
        /// Gets the albums collection.
        /// </summary>
        /// <value>
        /// The albums collection.
        /// </value>
        public ObservableCollection<Album> AlbumsCollection
        {
            get
            {
                return albumsCollection;
            }
        }

        /// <summary>
        /// Loads pre-created albums (for demonstration purposes; this method and associated images can be removed).
        /// </summary>
        public void LoadAlbums()
        {
            AlbumsCollection.Add(new Album("If You're Reading This It's Too Late", "Drake", "/MusicViewer;component/Images/ifyourereadingthisitstoolate.jpg"));
            AlbumsCollection.Add(new Album("In Defense of the Genre", "Say Anything", "/MusicViewer;component/Images/indefenseofthegenre.jpg"));
            AlbumsCollection.Add(new Album("Picaresque", "The Decemberists", "/MusicViewer;component/Images/picaresque.jpg"));
            AlbumsCollection.Add(new Album("In Evening Air", "Future Islands", "/MusicViewer;component/Images/ineveningair.jpg"));
            AlbumsCollection.Add(new Album("You're Gonna Miss It All", "Modern Baseball", "/MusicViewer;component/Images/youregonnamissitall.jpg"));
        }

        /// <summary>
        /// Loads user library of albums from the XML file.
        /// </summary>
        public void Load()
        {
            if (File.Exists(userLibraryFileName))
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Album>));

                using (StreamReader reader = new StreamReader(userLibraryFileName))
                {
                    this.albumsCollection = (ObservableCollection<Album>)xs.Deserialize(reader);
                }
            }

            else
            {
                LoadAlbums();
            }
        }

        /// <summary>
        /// Saves user library of albums to the XML file.
        /// </summary>
        public void Save()
        {
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Album>));

            using (StreamWriter writer = new StreamWriter(userLibraryFileName))
            {
                xs.Serialize(writer, this.albumsCollection);
            }
        }
        #endregion
    }
}
