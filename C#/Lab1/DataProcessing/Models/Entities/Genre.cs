using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataProcessing.Models.Entities
{
    public partial class Genre
    {
        [JsonInclude]
        public int Id { get; set; }
        [JsonInclude]
        public string Name { get; set; }
        [JsonIgnore]
        [XmlIgnore]
        public static int Count { get; private set; } = 0;
        [JsonConstructor]
        public Genre() { }

        public override string ToString()
        {
            return Name;
        }
    }
}
