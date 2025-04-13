using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class Program
    {
        public class order
        {
            public string ID { get; set; }
            public string NameOfCustomer { get; set; }
            public string NameOfGoods { get; set; }
            public double price { get; set; }
            public int number { get; set; }
            public double money { get; set; }
            public DateTime time { get; set; }

            public order()
            {
               ID = Guid.NewGuid().ToString();
                time = DateTime.Now;
            }
        }
        public class ordercontext : DbContext
        {
        public ordercontext():base("myorder")
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ordercontext>());
            }        
        public DbSet<order> myorder { get; set; }
        
        }
        public class orderservice
        {
            public static void addorders(order order_0)
            {
                using (var db = new ordercontext())
                {
                    db.myorder.Add(order_0);
                    db.SaveChanges();
                }
            }
            public static void deleteorders(string id)
            {
                using (var db = new ordercontext())
                {
                    var order = db.myorder.SingleOrDefault(o => o.ID == id);
                    if (order == null) return;
                    db.myorder.Remove(order);
                    db.SaveChanges();
                }
            }
            public static order checkorders_id(string id)
            {
                using (var db = new ordercontext())
                {
                    var order = db.myorder.SingleOrDefault(o => o.ID == id);
                    if (order == null) return null;
                    else return order;

                }
            }
            public static List<order> checkorderss_nameofcustomer(string nameofcustomer)
            {
                using (var db = new ordercontext())
                {
                    var order = (from orders in db.myorder where orders.NameOfCustomer ==
                               nameofcustomer select orders).ToList();
                    return order;
                }
            }
            public static List<order> checkorderss_nameofgoods(string nameofgoods)
            {
                using (var db = new ordercontext())
                {
                    var order = (from orders in db.myorder
                                 where orders.NameOfGoods ==
                               nameofgoods
                                 select orders).ToList();
                    return order;
                }
            }
            public static List<order> checkorderss_moneybigger(double money)
            {
                using (var db = new ordercontext())
                {
                    var order = (from orders in db.myorder
                                 where orders.money >money
                                 select orders).ToList();
                    return order;
                }
            }
            public static List<order> check()
            {
                using (var db = new ordercontext())
                {
                    return db.myorder.ToList();
                }
            }
        }
       
                [STAThread]
            static void Main()
            {
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        
    }
}
