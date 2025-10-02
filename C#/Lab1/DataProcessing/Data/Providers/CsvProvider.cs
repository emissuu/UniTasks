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
                
                    List<MusicCsvDTO> records = csv.GetRecords<MusicCsvDTO>().ToList();
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
                            if (!genreDict.ContainsKey(genreName))
                            {
                                Genre genre = new(Genre.Count, genreName);
                                sessionData.Genres.Add(genre);
                                genreDict[genreName] = genre.Id;
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
                        record.rating_count = record.rating_count.Substring(0, record.rating_count.IndexOf('r') - 1);
                        int rating = Int32.Parse(record.rating_count);

                        Song song = new(
                            Song.Count,
                            record.title,
                            artistDict[record.artist],
                            releaseDate,
                            record.genres.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(g => genreDict[g]).ToList(),
                            record.user_score,
                            rating,
                            record.album_link
                        );
                        sessionData.Songs.Add(song);
                    }
                    sessionData.Name = Path.GetFileNameWithoutExtension(path);
                    sessionData.Number_Entries = sessionData.Songs.Count;
                    sessionData.DataPath = path;
                    sessionData.ArtistDict = artistDict.ToDictionary(a => a.Value, b => b.Key);
                    sessionData.GenreDict = genreDict.ToDictionary(a => a.Value, b => b.Key);
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
            throw new NotImplementedException();
        }
    }
}
