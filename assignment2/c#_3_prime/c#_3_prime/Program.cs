using System.Collections;

namespace c__3_prime
{
    internal class Program
    {
         class myth_mythod
        {
            public bool if_Prime(int num)
            {
                for(int i = 2; i < num; i++)
                {
                    if (num % i == 0)
                        return false;
                }
                return true;
            }
            public ArrayList if_factor(int num)
            {
                ArrayList tmp = new ArrayList();
                for(int i = 2; i <= num; i++)
                {
                    if (num % i == 0)
                        tmp.Add(i);
                }
                return tmp;
            }
        }
        static void Main(string[] args)
        {   
            Console.WriteLine("请输入一整数");
            int num=int.Parse(Console.ReadLine());
            ArrayList factor = new ArrayList();
            ArrayList result = new ArrayList();
            myth_mythod newmyth = new myth_mythod();
            factor = newmyth.if_factor(num);
            foreach(int i in factor)
            {
                if (newmyth.if_Prime(i))
                    result.Add(i);
            }
            Console.WriteLine("此整数的素因数为：");
            foreach(int i in result)
            {
                Console.Write("{0} ",i);
            }
            
        }
    }
}
