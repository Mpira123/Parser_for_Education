using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;


namespace New_Proj_HTML
{
    public class ExcelExporter
    {
        static ExcelExporter()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public static void ExportToExcel(List<Company> companies, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Companies");

                // Set column headers
                worksheet.Cells[1, 1].Value = "Company Name";
                worksheet.Cells[1, 2].Value = "Company Address";
                worksheet.Cells[1, 3].Value = "Company Phone";

                int row = 2;
                foreach (var company in companies)
                {
                    worksheet.Cells[row, 1].Value = company.Name;
                    worksheet.Cells[row, 2].Value = company.Address;
                    worksheet.Cells[row, 3].Value = company.Phone;

                    row++;
                }

                FileInfo excelFile = new FileInfo(filePath);
                package.SaveAs(excelFile);
                Console.WriteLine("Data exported to Excel successfully.");
            }
        }
    }
}
