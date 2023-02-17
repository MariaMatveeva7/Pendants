using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Admin_Window.xaml
    /// </summary>
    public partial class Admin_Window : Window
    {
        AppContext db;
        public Admin_Window()
        {
            InitializeComponent();
            db = new AppContext();
            db.Products.Load();
            this.DataContext = db.Products.Local.ToBindingList();

            //AppContext db = new AppContext();
            //List<Product> prod = db.Products.ToList();
            //product_list.ItemsSource = prod;

        }

        private void Label_AddWorker_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Add_Worker_Window add_worker = new Add_Worker_Window();
            add_worker.Show();
        }

        private void Label_Order_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Order_Status_Window order = new Order_Status_Window();
            order.Show();
            this.Close();
        }

        private void Label_RemoveWorker_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            Delete_Worker_Window dlt = new Delete_Worker_Window();
            dlt.Show();
            
        }

        private void Label_User_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            User_List_Window usw = new User_List_Window();
            usw.Show();
            this.Close();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Authorization_Window authwin = new Authorization_Window();
            authwin.Show();
            this.Close();
        }

        

        //private void Delete_Click_1(object sender, RoutedEventArgs e)
        //{
        //    if (product_list.SelectedItem == null) return;
        //    Product prod = product_list.SelectedItem as Product;
        //    db.Products.Remove(prod);
        //    MessageBox.Show("Товар удален!");
        //    db.SaveChanges();
        //}
    }
}
