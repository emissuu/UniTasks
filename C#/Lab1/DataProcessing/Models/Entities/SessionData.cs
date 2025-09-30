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
        public List<Song> Songs { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
