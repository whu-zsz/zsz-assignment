namespace c__11_winform
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
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
        public bool AddOrder(string NameOfGoods, string NameOfCustomer, int Numbers, double Price)//���order
        {
                OrderDetails others = new OrderDetails(Numbers, Price);
                foreach (var tmp in AllOrders)
                {
                    if (tmp != null && tmp.others.Equals(others))
                        return false; 
                }
                int ID = (AllOrders == null) ? 0 : AllOrders.Count();
                Order order = new Order(ID, NameOfGoods, NameOfCustomer, (double)Numbers * Price, others);
                foreach (var tmp in AllOrders)
                {
                    if (tmp != null && tmp.Equals(order))
                        return false;
                }
                AllOrders.Add(order);
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