using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WindowsFormsApp1.Program;

namespace WindowsFormsApp1
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            bindingSource1.DataSource = orderservice.check();
            comboBox1.SelectedIndex = 0;
        }
        public void QueryAll()
        {
            bindingSource1.DataSource = orderservice.check();
            bindingSource1.ResetBindings(false);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            order delorder = bindingSource1.Current as order;
            if (delorder == null)
            {
                MessageBox.Show("请选择一个订单");
                return;
                    }
            else
            {
                orderservice.deleteorders(delorder.ID);
                QueryAll();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 addform = new Form2(bindingSource1.Current as order, true);
            addform.ShowDialog();
            QueryAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            { MessageBox.Show("请选择一个订单"); return; }
            Form2 modform = new Form2(bindingSource1.Current as order, false);
            modform.ShowDialog();
            QueryAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0://所有订单
                    {
                        bindingSource1.DataSource = orderservice.check();
                        break;
                    }
                case 1://按照ID
                    {
                        bindingSource1.DataSource = orderservice.checkorders_id(textBox1.Text);
                        break;
                    }
                case 2://按照货物名
                    {
                        bindingSource1.DataSource = orderservice.checkorderss_nameofgoods(textBox1.Text);
                        break;
                    }
                case 3://按照客户名
                    {
                        bindingSource1.DataSource = orderservice.checkorderss_nameofcustomer(textBox1.Text);
                        break;
                    }
                case 4://按照金额大于
                    {
                        double money = double.TryParse(textBox1.Text, out money)
                               ? Convert.ToInt32(textBox1.Text) : -1;
                        if (money == -1) { MessageBox.Show("请输入正确的数字形式"); return; }
                        bindingSource1.DataSource = orderservice.checkorderss_moneybigger(money);
                        break;
                    }
                    
            }
            bindingSource1.ResetBindings(false);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (bindingSource1.Current == null)
            { MessageBox.Show("请选择一个订单"); return; }
            Form2 modform = new Form2(bindingSource1.Current as order, false);
            modform.ShowDialog();
            QueryAll();
        }
    }
}
