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
    /// Логика взаимодействия для add.xaml
    /// </summary>
    public partial class add : Window
    {
        UCHEEntities2 entities = new UCHEEntities2();
        List<aptekasklad> aptekasklad = new List<aptekasklad>();
        aptekasklad _sklad;
        List<apteka> apteka = new List<apteka>();
        List<aptekapost> aptekapost = new List<aptekapost>();
        bool a = false;
        public add(aptekasklad sk)
        {
            InitializeComponent();

            aptekasklad = entities.aptekasklad.ToList();
            apteka = entities.apteka.ToList();
            aptekapost = entities.aptekapost.ToList();
            cb2.ItemsSource = entities.apteka.ToList();
            cb1.ItemsSource = entities.aptekapost.ToList();
            if (sk == null)
            {
                a = true;
            }
            else
            {
                a = false;
                _sklad = sk;
                DataContext = sk;
                int idt = Convert.ToInt32(aptekasklad.Where(g => g.Code_drug == sk.Code_drug).Select(f => f.Code_drug).FirstOrDefault());
                cb2.Text = apteka.Where(f => f.Code_drug == idt).Select(f => f.Name_drug).FirstOrDefault().ToString();
                int idC = Convert.ToInt32(aptekasklad.Where(g => g.kod_post == sk.kod_post).Select(f => f.kod_post).FirstOrDefault());
                cb1.Text = aptekapost.Where(f => f.Code_post == idC).Select(f => f.Short_name).FirstOrDefault().ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (a)
            {
                try
                {
                    aptekasklad r = new aptekasklad();
                    entities.aptekasklad.Add(r);
                    r.data_post = Convert.ToDateTime(tb1.Text);
                    var code_a = cb1.SelectedValue as aptekapost;
                    r.kod_post = code_a.Code_post;
                    r.cost = (decimal?)Convert.ToDouble(tb2.Text.Replace(".", ","));
                    var code_p = cb2.SelectedValue as apteka;
                    r.Code_drug = code_p.Code_drug;
                    r.value_drug = Convert.ToInt32(tb3.Text);
                    entities.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                try
                {
                    var r = entities.aptekasklad.Where(c => c.kod_postup == _sklad.kod_postup).FirstOrDefault();
                    r.data_post = Convert.ToDateTime(tb1.Text);
                    var code_a = cb1.SelectedValue as aptekapost;
                    r.kod_post = code_a.Code_post;
                    r.cost = Convert.ToDecimal(tb2.Text.Replace(".", ","));
                    var code_p = cb2.SelectedValue as apteka;
                    r.Code_drug = code_p.Code_drug;
                    r.value_drug = Convert.ToInt32(tb3.Text);
                    entities.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
