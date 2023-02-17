using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp10
{
    public class Order
    {
        [Key]
        public int id_order { get; set; }
        public int id_backet { get; set; }
        public int id_user { get; set; }
        public string Address;
        public string Delivery_time;
        public string Payment_method;
        public string Status_order;
       
        public string address
        {
            get { return Address; }
            set
            {
                Address = value;
                OnPropertyChanged("address");
            }
        }

        public string delivery_time
        {
            get { return Delivery_time; }
            set
            {
                Delivery_time = value;
                OnPropertyChanged("delivery_time");
            }
        }
        public string payment_method
        {
            get { return Payment_method; }
            set
            {
                Payment_method = value;
                OnPropertyChanged("payment_method");

            }
        }
        public string status_order
        {
            get { return Status_order; }
            set
            {
                Status_order = value;
                OnPropertyChanged("status_order");
            }
        }
       

        public Order() { }

        public Order(int id_order, int id_backet, int id_user, string Address, string Delivery_time, string Payment_method, string Status_order)
        {
            this.id_order = id_order;
            this.id_backet = id_backet;
            this.id_user = id_user;
            this.Address = Address;
            this.Delivery_time = Delivery_time;
            this.Payment_method = Payment_method;
            this.Status_order = Status_order;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")

        {

            if (PropertyChanged != null)

                PropertyChanged(this, new PropertyChangedEventArgs(prop));

        }
    }

}
