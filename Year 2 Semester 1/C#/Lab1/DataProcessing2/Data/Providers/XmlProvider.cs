using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DataProcessing.Data.Interfaces;
using DataProcessing.Models.Entities;

namespace DataProcessing.Data.Providers
{
    public class XmlProvider : IReadable, IWriteable
    {
        public SessionData ReadData(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SessionData));
            try
            {
                using (FileStream reader = new FileStream(path, FileMode.Open))
                {
                    SessionData data = (SessionData)serializer.Deserialize(reader);
                    data.Name = Path.GetFileNameWithoutExtension(path);
                    data.DataPath = path;
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
            XmlSerializer serializer = new XmlSerializer(typeof(SessionData));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, entity);
            }
        }
    }
}
