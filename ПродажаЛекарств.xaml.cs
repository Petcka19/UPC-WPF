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
    /// Логика взаимодействия для ПродажаЛекарств.xaml
    /// </summary>
    public partial class ПродажаЛекарств : Page
    {
        public ПродажаЛекарств()
        {
            InitializeComponent();
            dgsklad.ItemsSource = entities.aptekasklad.GroupBy(p => p.kod_postup).SelectMany(g => g).ToList();
            aptekasklad = entities.aptekasklad.GroupBy(p => p.kod_postup).SelectMany(g => g).ToList();
        }
        UCHEEntities2 entities = new UCHEEntities2();
        List<aptekasklad> aptekasklad = new List<aptekasklad>();


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            add _add = new add(null);
            _add.ShowDialog();
            NavigationService.Refresh();
            dgsklad.SelectedItem = null;
            dgsklad.ItemsSource = entities.aptekasklad.GroupBy(p => p.kod_postup).SelectMany(g => g).ToList();

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedPost = dgsklad.SelectedItem as aptekasklad;
            add _add = new add(selectedPost);
            _add.ShowDialog();
            NavigationService.Refresh();
            dgsklad.SelectedItem = null;
            dgsklad.ItemsSource = entities.aptekasklad.GroupBy(p => p.kod_postup).SelectMany(g => g).ToList();
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedMedicine = dgsklad.SelectedItem as aptekasklad;
            var result = MessageBox.Show("Вы уверены, что хотите удалить?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                entities.aptekasklad.Remove(selectedMedicine);
                entities.SaveChanges();
                dgsklad.ItemsSource = entities.aptekasklad.GroupBy(p => p.kod_postup).SelectMany(g => g).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (text1.Text.Length != 0 && text2.Text.Length != 0)
            {
                int a = Convert.ToInt32(text1.Text);
                int b = Convert.ToInt32(text2.Text);
                aptekasklad = entities.aptekasklad.Where(p => p.value_drug>= a && p.value_drug <= b).GroupBy(p => p.kod_postup).SelectMany(g => g).ToList().ToList();
                dgsklad.ItemsSource = aptekasklad;

            }
            else if (text1.Text.Length == 0 && text2.Text.Length == 0)
            {
                aptekasklad = entities.aptekasklad.ToList();
                dgsklad.ItemsSource = aptekasklad;
            }
            else
            {
                MessageBox.Show("Заполните оба поля");
            }
        }
    }
}
