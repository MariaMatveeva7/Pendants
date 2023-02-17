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

namespace WpfApp10
{
    /// <summary>
    /// Логика взаимодействия для Selected_Product_Window.xaml
    /// </summary>
    public partial class Selected_Product_Window : Window
    {
        public Product Product { get; private set; }
        public Selected_Product_Window(Product product)
        {
            InitializeComponent();
            Product = product;
            this.DataContext = product;

        }

        private void Korzina_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
