using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models.Entities
{
    public partial class SessionData
    {
        public string Name { get; set; }
        public int Number_Entries { get; set; }
        public string DataPath { get; set; }
        public List<Song> Songs { get; set; } = new();
        public List<Artist> Artists { get; set; } = new();
        public List<Genre> Genres { get; set; } = new();
        //public Dictionary<int, string> ArtistDict { get; set; } = new();
        //public Dictionary<int, string> GenreDict { get; set; } = new();
    }
    public class MusicCsvDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public string release_date { get; set; }
        public string genres { get; set; }
        public byte user_score { get; set; }
        public string rating_count { get; set; }
        public string album_link { get; set; }
    }
}
