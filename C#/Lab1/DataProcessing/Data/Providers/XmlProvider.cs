using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessing.Data.Interfaces;
using DataProcessing.Models.Entities;

namespace DataProcessing.Data.Providers
{
    public class XmlProvider : IReadable, IWriteable
    {
        public SessionData ReadData(string path)
        {
            throw new NotImplementedException();
        }

        public void WriteData(string path, SessionData entity)
        {
            throw new NotImplementedException();
        }
    }
}
