using System.Security.Cryptography.X509Certificates;

namespace c__9_clock
{
    internal class Program
    {
        public delegate void clockhandler(object sender);
        public class clocks
        {
           

            public int time_now { get; set; }
              
            public int time_clock { get; set; }
            
            public clocks(int time_clock_set )
            {
                time_now = 0;
                time_clock = time_clock_set;
            }

            public event clockhandler Onticks;

            public event clockhandler Onalarm;

            public void start()
            {
                while(time_now<time_clock)
                {
                    Thread.Sleep(1000);
                    time_now++;
                    Onticks(this);
                    if(time_now==time_clock)
                    {
                        Onalarm(this);
                    }
                }
            }
        }
        public class form
        {
            public clocks _clock = new clocks(0);
            void ticks_click(object sender)
            {
                Console.WriteLine("滴哒");
            }
            void alram_click(object sender)
            {
                Console.WriteLine("叮铃铃铃");
            }
           public form(int time)
            {
                clocks clock = new clocks(time);
                _clock = clock;
                clock.Onticks += ticks_click;
                clock.Onalarm += alram_click;
            }            
        }
        static void Main(string[] args)
        {
            int times=0;
            Console.WriteLine("请设置n秒后响铃");
            times = int.Parse(Console.ReadLine());
            form tmp = new form(times);
            Console.WriteLine("闹钟启动，{0}秒后响铃。", times);
            tmp._clock.start();
            Console.WriteLine("完成响铃");
        }
    }
}
