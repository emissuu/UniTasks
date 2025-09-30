using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Data.Interfaces
{
    public interface IReadable
    {
        public Type ReadData<Type>(string path);
    }
}
