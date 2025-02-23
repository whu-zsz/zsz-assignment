namespace c__2_caculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         
        double Num_A, Num_B; string symbol; string result;

        private void button1_Click(object sender, EventArgs e)
        {
            switch(symbol)
            {
                case ("+"):
                    result = (Num_A + Num_B).ToString();
                    break;
                case ("-"):
                    result = (Num_A - Num_B).ToString();
                    break;
                case ("*"):
                    result = (Num_A * Num_B).ToString();
                    break;
                case ("/"):
                    if (Num_B == 0) result = "error";
                    else result = (Num_A / Num_B).ToString();
                    break;
                default:
                    result = "error";
                    break;
            }
            Result.Text = result;

        }

        private void NumA_TextChanged(object sender, EventArgs e)
        {
             Num_A = double.Parse(NumA.Text);
        }

        private void Symbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            symbol = Symbol.Text;
        }

        private void NumB_TextChanged(object sender, EventArgs e)
        {
            Num_B = double.Parse(NumB.Text);
        }
    }
}
