using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models.Entities
{
    public partial class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Artist_Id { get; set; }
        public DateTime Released_At { get; set; }
        public List<int> Genre_Ids { get; set; }
        public byte User_Score { get; set; }
        public int Rating_Count { get; set; }
        public string Album_Link { get; set; }
        public static int Count { get; private set; } = 0;

        public string Artist
        {
            get
            {
                return Artist_Id.ToString();
            }
        }
        public string ReleaseDate
        {
            get
            {
                return Released_At.ToString("dd-MM-yyyy");
            }
        }
        public string Genres
        {
            get
            {
                return string.Join(", ", Genre_Ids);
            }
        }
        public string Rating
        {
            get
            {
                return $"{Rating_Count} ratings";
            }
        }
    }
}
