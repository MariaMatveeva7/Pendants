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
    /// Логика взаимодействия для Add_Product_Window.xaml
    /// </summary>
    public partial class Add_Product_Window : Window
    {
        AppContext db;
        public Add_Product_Window()
        {
            InitializeComponent();
            db = new AppContext();
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {

            string Name = TextName.Text.Trim();
            string Description = TextDescription.Text.Trim();
            string Cost = TextCost.Text.Trim();
            string Dimensions = TextDemintions.Text.Trim();
            string Product_material = TextMaterial.Text.Trim();
            string Image_product = TextImage.Text.Trim();
            if (Name.Length < 5)
            {
                MessageBox.Show("Это поле введено не корректно!");
                TextName.Background = Brushes.MistyRose;
            }
            else if (Description.Length < 6)
            {
                MessageBox.Show("Это поле введено не корректно!");
                TextDescription.Background = Brushes.MistyRose;
            }

            else if (Dimensions.Length < 5)
            {
                MessageBox.Show("Это поле введено не корректно!");
                TextDemintions.Background = Brushes.MistyRose;
            }
            else if (Product_material.Length < 5)
            {
                MessageBox.Show("Это поле введено не корректно!");
                TextMaterial.Background = Brushes.MistyRose;
            }

            else
            {
                TextName.ToolTip = "";
                TextName.Background = Brushes.Transparent;
                TextDescription.ToolTip = "";
                TextDescription.Background = Brushes.Transparent;
                TextCost.ToolTip = "";
                TextCost.Background = Brushes.Transparent;
                TextMaterial.ToolTip = "";
                TextMaterial.Background = Brushes.Transparent;
                TextDemintions.ToolTip = "";
                TextDemintions.Background = Brushes.Transparent;
                TextImage.ToolTip = "";
                TextImage.Background = Brushes.Transparent;


                Product prod = new Product(Name, Description, Dimensions, Product_material, Image_product, Cost);
                db.Products.Add(prod);
                db.SaveChanges();
                MessageBox.Show("Вы успешно добавили товар!");
                this.Close();



            }
        }
    }
}
