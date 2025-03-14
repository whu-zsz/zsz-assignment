using System.Reflection.Metadata.Ecma335;

namespace c__8_list
{
    internal class Program
    {

        public class Node<T>
        {
            public Node<T> Next { get; set; }//属性
            public T Data { get; set; }//属性
            public Node(T t)
            {//构造函数
                Next = null;
                Data = t;
            }
        }
        public class List<T>
            {
                public Node<T> head;
                public Node<T> tail;
            
                public void creat()
                {
                    head = tail = null;
                }
                public Node<T> Head
                {
                    get { return head; }
                }
                public void add(T t)
                {
                    Node<T> tmp = new Node<T>(t);
                    if (tail == null)
                        head = tail = tmp;
                    else
                    {
                        tail.Next = tmp;
                        tail = tmp;
                    }
                }
                public void Foreach(Action<T> action)
            {
                Node<T> now_node = head;
                while (now_node != null)
                {
                    action(now_node.Data);
                    now_node = now_node.Next;
                }
            }
            } 
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.add(45); list.add(145); list.add(455); list.add(452); list.add(450);
            Console.WriteLine("输出列表：");
            list.Foreach(x => Console.WriteLine("{0} ", x));
            int max = int.MinValue;int min = int.MaxValue;
            list.Foreach(x => { if (x < min) min = x; });
            list.Foreach(x => { if (x > max) max = x; });
            Console.WriteLine("输出最大值：{0}", max);
            Console.WriteLine("输出最小值：{0}", min);
            int sum = 0;
            list.Foreach(x => sum += x);
            Console.WriteLine("输出总和：{0}", sum);

        }
    }
}
