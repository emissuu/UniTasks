using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataProcessing.Models.Entities
{
    public partial class SessionData
    {
        [JsonIgnore]
        [XmlIgnore]
        public string Name { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public int Number_Entries { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public string DataPath { get; set; }
        [JsonInclude]
        public List<Album> Albums { get; set; } = new();
        [JsonInclude]
        public List<Artist> Artists { get; set; } = new();
        [JsonInclude]
        public List<Genre> Genres { get; set; } = new();
        [JsonConstructor]
        public SessionData() { }
    }
    public class MusicDTO
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
