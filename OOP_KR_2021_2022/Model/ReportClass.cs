using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_KR_2021_2022.Model
{
    class ReportClass
    {
        public void CreateBookReport(DataRowView book)
        {
            try
            {

                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));
                doc.Open();
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                PdfPTable table = new PdfPTable(2);

                PdfPCell cell = new PdfPCell(new Phrase("Выгруженная информация о книге", font));

                cell.Colspan = 2;
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                table.AddCell(cell);

                //Сначала добавляем заголовки таблицы
                cell = new PdfPCell(new Phrase(new Phrase("Название книги", font)));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(new Phrase(book.Row.ItemArray[2].ToString(), font)));
                table.AddCell(cell);
                table.AddCell(new Phrase("Автор", font));
                table.AddCell(new Phrase(book.Row.ItemArray[1].ToString(), font));
                table.AddCell(new Phrase("Издание", font));
                table.AddCell(new Phrase(book.Row.ItemArray[3].ToString(), font));
                table.AddCell(new Phrase("Год публикации", font));
                table.AddCell(new Phrase(book.Row.ItemArray[4].ToString(), font));
                table.AddCell(new Phrase("Количество страниц", font));
                table.AddCell(new Phrase(book.Row.ItemArray[5].ToString(), font));

                table.AddCell(cell);
                doc.Add(table);
                doc.Close();

                Process.Start(Environment.CurrentDirectory + "\\pdfTables.pdf");
            }
            catch (IOException exp)
            {
                MessageBox.Show("Данный файл используется, закройте его что бы можно было создать новый \n\n" + exp, "Ошибка!");
            }
        }

        public void CreateBooksReport(DataRowCollection books)
        {
            try
            {
                iTextSharp.text.Document doc = new iTextSharp.text.Document();

                PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));

                doc.Open();
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                PdfPTable table = new PdfPTable(5);
                PdfPCell cell = new PdfPCell(new Phrase("Выгруженная информация о имеющихся книгах", font));
                cell.Colspan = books.Count;
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase("Название", font));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Автор", font));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Издание", font));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Год публикации", font));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Количество страниц", font));
                table.AddCell(cell);
                foreach (DataRow book in books)
                {
                    table.AddCell(new Phrase(book.ItemArray[2].ToString(), font));
                    table.AddCell(new Phrase(book.ItemArray[1].ToString(), font));
                    table.AddCell(new Phrase(book.ItemArray[3].ToString(), font));
                    table.AddCell(new Phrase(book.ItemArray[4].ToString(), font));
                    table.AddCell(new Phrase(book.ItemArray[5].ToString(), font));
                }
                doc.Add(table);
                doc.Close();

                Process.Start(Environment.CurrentDirectory + "\\pdfTables.pdf");
            }
            catch (IOException exp)
            {
                MessageBox.Show("Данный файл используется, закройте его что бы можно было создать новый \n\n" + exp, "Ошибка!");
            }
        }

    }
}
