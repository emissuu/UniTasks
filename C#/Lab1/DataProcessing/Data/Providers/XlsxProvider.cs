using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessing.Data.Interfaces;

namespace DataProcessing.Data.Providers
{
    public class XlsxProvider : IReadable, IWriteable
    {
        public Type ReadData<Type>(string path)
        {
            throw new NotImplementedException();
        }

        public void WriteData<Type>(string path, Type entity)
        {
            throw new NotImplementedException();
        }
    }
}
