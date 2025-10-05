using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using DataProcessing.Data.Interfaces;
using DataProcessing.Models.Entities;

namespace DataProcessing.Data.Providers
{
    public class JsonProvider : IReadable, IWriteable
    {
        public SessionData ReadData(string path)
        {
            try
            {
                string json = File.ReadAllText(path);
                SessionData data = JsonSerializer.Deserialize<SessionData>(json);
                data.Name = Path.GetFileNameWithoutExtension(path);
                data.DataPath = path;
                data.Number_Entries = data.Songs.Count;
                return data;
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    MessageBox.Show("Cannot import invalid data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new ArgumentException("Cannot import invalid data");
                }
                else
                {
                    MessageBox.Show("Error processing JSON data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new Exception($"Error processing CSV data: {ex.Message}", ex);
                }
            }
        }

        public void WriteData(string path, SessionData entity)
        {
            try
            {
                string json = JsonSerializer.Serialize<SessionData>(entity, new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                });
                File.WriteAllText(path, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occured\n" + ex);
            }
        }
    }
}
