using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessing.Models.Entities;

namespace DataProcessing.Data.Interfaces
{
    interface IReportable
    {
        public void CreateReport(string path, ref SessionData songs);
    }
}
