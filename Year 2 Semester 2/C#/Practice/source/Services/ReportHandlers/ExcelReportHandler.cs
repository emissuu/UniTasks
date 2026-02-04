using Data.Models;
using OfficeOpenXml;
using Services.Models;
using System.Drawing;

namespace Services.ReportHandlers
{
    public static class ExcelReportHandler
    {
        public static void CreateReport(List<AuditLogDetails> auditLogs, User user, string path)
        {
            ExcelPackage.License.SetNonCommercialOrganization("TeamTaskDigital");
            using (var package = new ExcelPackage())
            {
                var sheetReport = package.Workbook.Worksheets.Add("Report");
                sheetReport.Column(2).Width = 20;
                sheetReport.Column(4).Width = 10;
                sheetReport.Column(6).Width = 20;
                sheetReport.Column(7).Width = 72;
                sheetReport.Column(8).Width = 72;
                sheetReport.Cells[1, 1].Value = "TeamTask report of Audit Log";
                sheetReport.Cells[2, 1].Value = $"As of: {DateTime.UtcNow.ToString("g")} UTC.";
                sheetReport.Cells[3, 1].Value = $"Created by: {user.UserName}.";
                WriteHeaders(sheetReport, ["Id", "User", "Entity Id", "Entity Type", "Action", "Created At", "Old Value", "New Value"]);
                for (int i = 0; i < auditLogs.Count; i++)
                {
                    WriteAuditLog(sheetReport, auditLogs[i], i + 5);
                }
                package.SaveAs(new FileInfo(path));
            }
        }
        private static void WriteHeaders(ExcelWorksheet sheet, string[] headers)
        {
            var color = ColorTranslator.FromHtml("#7DCEA0");
            int column = 1;
            foreach (var header in headers)
            {
                sheet.Cells[4, column].Value = header;
                sheet.Cells[4, column].Style.Fill.SetBackground(color);
                column++;
            }
        }
        private static void WriteAuditLog(ExcelWorksheet sheet, AuditLogDetails log, int row)
        {
            var color1 = ColorTranslator.FromHtml("#D4EFDF");
            var color2 = ColorTranslator.FromHtml("#E9F7EF");
            sheet.Cells[row, 1].Value = log.Id;
            sheet.Cells[row, 2].Value = log.User.UserName;
            sheet.Cells[row, 3].Value = log.EntityId;
            sheet.Cells[row, 4].Value = log.EntityType;
            sheet.Cells[row, 5].Value = log.Action;
            sheet.Cells[row, 6].Value = log.GetCreatedAtUtc;
            sheet.Cells[row, 7].Value = log.OldValue;
            sheet.Cells[row, 8].Value = log.NewValue;
            if (row % 2 == 1)
                sheet.Cells[$"A{row}:H{row}"].Style.Fill.SetBackground(color1);
            else
                sheet.Cells[$"A{row}:H{row}"].Style.Fill.SetBackground(color2);
        }
    }
}