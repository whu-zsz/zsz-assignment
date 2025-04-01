using System.Windows.Forms;
using static c__11_winform.Program;

namespace c__11_winform
{
    public partial class Form1 : Form
    {
        OrderService orders = new OrderService();
        public Form1()
        {
            InitializeComponent();
            comboBox2.Items.Add("ID");
            comboBox2.Items.Add("货物名");
            label5.Text = "";//nameofcustomer
            label6.Text = "";//nameofgoods
            label7.Text = "";//id
            label11.Text = "";//price
            label12.Text = "";//number
            label13.Text = "";//money
            label15.Text = "";//time
            orders.AddOrder("apple", "me", 21, 2.5);
        }
        
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            
            f2.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ID = int.TryParse(textBox1.Text, out ID) ? Convert.ToInt32(textBox1.Text) : -1;
            if(orders.DelOrders(ID))
                MessageBox.Show("已删除目标订单");
            else MessageBox.Show("目标订单不存在");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int type = comboBox2.Text == "ID" ? 0 : 1;
            Program.Order? tmp=orders.CheckOrders(type, textBox2.Text);
            if (tmp == null)
                MessageBox.Show("未查到目标订单");
            else
            {
                label5.Text = tmp.NameOfCustomer;//nameofcustomer
                label6.Text = tmp.NameOfGoods;//nameofgoods
                label7.Text = tmp.ID.ToString();//id
                label11.Text = tmp.others.Price.ToString();//price
                label12.Text = tmp.others.Numbers.ToString();//number
                label13.Text = tmp.Money.ToString();//money
                label15.Text = tmp.others.Time.ToString();//time
                MessageBox.Show("完成查询");
            }
        }
    }
}
