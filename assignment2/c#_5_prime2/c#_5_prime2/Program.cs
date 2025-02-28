using System.Collections;

namespace c__5_prime2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ArrayList divides = new ArrayList();
            ArrayList divided = new ArrayList();
            for (int n=2;n<=100;n++ )
            {
                divides.Add(n);
            }
            for (int num = 2; num <= 100; num++)
                
            {   bool if_prime=true;
                foreach(int p in divided)
                {
                    if (num == 2) break;
                    if (num % p == 0)
                    {
                        if_prime = false;
                        break;
                    }
                }
                if (if_prime) divided.Add(num);
                ArrayList b = new ArrayList();
                foreach(int i in divides)
                {
                    if(i==num)
                        b.Add(i);
                    if (i % num != 0)
                        b.Add(i);
                }
                divides = b;
            }
            Console.WriteLine("运算结果是：");
            foreach(int k in divides)
            {
                Console.Write( "{0} ",k);
            }
            Console.WriteLine("end");
        }
    }
}
