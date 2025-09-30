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
    }
}
