using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static c__11_winform.Program;

namespace c__11_winform
{
    public partial class Form3 : Form
    {
        OrderService orders3 = new OrderService();
        public Form3()
        {
            InitializeComponent();
            comboBox1.Items.Add("商品数量");
            comboBox1.Items.Add("客户名称");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int type = comboBox1.Text == "商品数量" ? 0 : 1;
            int ID = int.TryParse(textBox1.Text, out ID) ? Convert.ToInt32(textBox1.Text) : -1;
            if (ID == -1)
            { MessageBox.Show("请输入正确形式ID"); return; }
            if (orders3.ModOrders(ID, textBox2.Text, type))
            { MessageBox.Show("成功完成修改"); return; }
            else MessageBox.Show("修改失败");

        }
    }
}
