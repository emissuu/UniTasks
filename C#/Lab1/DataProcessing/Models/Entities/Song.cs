using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace DataProcessing.Models.Entities
{
    public partial class Song
    {
        [JsonInclude]
        public int Id { get; set; }
        [JsonInclude]
        public string Title { get; set; }
        [JsonInclude]
        public int Artist_Id { get; set; }
        [JsonInclude]
        public DateTime Released_At { get; set; }
        [JsonInclude]
        public List<int> Genre_Ids { get; set; }
        [JsonInclude]
        public byte User_Score { get; set; }
        [JsonInclude]
        public int Rating_Count { get; set; }
        [JsonInclude]
        public string Album_Link { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public static int Count { get; private set; } = 0;
        [JsonConstructor]
        public Song() { }
        [JsonIgnore]
        [XmlIgnore]
        public int IdPlusOne
        {
            get
            {
                return Id + 1;
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public string Artist
        {
            get
            {
                return CurrentSession.Data.Artists.FirstOrDefault(a => a.Id == Artist_Id)?.Name ?? "Unknown";
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public string ReleaseDate
        {
            get
            {
                return Released_At.ToString("dd-MM-yyyy");
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public string Genres
        {
            get
            {
                return string.Join(", ", Genre_Ids.Select(gid => CurrentSession.Data.Genres.FirstOrDefault(g => g.Id == gid)?.Name ?? "Unknown"));
            }
        }
        [JsonIgnore]
        [XmlIgnore]
        public string Rating
        {
            get
            {
                return $"{Rating_Count} ratings";
            }
        }
    }
}
