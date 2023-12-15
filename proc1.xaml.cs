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
    /// Логика взаимодействия для proc1.xaml
    /// </summary>
    public partial class proc1 : Window
    {
        public proc1()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (UCHEEntities2 db = new UCHEEntities2())
            {
                System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", Convert.ToInt32(Text.Text));
                var avtBooks = db.Database.SqlQuery<GetSupplyDetails_Result>("GetSupplyDetails @name", param);

                dgBook.ItemsSource = avtBooks.ToList();

            }
        }
    }
}
