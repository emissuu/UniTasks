using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models.Entities
{
    public partial class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int Count { get; private set; } = 0;

        public override string ToString()
        {
            return Name;
        }
    }
}
