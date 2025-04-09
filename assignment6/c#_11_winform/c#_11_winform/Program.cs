using MySql.Data.MySqlClient;

namespace c__11_winform
{
    public  class Program
    {
        
        public class EmptyException : Exception
        {
            private int code;
        //1->ɾ�������
        //2->�޸������
        //3->�ظ��������
        //4->��ѯ�����
        public EmptyException() { }
        public EmptyException(string message, int code) : base(message)
        {
            this.code = code;
        }
        public int Code { get => code; }
    }
        /*
        public class Order
    {
        public Order(int ID, string NameOfGoods, string NameOfCustomer, double Money, OrderDetails others)
        {
            this.ID = ID; this.NameOfGoods = NameOfGoods; this.NameOfCustomer = NameOfCustomer;
            this.Money = Money; this.others = others;
        }
        public int ID { get; set; }//������
        public string NameOfGoods { get; set; }//��Ʒ����
        public string NameOfCustomer { get; set; }//�ͻ�����
        public double Money { get; set; } //�ܽ��
        public OrderDetails others;
        public override bool Equals(object? obj)//��дequal
        {
            Order? tmp = obj as Order;
            return tmp != null  && NameOfGoods == tmp.NameOfGoods
                && NameOfCustomer == tmp.NameOfCustomer && Money == tmp.Money
                && others.Equals(tmp.others);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "������Ϊ" + ID + ";" + "��Ʒ����Ϊ" + NameOfGoods + ";" + "�ͻ�����Ϊ" + NameOfCustomer + ";"
                + "�ܽ��Ϊ" + Money + ";" + others.ToString();
        }
    }
        public class OrderDetails
    {
        public OrderDetails(int Numbers, double Price)
        {
            this.Numbers = Numbers; this.Price = Price;
            this.Time = DateTime.Now;
        }
        public int Numbers { get; set; }//��������
        public double Price { get; set; }//����
        public DateTime Time;//����ʱ��
        public override bool Equals(object? obj)//��дequal
        {
            OrderDetails? tmp = obj as OrderDetails;
            return tmp != null && Numbers == tmp.Numbers
                && Price == tmp.Price ;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "����ʱ��Ϊ" + Time + ";" + "����Ϊ" + Price + ";" + "��������Ϊ" + Numbers + ";";
        }
    }
       
        public class OrderService
    {
        public static List<Order> AllOrders = new List<Order>();
        public void SortOrder(List<Order>? Lists)//Ĭ�ϵ�����id����
        {
            if (Lists == null)
                return;
            Lists.OrderBy(a => a.ID);
        }
        public void SortOrder(int type, ref List<Order>? Lists)//�Զ�������

        {
            if (Lists == null)
                return;
            switch (type)
            {
                case 0://����ID����
                    {
                        Lists.OrderBy(a => a.ID);
                        break;
                    }
                case 1://�����ܽ������
                    {
                        var list = Lists.OrderBy(a => a.Money).ToList();
                        Lists = list;
                        break;
                    }
            }

        }
        public static bool AddOrder(string NameOfGoods, string NameOfCustomer, int Numbers, double Price)//���order
            { 
                string sql = "SELECT COUNT(*) FROM myorder";
                using (MySqlConnection connection = GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    int totalCount = Convert.ToInt32(command.ExecuteScalar());
                    using (MySqlCommand cmd = new MySqlCommand
                    ("INSERT INTO stu(idstu,price,number) VALUES(@idstu,@price,@number)", connection))
                    {
                        cmd.Parameters.AddWithValue("@idstu", "1");
                        cmd.Parameters.AddWithValue("@price", "23");
                        cmd.Parameters.AddWithValue("@number", "12");
                        cmd.ExecuteNonQuery();
                    }

                }
                return true;
        }
        public bool DelOrders(int ID)//����idɾ������
        {
           
                foreach (var tmp in AllOrders)
                {
                    if (tmp != null && tmp.ID == ID)
                    {
                        AllOrders.Remove(tmp);                        
                        return true;
                    }
                }
                return false;
            }                  
        public bool ModOrders(int ID, object message, int type)//�޸Ķ���
        {
            //type�����ڹ��������Ϳͻ����޸ģ��޸������Զ��޸��ܽ��            
                switch (type)
                {
                    case 0://�޸�����
                        {
                            int NewNumbers = (int.TryParse((string)message,out NewNumbers))?
                                Convert.ToInt32(message):-1;
                            foreach (var tmp in AllOrders)
                            {
                                if (tmp != null && tmp.ID == ID)
                                {
                                    tmp.others.Numbers = NewNumbers;
                                    tmp.Money = tmp.others.Price * tmp.others.Numbers;
                                    return true;
                                }
                            }
                            return false;
                        }
                    case 1://�޸Ŀͻ���
                        {
                            string NewNameOfCustomer = (string)message;
                            foreach (var tmp in AllOrders)
                            {
                                if (tmp != null && tmp.ID == ID)
                                {
                                    tmp.NameOfCustomer = NewNameOfCustomer;
                                    return true;
                                }
                            }
                            return false;
                        }
                    default:
                        {
                            return false;
                        }
                }
            }                   
        public Order? CheckOrders(int type, object message)//��ѯ����
        {
            List<Order> OutList = new List<Order>();            
                switch (type)
                {
                    case 0://����ID��ѯ
                        {
                            int ID = int.TryParse((string)message, out ID) ? Convert.ToInt32(message) : -1; ;
                            OutList = (from tmp in AllOrders
                                       where tmp.ID == ID
                                       select tmp).ToList();
                            break;
                        }

                    case 1://���ݻ�������ѯ
                        {
                            string NameOfGoods = (string)message;
                            OutList = (from tmp in AllOrders
                                       where tmp.NameOfGoods == NameOfGoods
                                       select tmp).ToList();
                            break;
                        }
                    case 2://���ݿͻ�����ѯ
                        {
                            string NameOfCustomer = (string)message;
                            OutList = (from tmp in AllOrders
                                       where tmp.NameOfCustomer == NameOfCustomer
                                       select tmp).ToList();
                            break;
                        }
                }
            SortOrder(1, ref OutList);            
            return OutList.Count==0?null:OutList[0];
        }
        }
       */
        public class order
        {
            public int ID { get; set; }
            public string NameOfCustomer { get; set; }
            public string NameOfGoods { get; set; }
            public double price { get; set; }
            public int number { get; set; }
            public double money { get; set; }
            public DateTime time { get; set; }
        }
        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(
                "datasource=127.0.0.1;username=root;password=zsz050124;database=testdb;charset=utf8"
                );
            connection.Open();
            return connection;
        }
        public class orderservice
        {
            public static void sortorder(string tableName)//�Զ����������ʵ�deepseek
            {
                using (MySqlConnection connection = GetConnection())
                {
                    var disableFkCmd = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 0;", connection);
                    disableFkCmd.ExecuteNonQuery();
                    // 1. ��ȡ���з�ID����
                    var columnsCmd = new MySqlCommand(
                    $"SELECT GROUP_CONCAT(COLUMN_NAME) FROM INFORMATION_SCHEMA.COLUMNS " +
                    $"WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = '{tableName}' AND COLUMN_NAME != 'id';",
                    connection);
                    string columns = columnsCmd.ExecuteScalar()?.ToString();

                    if (string.IsNullOrEmpty(columns))
                    {
                        Console.WriteLine("����û�������л��Ҳ�������Ϣ");
                        return;
                    }

                    // 2. ������ʱ��洢���ݣ�������id��
                    var createTempCmd = new MySqlCommand(
                        $"CREATE TEMPORARY TABLE temp_{tableName} AS SELECT {columns} FROM {tableName};",
                        connection);
                    createTempCmd.ExecuteNonQuery();

                    // 3. ���ԭ��
                    var truncateCmd = new MySqlCommand($"TRUNCATE TABLE {tableName};", connection);
                    truncateCmd.ExecuteNonQuery();

                    // 4. ���²������ݣ���MySQL�Զ�������id��
                    var reinsertCmd = new MySqlCommand(
                        $"INSERT INTO {tableName} ({columns}) SELECT {columns} FROM temp_{tableName};",
                        connection);
                    reinsertCmd.ExecuteNonQuery();

                    // 5. ��ȡ��ǰ���IDֵ
                    var maxIdCmd = new MySqlCommand($"SELECT MAX(id) FROM {tableName};", connection);
                    int maxId = Convert.ToInt32(maxIdCmd.ExecuteScalar());

                    // 6. ��������ֵ��������ķ�����
                    var resetAutoIncCmd = new MySqlCommand(
                        $"ALTER TABLE {tableName} AUTO_INCREMENT = {maxId + 1};",
                        connection);
                    resetAutoIncCmd.ExecuteNonQuery();

                    // 7. ɾ����ʱ��
                    var dropTempCmd = new MySqlCommand($"DROP TEMPORARY TABLE temp_{tableName};", connection);
                    dropTempCmd.ExecuteNonQuery();

                    var enableFkCmd = new MySqlCommand("SET FOREIGN_KEY_CHECKS = 1;", connection);
                    enableFkCmd.ExecuteNonQuery();
                }
            }
            public static void addorder(string NameOfGoods, string NameOfCustomer, int Numbers, double Price)
            {
                string sql = "SELECT COUNT(*) FROM myorder";
                using (MySqlConnection connection = GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    int totalCount = Convert.ToInt32(command.ExecuteScalar());

                    string id = (totalCount + 1).ToString();
                    string number = Numbers.ToString(); string price = Price.ToString();
                    string money = (Numbers * Price).ToString();
                    string time = DateTime.Now.ToString();

                    using (MySqlCommand cmd = new MySqlCommand
                    ("INSERT INTO myorder(ID,NameOfCustomer,NameOfGoods,price,number,money,time) " +
                    "VALUES(@ID,@NameOfCustomer,@NameOfGoods,@price,@number,@money,@time)", connection))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@NameOfCustomer", NameOfCustomer);
                        cmd.Parameters.AddWithValue("@NameOfGoods", NameOfGoods);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@number", number);
                        cmd.Parameters.AddWithValue("@money", money);
                        cmd.Parameters.AddWithValue("@time", time);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            public static bool deleteorder(int ID)
            {
                string sql = "SELECT COUNT(*) FROM myorder";
                using (MySqlConnection connection = GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    int totalCount = Convert.ToInt32(command.ExecuteScalar());
                    if (ID > totalCount) return false;
                    using (MySqlCommand cmd = new MySqlCommand
                   ("delete from myorder where ID= 1", connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                sortorder("myorder");
                return true;
            }
            public static order checkorder(int ID)
            {
                
                string sql = "SELECT * FROM myorder WHERE ID = @id";

                using (MySqlConnection connection = GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", ID.ToString());


                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new order
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                NameOfCustomer = reader["NameOfCustomer"].ToString(),
                                NameOfGoods = reader["NameOfGoods"].ToString(),
                                price = Convert.ToDouble(reader["price"]),
                                number = Convert.ToInt32(reader["number"]),
                                money = Convert.ToDouble(reader["money"]),
                                time = Convert.ToDateTime(reader["time"])
                            };
                        }
                    }
                }
                return null;
            }
            public static bool modorder(int ID, int type, string message)
            {
                string sql1 = @"UPDATE myorder 
                  SET number=@number,
                      money=@money
                  WHERE ID = @id";
                string sql2 = @"UPDATE myorder 
                  SET  NameOfCustomer=@NameOfCustomer
                  WHERE ID = @id";
                string sql = (type == 0) ? sql1 : sql2;
                using (MySqlConnection connection = GetConnection())
                {
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", ID.ToString());
                    if (type == 0)
                    {
                        double price = 0;
                        MySqlCommand command1 = new MySqlCommand("SELECT * FROM myorder WHERE ID = @id", connection);
                        command1.Parameters.AddWithValue("@id", ID.ToString());
                        using (MySqlDataReader reader = command1.ExecuteReader())
                        {
                            if (reader.Read())
                                price = Convert.ToDouble(reader["price"]);
                        }
                        int Number = int.TryParse(message, out Number)? Convert.ToInt32(message) : -1;
                        if (Number == -1) return false;
                        string money = (price * Number).ToString();
                        command.Parameters.AddWithValue("@number", message);
                        command.Parameters.AddWithValue("@money", money);
                    }
                    else command.Parameters.AddWithValue("@NameOfCustomer", message);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }

            }
        }
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}