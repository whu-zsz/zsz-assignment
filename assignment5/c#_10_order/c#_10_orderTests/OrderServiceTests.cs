using Microsoft.VisualStudio.TestTools.UnitTesting;
using static c__10_order.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__10_order.Tests
{
    [TestClass]
    public class OrderServiceTests
    {
        
        
        [TestMethod]
        public void SortOrderTest()
        {
            
        }

        [TestMethod]
        public void SortOrderTest1()
        {
            OrderService os = new OrderService();
            os.AddOrder("apple", "me", 52, 73);
            os.AddOrder("dicks", "anno", 56, 7.3);
            os.AddOrder("pussy", "soyo", 10, 6.4);
            os.SortOrder(1,ref OrderService.AllOrders);
            List < Order >l1= new List<Order>();
            OrderDetails od1 = new OrderDetails(10, 6.4);
            OrderDetails od2 = new OrderDetails(56, 7.3);
            OrderDetails od3 = new OrderDetails(52, 73);
            Order o1 = new Order(2, "pussy", "soyo", (6.4 * 10) ,od1 );
            Order o2 = new Order(1, "dicks", "anno", (7.3*56), od2);
            Order o3 = new Order(0, "apple", "me", (73*52), od3);
            l1.Add(o1);l1.Add(o2);l1.Add(o3);
            CollectionAssert.Equals(OrderService.AllOrders, l1);
        }

        [TestMethod]
        public void AddOrderTest()
        {
            OrderService os = new OrderService();
            os.AddOrder("apple", "me", 52, 73);
            List<Order> l1 = new List<Order>();
            OrderDetails od3 = new OrderDetails(52, 73);
            Order o3 = new Order(0, "apple", "me", (73 * 52), od3);
            l1.Add(o3);
            CollectionAssert.Equals(OrderService.AllOrders, l1);
        }

        [TestMethod]
        public void DelOrdersTest()
        {
            OrderService os = new OrderService();
            os.AddOrder("apple", "me", 52, 73);
            os.AddOrder("dicks", "anno", 56, 7.3);
            os.AddOrder("pussy", "soyo", 10, 6.4);
            List<Order> l1 = new List<Order>();
            OrderDetails od1 = new OrderDetails(10, 6.4);
            OrderDetails od2 = new OrderDetails(56, 7.3);
            Order o1 = new Order(2, "pussy", "soyo", (6.4 * 10), od1);
            Order o2 = new Order(1, "dicks", "anno", (7.3 * 56), od2);
            l1.Add(o2); l1.Add(o1);
            os.DelOrders(0);
            CollectionAssert.Equals(OrderService.AllOrders, l1);
        }

        [TestMethod]
        public void ModOrdersTest()
        {
            OrderService os = new OrderService();
            os.AddOrder("apple", "me", 52, 73);
            os.AddOrder("dicks", "anno", 56, 7.3);
            os.AddOrder("pussy", "soyo", 10, 6.4);
            os.DelOrders(0);
            List<Order> l1 = new List<Order>();
            OrderDetails od1 = new OrderDetails(10, 6.4);
            OrderDetails od2 = new OrderDetails(56, 7.3);
            Order o1 = new Order(2, "pussy", "soyo", (6.4 * 10), od1);
            Order o2 = new Order(1, "dicks", "anno", (7.3 * 56), od2);
            l1.Add(o2); l1.Add(o1);
            CollectionAssert.Equals(OrderService.AllOrders, l1);
        }

        [TestMethod]
        public void CheckOrdersTest()
        {
            OrderService os = new OrderService();
            os.AddOrder("apple", "me", 52, 73);
            os.AddOrder("dicks", "anno", 56, 7.3);
            os.AddOrder("pussy", "soyo", 10, 6.4);
            bool a = os.CheckOrders(1, "apple");
            Assert.AreEqual(a, true);
        }
    }
}