using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessing.Data.Interfaces;
using DataProcessing.Models.Entities;
using OfficeOpenXml;

namespace DataProcessing.Data.Providers
{
    public class XlsxProvider : IReadable, IWriteable
    {
        public SessionData ReadData(string path)
        {
            ExcelPackage.License.SetNonCommercialOrganization("MusicStore_LLL");
            try
            {
                using (var package = new ExcelPackage(new FileInfo(path)))
                {
                    var data = new SessionData
                    {
                        Name = Path.GetFileNameWithoutExtension(path),
                        DataPath = path,
                        Albums = new List<Album>(),
                        Artists = new List<Artist>(),
                        Genres = new List<Genre>()
                    };
                    var sheerSongs = package.Workbook.Worksheets["Songs"];
                    if (sheerSongs != null)
                    {
                        int row = 2;
                        while (sheerSongs.Cells[row, 1].Value != null)
                        {
                            var song = new Album
                            {
                                Id = int.Parse(sheerSongs.Cells[row, 1].Value.ToString()),
                                Title = sheerSongs.Cells[row, 2].Value.ToString(),
                                Artist_Id = int.Parse(sheerSongs.Cells[row, 3].Value.ToString()),
                                Released_At = DateTime.Parse(sheerSongs.Cells[row, 4].Value.ToString()),
                                Genre_Ids = sheerSongs.Cells[row, 5].Value.ToString().Split(',').Select(int.Parse).ToList(),
                                User_Score = byte.Parse(sheerSongs.Cells[row, 6].Value.ToString()),
                                Rating_Count = int.Parse(sheerSongs.Cells[row, 7].Value.ToString()),
                                Album_Link = sheerSongs.Cells[row, 8].Value.ToString()
                            };
                            data.Albums.Add(song);
                            row++;
                        }
                    }
                    var sheerArtists = package.Workbook.Worksheets["Artists"];
                    if (sheerArtists != null)
                    {
                        int row = 2;
                        while (sheerArtists.Cells[row, 1].Value != null)
                        {
                            var artist = new Artist
                            {
                                Id = int.Parse(sheerArtists.Cells[row, 1].Value.ToString()),
                                Name = sheerArtists.Cells[row, 2].Value.ToString()
                            };
                            data.Artists.Add(artist);
                            row++;
                        }
                    }
                    var sheerGenres = package.Workbook.Worksheets["Genres"];
                    if (sheerGenres != null)
                    {
                        int row = 2;
                        while (sheerGenres.Cells[row, 1].Value != null)
                        {
                            var genre = new Genre
                            {
                                Id = int.Parse(sheerGenres.Cells[row, 1].Value.ToString()),
                                Name = sheerGenres.Cells[row, 2].Value.ToString()
                            };
                            data.Genres.Add(genre);
                            row++;
                        }
                    }
                    data.Number_Entries = data.Albums.Count;
                    return data;
                }
            }
            catch
            {
                throw;
            }
        }

        public void WriteData(string path, SessionData entity)
        {
            ExcelPackage.License.SetNonCommercialOrganization("MusicStore_LLL");
            using (var package = new ExcelPackage())
            {
                var sheerSongs = package.Workbook.Worksheets.Add("Songs");
                {
                    sheerSongs.Cells[1, 1].Value = "Id";
                    sheerSongs.Cells[1, 2].Value = "Title";
                    sheerSongs.Cells[1, 3].Value = "ArtistId";
                    sheerSongs.Cells[1, 4].Value = "ReleasedAt";
                    sheerSongs.Cells[1, 5].Value = "GenreIds";
                    sheerSongs.Cells[1, 6].Value = "UserScore";
                    sheerSongs.Cells[1, 7].Value = "RatingCount";
                    sheerSongs.Cells[1, 8].Value = "AlbumLink";
                    int row = 2;
                    foreach (var song in entity.Albums)
                    {
                        sheerSongs.Cells[row, 1].Value = song.Id;
                        sheerSongs.Cells[row, 2].Value = song.Title;
                        sheerSongs.Cells[row, 3].Value = song.Artist_Id;
                        sheerSongs.Cells[row, 4].Value = song.Released_At.ToString("yyyy-MM-dd");
                        sheerSongs.Cells[row, 5].Value = string.Join(",", song.Genre_Ids);
                        sheerSongs.Cells[row, 6].Value = song.User_Score;
                        sheerSongs.Cells[row, 7].Value = song.Rating_Count;
                        sheerSongs.Cells[row, 8].Value = song.Album_Link;
                        row++;
                    }
                }
                var sheerArtists = package.Workbook.Worksheets.Add("Artists");
                {
                    sheerArtists.Cells[1, 1].Value = "Id";
                    sheerArtists.Cells[1, 2].Value = "Name";
                    int row = 2;
                    foreach (var artist in entity.Artists)
                    {
                        sheerArtists.Cells[row, 1].Value = artist.Id;
                        sheerArtists.Cells[row, 2].Value = artist.Name;
                        row++;
                    }
                }
                var sheerGenres = package.Workbook.Worksheets.Add("Genres");
                {
                    sheerGenres.Cells[1, 1].Value = "Id";
                    sheerGenres.Cells[1, 2].Value = "Name";
                    int row = 2;
                    foreach (var genre in entity.Genres)
                    {
                        sheerGenres.Cells[row, 1].Value = genre.Id;
                        sheerGenres.Cells[row, 2].Value = genre.Name;
                        row++;
                    }
                }
                package.SaveAs(new FileInfo(path));
            }
        }
    }
}
