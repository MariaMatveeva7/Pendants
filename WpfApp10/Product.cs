using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp10
{
    public class Product
    {
        [Key]
        public int id_product { get; set; }
        public string Name;
        public string Description;
        public string Dimensions;
        public string Product_material;
        public string Image_product { get; set; }
        public string Cost;
        public string name
        {
            get { return Name; }
            set
            {
                Name = value;
                OnPropertyChanged("name");
            }
        }

        public string description
        {
            get { return Description; }
            set 
            { 
                Description = value;
                OnPropertyChanged("description");
            }
        }
        public string cost
        {
            get { return Cost; }
            set 
            { 
                Cost = value;
                OnPropertyChanged("cost");

            }
        }
        public string dimensions
        {
            get { return Dimensions; }
            set
            {
                Dimensions = value;
                OnPropertyChanged("dimensions");
            }
        }
        public string product_material
        {
            get { return Product_material; }
            set 
            { 
                Product_material = value;
                OnPropertyChanged("product_material");
            }

        }
        //public string image_product
        //{
        //    get { return Image_product; }
        //    set 
        //    { 
        //        Image_product = value;
        //        OnPropertyChanged("image_product");
        //    }
        //}

        public Product() { }

        public Product(string Name, string Description, string Dimensions, string Product_material, string Image_product, string Cost)
        {
            this.Name = Name;
            this.Description = Description;
            this.Cost = Cost;
            this.Dimensions = Dimensions;
            this.Product_material = Product_material;
            this.Image_product = Image_product;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")

        {

            if (PropertyChanged != null)

                PropertyChanged(this, new PropertyChangedEventArgs(prop));

        }
    }

}
