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
using Microsoft.Office.Interop.Excel;

namespace УП
{
    /// <summary>
    /// Логика взаимодействия для Поставщики.xaml
    /// </summary>
    public partial class Поставщики : System.Windows.Controls.Page
    {
        public Поставщики()
        {
            InitializeComponent();
            dgpost.ItemsSource = entities.aptekapost.ToList();
            aptekapost = entities.aptekapost.ToList();
        }

        UCHEEntities2 entities = new UCHEEntities2();
        List<aptekapost> aptekapost = new List<aptekapost>();

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedApteka = dgpost.SelectedItem as aptekapost;

            aptekapost newApteka = new aptekapost();
            entities.aptekapost.Add(newApteka);
            newApteka.Short_name = selectedApteka.Short_name;
            newApteka.Long_name = selectedApteka.Long_name;
            newApteka.adress = selectedApteka.adress;
            newApteka.phone = selectedApteka.phone;
            newApteka.FIO_dir = selectedApteka.FIO_dir;
            entities.SaveChanges();
            MessageBox.Show("Данные добавлены");
            dgpost.ItemsSource = null;
            dgpost.ItemsSource = entities.aptekapost.ToList();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedApteka = dgpost.SelectedItem as aptekapost;
            entities.SaveChanges();
            MessageBox.Show("Данные обновлены");
            dgpost.ItemsSource = null;
            dgpost.ItemsSource = entities.aptekapost.ToList();
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedApteka = dgpost.SelectedItem as aptekapost;
            var result = MessageBox.Show("Вы уверены, что хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                entities.aptekapost.Remove(selectedApteka);
                entities.SaveChanges();
                dgpost.ItemsSource = null;
                dgpost.ItemsSource = entities.aptekapost.ToList();
            }
        }

        private void Excel(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            for (int i = 0; i < dgpost.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[1, i + 1];
                sheet1.Cells[1, i + 1].Font.Bold = true;
                myRange.Value2 = dgpost.Columns[i].Header;
            }
            for (int i = 0; i < dgpost.Columns.Count; i++)
            {
                for (int j = 0; j < dgpost.Items.Count; j++)
                {
                    TextBlock b = dgpost.Columns[i].GetCellContent(dgpost.Items[j]) as TextBlock;
                    if (b == null)
                    {
                        continue;
                    }
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
            sheet1.Columns.AutoFit();

        }

        private void TextCh_TextChanged(object sender, TextChangedEventArgs e)
        {
            aptekapost = entities.aptekapost.ToList();
            if (textCh.Text.Length == 0)
            {
                dgpost.ItemsSource = aptekapost;
            }
            else
            {
                aptekapost = aptekapost.Where(p => p.Long_name.ToLower().Contains(textCh.Text.ToLower())).ToList();
                dgpost.ItemsSource = aptekapost;
            }
        }
    }
}
