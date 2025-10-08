using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProcessing.Data.Interfaces;
using DataProcessing.Models.Entities;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DataProcessing.Data.Reports
{
    public class DocxReportService : IReportable
    {
        public void GenerateReport(string path, SessionData entity)
        {
            throw new NotImplementedException();
            using (WordprocessingDocument doc = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document))
            {

            }
        }
    }
}
