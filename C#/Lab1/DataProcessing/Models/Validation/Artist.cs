using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models.Entities
{
    public partial class Artist
    {
        public Artist(int id, string name)
        {
            if (id != Count)
            {
                throw new ArgumentException("Artist ID must be sequential and start from 0.");
            }
            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Artist name cannot be null or empty.");
            }
            else
            {
                Id = id;
                Name = name;
                Count++;
            }
        }
    }
}
