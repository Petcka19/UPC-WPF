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
using System.Windows.Shapes;

namespace УП
{
    /// <summary>
    /// Логика взаимодействия для proc4.xaml
    /// </summary>
    public partial class proc4 : Window
    {
        public proc4()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (UCHEEntities2 db = new UCHEEntities2())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", Convert.ToInt32(Text.Text));
                System.Data.SqlClient.SqlParameter param2 = new System.Data.SqlClient.SqlParameter("@name2", Convert.ToInt32(Text2.Text));
                var avtBooks = db.Database.SqlQuery<Вывести_Лекарства_С_Условием_Result>("Вывести_Лекарства_С_Условием @name, @name2", param, param2);

                dgBook.ItemsSource = avtBooks.ToList();

            }
        }
    }
}
