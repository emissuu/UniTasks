using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Data.Interfaces
{
    public interface IWriteable
    {
        public void WriteData<Type>(string path, Type entity);
    }
}
