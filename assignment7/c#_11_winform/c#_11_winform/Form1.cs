using System.Windows.Forms;
using static c__11_winform.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace c__11_winform
{
    public partial class Form1 : Form
    {
        //OrderService orders = new OrderService();
        public Form1()
        {
            InitializeComponent();
            label5.Text = "";//nameofcustomer
            label6.Text = "";//nameofgoods
            label7.Text = "";//id
            label11.Text = "";//price
            label12.Text = "";//number
            label13.Text = "";//money
            label15.Text = "";//time
            //orders.AddOrder("apple", "me", 21, 2.5);
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
            if(orderservice.deleteorder(ID))
                MessageBox.Show("已删除目标订单");
            else MessageBox.Show("目标订单不存在");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ID = int.TryParse(textBox2.Text, out ID)
                ? Convert.ToInt32(textBox2.Text) : -1;
            order tmp = orderservice.checkorder(ID);
            if (tmp == null)
                MessageBox.Show("未查到目标订单");
            else
            {
                label5.Text = tmp.NameOfCustomer;//nameofcustomer
                label6.Text = tmp.NameOfGoods;//nameofgoods
                label7.Text = tmp.ID.ToString();//id
                label11.Text = tmp.price.ToString();//price
                label12.Text = tmp.number.ToString();//number
                label13.Text = tmp.money.ToString();//money
                label15.Text = tmp.time.ToString();//time
                MessageBox.Show("完成查询");
            }
        }
    }
}
