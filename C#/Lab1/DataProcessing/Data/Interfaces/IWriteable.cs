using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessing.Models.Entities;

namespace DataProcessing.Data.Interfaces
{
    public interface IWriteable
    {
        public void WriteData(string path, SessionData entity);
    }
}
