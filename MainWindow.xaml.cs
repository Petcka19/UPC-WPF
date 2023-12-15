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

namespace УП
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new System.Uri("Лекарства.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new System.Uri("Поставщики.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FrameWithinGrid.Navigate(new System.Uri("ПродажаЛекарств.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            proc3 a = new proc3();
            a.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            proc2 a = new proc2();
            a.Show();
        }


        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            proc1 a = new proc1();
            a.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            proc4 a = new proc4();
            a.Show();
        }
    }
}
