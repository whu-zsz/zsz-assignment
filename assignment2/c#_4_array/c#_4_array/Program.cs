using System.Collections;

namespace c__4_array
{
    internal class Program
    {
        class myth_mythod
        {   public void caculate(ArrayList a,out int adds,out double average)
            {
                adds = 0;average = 0.0;
                foreach (int i in a)
                    adds += i;                
                average=a.Count!=0?(double)adds/a.Count:0 ;
            }           
        }
        static void Main(string[] args)
        {

            ArrayList target = new ArrayList { 8,5,7,6,4,9 };
            myth_mythod newmyth = new myth_mythod();
            target.Sort();
            Console.WriteLine("最大值为：{0}", target[target.Count - 1]);
            Console.WriteLine("最小值为：{0}", target[0]);
            int adds=0;double average=0.0;
            newmyth.caculate(target,out adds,out average);
            Console.WriteLine("总和为:{0}", adds);
            Console.WriteLine("平均值为:{0}", average);
        }
    }
}
