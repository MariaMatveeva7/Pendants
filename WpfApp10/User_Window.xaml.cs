using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для User_Window.xaml
    /// </summary>
    public partial class User_Window : Window
    {
        AppContext db;
        public User_Window()
        {
            InitializeComponent();
            db = new AppContext();
            db.Products.Load();
            this.DataContext = db.Products.Local.ToBindingList();
        }

        private void Label_Info_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }



        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Authorization_Window authwin = new Authorization_Window();
            authwin.Show();
            this.Close();
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (catalog_list.SelectedItem == null) return;
            // получаем выделенный объект
            Product product = catalog_list.SelectedItem as Product;
            Selected_Product_Window cons = new Selected_Product_Window(new Product
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
                    catalog_list.Items.Refresh();
                }
            }
        }
    }

}