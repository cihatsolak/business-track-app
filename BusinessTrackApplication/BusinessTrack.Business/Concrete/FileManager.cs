using BusinessTrack.Business.Interfaces;
using FastMember;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace BusinessTrack.Business.Concrete
{
    public class FileManager : IFileService
    {
        public async Task<byte[]> ExportExcel<T>(List<T> list, string workSheetName = "Worksheet1") where T : class, new()
        {
            var excelPackage = new ExcelPackage();
            var excelBlank = excelPackage.Workbook.Worksheets.Add(workSheetName);

            excelBlank.Cells["A1"].LoadFromCollection(list, true, TableStyles.Light15);
            var package = await excelPackage.GetAsByteArrayAsync();

            return package;
        }

        public string ExportPdf<T>(List<T> list) where T : class, new()
        {
            var dataTable = new DataTable();
            dataTable.Load(ObjectReader.Create(list));

            var fileName = $"{Guid.NewGuid()}.pdf";
            var returnPath = $"/documents/{fileName}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/documents/" + fileName);

            var stream = new FileStream(path, FileMode.Create);

            #region Font İşlemleri
            /*
             * Bilgisayar sisteminde bulunan arial.ttf font'unun yolunu buluyorum.
             */
            string arialFont = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont baseFont = BaseFont.CreateFont(arialFont, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font customFont = new Font(baseFont, 12, Font.NORMAL);
            #endregion

            Document document = new Document(PageSize.A4, 25f, 25f, 25f, 25f);
            PdfWriter.GetInstance(document, stream);
            document.Open();

            var pdfPTable = new PdfPTable(dataTable.Columns.Count);

            //Başlıkları ekliyoruz.
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                pdfPTable.AddCell(new Phrase(dataTable.Columns[i].ColumnName, customFont));
            }

            //İçerikleri Dolduruyoruz.
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    pdfPTable.AddCell(new Phrase(dataTable.Rows[i][j].ToString(), customFont));
                }
            }

            document.Add(pdfPTable);

            document.Close();
            return returnPath;
        }
    }
}
