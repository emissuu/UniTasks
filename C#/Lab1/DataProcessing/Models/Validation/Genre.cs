using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Models.Entities
{
    public partial class Genre
    {
        public Genre(int id, string name)
        {
            if (id != Count)
            {
                throw new ArgumentException("Genre ID must be sequential and start from 0.");
            }
            else if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Genre name cannot be null or empty.");
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
