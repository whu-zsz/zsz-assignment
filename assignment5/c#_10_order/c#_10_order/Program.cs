﻿using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace c__10_order
{
    public class Program
    {   
        public class EmptyException : Exception
        {
            private int code;
            //1->删除项不存在
            //2->修改项不存在
            //3->重复的添加项
            //4->查询项不存在
            public EmptyException() { }
            public EmptyException(string message,int code):base(message)
            {
                this.code = code;
            }
            public int Code { get => code; }
        }
        public class Order
        {   public Order(int ID,string NameOfGoods,string NameOfCustomer,double Money,OrderDetails others)
            {
                this.ID = ID;this.NameOfGoods = NameOfGoods;this.NameOfCustomer = NameOfCustomer;
                this.Money = Money;this.others = others;
            }
            public int ID{get;set;}//订单号
            public string NameOfGoods { get; set; }//商品名称
            public string NameOfCustomer { get; set; }//客户名称
            public double Money { get; set; } //总金额
            public OrderDetails others;
            public override bool Equals(object? obj)//重写equal
            {
                Order? tmp = obj as Order;
                return tmp != null && ID == tmp.ID && NameOfGoods == tmp.NameOfGoods
                    && NameOfCustomer == tmp.NameOfCustomer && Money == tmp.Money
                    && others.Equals(tmp.others);
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public override string ToString()
            {
                return "订单号为" + ID + ";" + "商品名称为" + NameOfGoods + ";" + "客户名称为" + NameOfCustomer + ";"
                    + "总金额为" + Money + ";" + others.ToString();
            }
        }
        public class OrderDetails
        {   public OrderDetails(int Numbers,double Price)
            {
                this.Numbers = Numbers;this.Price = Price;
                this.Time = DateTime.Now;
            } 
            public int Numbers { get; set; }//货物数量
            public double Price { get; set; }//单价
            public DateTime Time;//订单时间
            public override bool Equals(object? obj)//重写equal
            {
                OrderDetails? tmp = obj as OrderDetails;
                return tmp != null && Numbers == tmp.Numbers 
                    && Price == tmp.Price&&Time==tmp.Time;
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
            public override string ToString()
            {
                return "订单时间为" + Time+";"+"单价为"+Price+";"+"货物数量为"+Numbers+";";
            }
        }
        public class OrderService
        {
            public static List<Order> AllOrders = new List<Order>();
            public void SortOrder(List<Order>? Lists)//默认单参数id排序
            {
                if (Lists == null)
                    return;
                Lists.OrderBy(a => a.ID);
            }
            public void SortOrder(int type, ref List<Order>?Lists)//自定义排序

            {
                if (Lists == null)
                    return;
                switch (type)
                {
                    case 0://根据ID排序
                        {
                            Lists.OrderBy(a => a.ID);
                            break;
                        }
                    case 1://根据总金额排序
                        {
                            var list=Lists.OrderBy(a=>a.Money).ToList();
                            Lists = list;
                            break;
                        }
                }
                    
             }
            public void AddOrder(string NameOfGoods, string NameOfCustomer, int Numbers, double Price)//添加order
            {
                try
                {
                    OrderDetails others = new OrderDetails(Numbers, Price);
                    foreach (var tmp in AllOrders)
                    {
                        if (tmp!=null&&tmp.others.Equals(others))
                            throw new EmptyException("重复的订单明细", 3);
                    }
                    int ID = (AllOrders == null) ? 0 : AllOrders.Count();
                    Order order = new Order(ID, NameOfGoods, NameOfCustomer, (double)Numbers * Price, others);
                    foreach (var tmp in AllOrders)
                    {
                        if (tmp != null && tmp.Equals(order))
                            throw new EmptyException("重复的订单信息", 3);
                    }
                    AllOrders.Add(order);
                }
                catch (EmptyException e)
                {
                    Console.WriteLine("错误的添加,具体错误：", e.Message,"错误代码：",e.Code);
                }
                Console.WriteLine("添加成功");
            }
            public void DelOrders(int ID)//根据id删除订单
            {
                try
                {
                    foreach (var tmp in AllOrders)
                    {
                        if (tmp != null && tmp.ID == ID)
                        {
                            AllOrders.Remove(tmp);
                            Console.WriteLine("删除成功");
                            return;
                        }
                    }
                    throw new EmptyException("无法找到删除项", 1);
                 }
                catch (EmptyException e)
                {
                    Console.WriteLine("错误的删除,具体错误：", e.Message, "错误代码：", e.Code);
                }               
            }
            public void ModOrders(int ID, object message,int type)//修改订单
            {
                //type仅限于购买数量和客户的修改，修改数量自动修改总金额
                try
                {
                    switch (type) 
                    {
                        case 0://修改数量
                            {
                                int NewNumbers = (int)message;                               
                                foreach(var tmp in AllOrders)
                                {
                                    if (tmp != null && tmp.ID == ID)
                                    { 
                                        tmp.others.Numbers = NewNumbers;
                                        tmp.Money = tmp.others.Price * tmp.others.Numbers;
                                        Console.WriteLine("修改成功");
                                        return; 
                                    }
                                }
                                throw new EmptyException("未找到修改选项", 2);                                
                            }
                        case 1://修改客户名
                            {
                                string NewNameOfCustomer = (string)message;
                                foreach(var tmp in AllOrders)
                                {
                                    if (tmp != null && tmp.ID == ID)
                                    {
                                        tmp.NameOfCustomer = NewNameOfCustomer;
                                        Console.WriteLine("修改成功");
                                        return;
                                    }
                                }
                                break;
                            }
                        default:
                            {
                                throw new EmptyException("修改类别错误", 2);
                            }
                    }
                }
                catch (EmptyException e)
                {
                    Console.WriteLine("错误的修改,具体错误：", e.Message, "错误代码：", e.Code);
                }
            }
            public bool CheckOrders(int type, object message)//查询订单
            {
                List<Order> OutList = new List<Order>();
                try
                {                    
                    switch (type)
                    {
                        case 0://根据ID查询
                            {
                                int ID = (int)message;
                                OutList = (from tmp in AllOrders
                                           where tmp.ID == ID
                                           select tmp).ToList();
                                break;
                            }

                        case 1://根据货物名查询
                            {
                                string NameOfGoods = (string)message;
                                OutList = (from tmp in AllOrders
                                           where tmp.NameOfGoods == NameOfGoods
                                           select tmp).ToList();
                                break;
                            }
                        case 2://根据客户名查询
                            {
                                string NameOfCustomer = (string)message;
                                OutList = (from tmp in AllOrders
                                           where tmp.NameOfCustomer == NameOfCustomer
                                           select tmp).ToList();
                                break;
                            }
                    }
                    if (OutList == null)
                    {
                        throw new EmptyException("未查到目标项", 4);
                    }
                }
                catch(EmptyException e)
                {
                    Console.WriteLine("错误的查询,具体错误：", e.Message, "错误代码：", e.Code);
                }
                SortOrder(1, ref OutList);
                foreach(var tmp in OutList)
                {
                    Console.WriteLine(tmp);
                    Console.WriteLine();
                }
                return true;
            }
        }

        static void Main(string[] args)
        {
            
        }
    }
}
