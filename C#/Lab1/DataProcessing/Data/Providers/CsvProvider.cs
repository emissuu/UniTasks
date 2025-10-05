using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using DataProcessing.Data.Interfaces;
using DataProcessing.Models.Entities;

namespace DataProcessing.Data.Providers
{
    public class CsvProvider : IReadable, IWriteable
    {
        public SessionData ReadData(string path)
        {
            try
            {
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                }))
                {
                
                    List<MusicDTO> records = csv.GetRecords<MusicDTO>().ToList();
                    SessionData sessionData = new();
                    var artistDict = new Dictionary<string, int>();
                    var genreDict = new Dictionary<string, int>();

                    foreach (var record in records)
                    {
                        if (!artistDict.ContainsKey(record.artist))
                        {
                            Artist artist = new(Artist.Count, record.artist);
                            sessionData.Artists.Add(artist);
                            artistDict[record.artist] = artist.Id;
                        }
                        foreach (string genreName in record.genres.Split(',', StringSplitOptions.RemoveEmptyEntries))
                        {
                            string genreTrimmed = genreName.Trim();
                            if (!genreDict.ContainsKey(genreTrimmed))
                            {
                                Genre genre = new(Genre.Count, genreTrimmed);
                                sessionData.Genres.Add(genre);
                                genreDict[genreTrimmed] = genre.Id;
                            }
                        }
                        // Release_Date cleaning
                        DateTime releaseDate;
                        if(DateTime.TryParse(record.release_date, out releaseDate));
                        else if (DateTime.TryParseExact(record.release_date, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate))
                            releaseDate = new DateTime(releaseDate.Year, 1, 1);
                        else
                            releaseDate = new DateTime(1900, 1, 1);

                        // Rating_Count cleaning
                        if (record.rating_count.IndexOf(',') != -1)
                        {
                            record.rating_count = record.rating_count.Remove(record.rating_count.IndexOf(','), 1);
                        }
                        if (record.rating_count.IndexOf('r') != -1)
                        {
                            record.rating_count = record.rating_count.Substring(0, record.rating_count.IndexOf('r') - 1);
                        }
                        int rating = Int32.Parse(record.rating_count);

                        Song song = new(
                            Song.Count,
                            record.title,
                            artistDict[record.artist],
                            releaseDate,
                            record.genres.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(g => genreDict[g.Trim()]).ToList(),
                            record.user_score,
                            rating,
                            record.album_link
                        );
                        sessionData.Songs.Add(song);
                    }
                    sessionData.Name = Path.GetFileNameWithoutExtension(path);
                    sessionData.Number_Entries = sessionData.Songs.Count;
                    sessionData.DataPath = path;
                    return sessionData;
                }
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                    throw new ArgumentException("Cannot import invalid data");
                else
                    throw new Exception($"Error processing CSV data: {ex.Message}", ex);
            }
        }

        public void WriteData(string path, SessionData entity)
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteHeader<MusicDTO>();
                csv.NextRecord();
                foreach (var song in entity.Songs)
                {
                    var artistName = entity.Artists.First(a => a.Id == song.Artist_Id).Name;
                    var genreNames = string.Join(",", song.Genre_Ids.Select(gid => entity.Genres.First(g => g.Id == gid).Name));
                    var record = new MusicDTO
                    {
                        id = song.Id + 1,
                        title = song.Title,
                        artist = artistName,
                        release_date = song.Released_At.ToString("yyyy-MM-dd"),
                        genres = genreNames,
                        user_score = song.User_Score,
                        rating_count = song.Rating_Count.ToString(),
                        album_link = song.Album_Link
                    };
                    csv.WriteRecord(record);
                    csv.NextRecord();
                }
            }
        }
    }
}
