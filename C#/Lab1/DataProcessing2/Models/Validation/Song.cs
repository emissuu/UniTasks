using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtistClass = DataProcessing.Models.Entities.Artist;

namespace DataProcessing.Models.Entities
{
    public partial class Album
    {
        public Album(int id, string title, int artistId, DateTime releasedAt, List<int> genreIds, byte userScore, int ratingsCount, string albumLink)
        {
            if (id != Count)
            {
                throw new ArgumentException("Song ID must be sequential and start from 0.");
            }
            else if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Song title cannot be null or empty.");
            }
            else if (artistId < 0 || artistId >= ArtistClass.Count)
            {
                throw new ArgumentException("Artist ID is out of range.");
            }
            else if (releasedAt > DateTime.Now)
            {
                throw new ArgumentException("Release date cannot be in the future.");
            }
            else if (genreIds == null || genreIds.Count == 0 || genreIds.Any(g => g < 0 || g >= Genre.Count))
            {
                throw new ArgumentException("Genre IDs are invalid.");
            }
            else if (userScore < 0 || userScore > 100)
            {
                throw new ArgumentException("User score must be between 0 and 100.");
            }
            else if (ratingsCount < 0)
            {
                throw new ArgumentException("Ratings count cannot be negative.");
            }
            else if (string.IsNullOrWhiteSpace(albumLink))
            {
                throw new ArgumentException("Album link must be a valid URL.");
            }
            else
            {
                Id = id;
                Title = title;
                Artist_Id = artistId;
                Released_At = releasedAt;
                Genre_Ids = genreIds;
                User_Score = userScore;
                Rating_Count = ratingsCount;
                Album_Link = albumLink;
                Count++;
            }
        }
    }
}
