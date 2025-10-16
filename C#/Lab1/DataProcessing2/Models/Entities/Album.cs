using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataProcessing.Models.Entities
{
    public partial class Album
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
        public Album() { }
        [JsonIgnore]
        [XmlIgnore]
        public int IdPlusOne
        {
            get
            {
                return Id + 1;
            }
            set
            {
                return;
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
            set
            {
                CurrentSession.Data.Artists.First(a => a.Name == value);
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
            set
            {
                try {
                    Released_At = DateTime.ParseExact(value, "dd-MM-yyyy", null);
                }
                catch (Exception e)
                {
                    return;
                }
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
            set
            {
                Genre_Ids = value.Split(", ").Select(gname => CurrentSession.Data.Genres.FirstOrDefault(g => g.Name == gname)?.Id ?? -1).Where(id => id != -1).ToList();
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
            set
            {
                try
                {
                    Rating_Count = int.Parse(value.Split(" ")[0]);
                }
                catch (Exception e)
                {
                    return;
                }
            }
        }
    }
}
