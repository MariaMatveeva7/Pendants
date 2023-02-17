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
    /// Логика взаимодействия для Order_Redact_Window.xaml
    /// </summary>
    public partial class Order_Redact_Window : Window
    {
        public Order Order { get; private set; }
        public Order_Redact_Window(Order order)
        {
            InitializeComponent();
            Order = order;
            this.DataContext = order;


        }

  
        private void ButtonRedactStatus_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
