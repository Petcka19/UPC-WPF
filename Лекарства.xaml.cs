using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Office.Interop.Word;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Diagnostics;

namespace УП
{
    /// <summary>
    /// Логика взаимодействия для Лекарства.xaml
    /// </summary>
    public partial class Лекарства : System.Windows.Controls.Page
    {
        UCHEEntities2 entities = new UCHEEntities2();
        List<apteka> apteka = new List<apteka>();
        Microsoft.Office.Interop.Word._Application oWord;
        public Лекарства()
        {
            InitializeComponent();
            dgapteka.ItemsSource = entities.apteka.OrderBy(p=>p.Name_drug).ToList();
            apteka = entities.apteka.OrderBy(p => p.Name_drug).ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedApteka = dgapteka.SelectedItem as apteka;

            apteka newApteka = new apteka();
            entities.apteka.Add(newApteka);
            newApteka.Name_drug = selectedApteka.Name_drug;
            newApteka.use_drug = selectedApteka.use_drug;
            newApteka.EI = selectedApteka.EI;
            newApteka.value_in_pack = selectedApteka.value_in_pack;
            newApteka.Name_maker = selectedApteka.Name_maker;
            entities.SaveChanges();
            MessageBox.Show("Данные добавлены");
            dgapteka.ItemsSource = null;
            dgapteka.ItemsSource = entities.apteka.OrderBy(p => p.Name_drug).ToList();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedApteka = dgapteka.SelectedItem as apteka;
            entities.SaveChanges();
            MessageBox.Show("Данные обновлены");
            dgapteka.ItemsSource = null;
            dgapteka.ItemsSource = entities.apteka.OrderBy(p => p.Name_drug).ToList();
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedApteka = dgapteka.SelectedItem as apteka;
            var result = MessageBox.Show("Вы уверены, что хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                entities.apteka.Remove(selectedApteka);
                entities.SaveChanges();
                dgapteka.ItemsSource = null;
                dgapteka.ItemsSource = entities.apteka.OrderBy(p => p.Name_drug).ToList();
            }
        }

        private void ExportToWord_Click(object sender, RoutedEventArgs e)
        {
            oWord = new Microsoft.Office.Interop.Word.Application();
            _Document oDoc = GetDoc(Environment.CurrentDirectory + "\\ценник.dot");
            oDoc.SaveAs(FileName: Environment.CurrentDirectory + "\\For_print.doc");
            oDoc = oWord.Documents.Add();
            oWord.Visible = true;
            oDoc.Close();
        }
        private _Document GetDoc(string path)
        {
            _Document oDoc = oWord.Documents.Add(path);
            SetTemplate(oDoc);
            return oDoc;
        }
        private void SetTemplate(Microsoft.Office.Interop.Word._Document oDoc)
        {
            var selectedApteka = dgapteka.SelectedItem as apteka;
            oDoc.Bookmarks["Название"].Range.Text = selectedApteka.Name_drug.ToString();
            oDoc.Bookmarks["еи"].Range.Text = selectedApteka.EI.ToString();
            oDoc.Bookmarks["штук"].Range.Text = selectedApteka.value_in_pack.ToString();
        }
        private void TextCh_TextChanged(object sender, TextChangedEventArgs e)
        {
            apteka = entities.apteka.OrderBy(p => p.Name_drug).ToList();
            if (textCh.Text.Length == 0)
            {
                dgapteka.ItemsSource = apteka;
            }
            else
            {
                apteka=apteka.Where(p => p.Name_drug.ToLower().Contains(textCh.Text.ToLower())).OrderBy(p => p.Name_drug).ToList(); 
                dgapteka.ItemsSource = apteka;
            }
           
        }

        private void PDF(object sender, RoutedEventArgs e)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("../../sample.pdf", FileMode.Create));
            document.Open();
            var logo = iTextSharp.text.Image.GetInstance(new FileStream(@"..\..\3.jpg", FileMode.Open));
            logo.SetAbsolutePosition(500, 800); // Задайте координаты верхнего левого угла изображения на документе
            logo.ScaleToFit(30, 30); // Задайте требуемую ширину и высоту изображения
            writer.DirectContent.AddImage(logo);
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
            PdfPTable table = new PdfPTable(dgapteka.Columns.Count);
            PdfPCell cell = new PdfPCell(new Phrase("Список лекарств", font));
            cell.Colspan = dgapteka.Columns.Count;
            cell.HorizontalAlignment = 1;
            cell.Border = 0;
            table.AddCell(cell);
            string[] name = { "Название", "Показания к применению", "Ед. изм.", "Количество в упаковке", "Производитель" };
            for (int i = 0; i < dgapteka.Columns.Count; i++)
            {
                cell = new PdfPCell(new Phrase(name[i], font));
                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                table.AddCell(cell);
            }
            for (int j = 0; j < dgapteka.Items.Count; j++)
            {
                for (int i = 0; i < dgapteka.Columns.Count; i++)
                {
                    TextBlock b = dgapteka.Columns[i].GetCellContent(dgapteka.Items[j]) as TextBlock;
                    table.AddCell(new Phrase(b.Text, font));
                }
            }
            document.Add(table);
            document.Close();
            Process.Start(@"..\..\sample.pdf");
        }
    }
}
