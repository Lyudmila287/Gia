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

namespace WpfApp19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            update();
        }
        public void update()
        {
            var list = App.DB.product.ToList();
            listView.ItemsSource = list;        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            product prd1 = new product
            {
                name = textBox.Text,
                data = textBox1.Text,
                id_category = Convert.ToInt32(textBox2.Text)
            };
            App.DB.product.Add(prd1);
            App.DB.SaveChanges();
            update();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button1 = (Button)sender;
            product prod1 = (product)button1.DataContext;
            App.DB.product.Remove(prod1);
            App.DB.SaveChanges();
            update();
            MessageBox.Show($"Удален объект {prod1.name}");
        }
    }
}
