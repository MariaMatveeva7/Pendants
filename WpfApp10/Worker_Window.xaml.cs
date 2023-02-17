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
    /// Логика взаимодействия для Worker_Window.xaml
    /// </summary>
    public partial class Worker_Window : Window
    {
        AppContext db;
        public Worker_Window()
        {
            InitializeComponent();
            db = new AppContext();
            db.Products.Load();
            this.DataContext = db.Products.Local.ToBindingList();
        }

        private void Label_AddProduct_MouseDown_2(object sender, MouseButtonEventArgs e)
        {

            Add_Product_Window add_worker = new Add_Product_Window();
            add_worker.Show();
        }

        

        private void Label_Order_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Order_Worker_Window orw = new Order_Worker_Window();
            orw.Show();
            this.Close();
        }

        private void Delete_Click_1(object sender, RoutedEventArgs e)
        {
            if (product_list.SelectedItem == null) return;
            Product prod = product_list.SelectedItem as Product;
            db.Products.Remove(prod);
            MessageBox.Show("Товар удален!");
            db.SaveChanges();
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (product_list.SelectedItem == null) return;
            // получаем выделенный объект
            Product product = product_list.SelectedItem as Product;
            Redact_Product_Window cons = new Redact_Product_Window(new Product
            {
                id_product = product.id_product,
                Name = product.Name,
                Description = product.Description,
                Dimensions = product.Dimensions,
                Product_material = product.Product_material,
                Image_product = product.Image_product,
                Cost = product.Cost,
            });
            if (cons.ShowDialog() == true)
            {
                // получаем измененный объект
                product = db.Products.Find(cons.Product.id_product);
                if (product != null)
                {
                    product.Name = cons.Product.name;
                    product.Description = cons.Product.description;
                    product.Dimensions = cons.Product.dimensions;
                    product.Product_material = cons.Product.product_material;
                    product.Image_product = cons.Product.Image_product;
                    product.Cost = cons.Product.cost;

                    //db.Entry(contest).State = EntityState.Modified;
                    db.SaveChanges();
                    product_list.Items.Refresh();
                }
            }
        }

       

        

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Authorization_Window authwin = new Authorization_Window();
            authwin.Show();
            this.Close();
        }
    }
}
