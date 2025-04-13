using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Program;

namespace WindowsFormsApp1
{
    public partial class Form2: Form
    {
        bool addormod;
        order currents;
        public Form2(order current, bool addormod)
        {
            InitializeComponent();
            if(!addormod)//修改状态
            {
                textBox1.Text = current.NameOfGoods;
                textBox2.Text = current.number.ToString();
                textBox3.Text = current.NameOfCustomer;
                textBox4.Text = current.price.ToString();
                textBox5.Text = current.ID;
                this.addormod = addormod;
                currents = current;
            }
            else //添加状态
            {
                textBox5.Visible = false;
                label5.Visible = false;
                this.addormod = addormod;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameofcustomer = textBox3.Text;
            string nameofgoods = textBox1.Text;
            int number = int.TryParse(textBox2.Text, out number)
            ? Convert.ToInt32(textBox2.Text) : -1;
            double price = double.TryParse(textBox4.Text, out price)
            ? Convert.ToInt32(textBox4.Text) : -1;
            if (number <= 0 || price <= 0)
            {
                MessageBox.Show("单价或数量格式错误");
            }
            order neworder = new order
            {
                NameOfCustomer = nameofcustomer,
                NameOfGoods = nameofgoods,
                number = number,
                price = price,
                money = number * price
            };
            if (!addormod)//修改状态
            {                  
                orderservice.deleteorders(currents.ID);
                orderservice.addorders(neworder);
                MessageBox.Show("修改订单完成");
                Close();
            }
            else
            {
                orderservice.addorders(neworder);
                MessageBox.Show("添加订单完成");
                Close();
            }
        }
    }
}
