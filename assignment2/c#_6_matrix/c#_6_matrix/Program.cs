namespace c__6_matrix
{
    internal class Program
    {
        class matrix
        {
            public bool judge(int[,]target)
            {
                int length = target.GetLength(1)-1, width = target.GetLength(0)-1;
                int x_i=0, y_i=width;int x, y;
                while (y_i>=0)
                {   x = x_i ;y = y_i;
                    while(x<=length&&y<=width)
                    {
                        
                        if (target[y_i, x_i] != target[y,x])
                            return false;
                        x += 1; y += 1;
                    }
                    y_i -= 1;
                }
                x_i = 0;y_i = 0;
                while(x_i<=length)
                {
                    x = x_i;y = y_i;
                    while(x <= length && y <= width)
                    {
                     
                        if (target[y_i, x_i] != target[y, x])
                            return false;
                        x += 1; y += 1;
                    }
                    x_i += 1;
                }
                return true;
            }
        }
        static void Main(string[] args)
        {
            int[,]target= new int[,] { {1,2,3,4 },
                                       {6,1,2,3 },
                                       {7,6,1,2 }};
            int[,] target1 = new int[,] { {1,2,3,4 },
                                          {6,3,2,3 },
                                          {7,6,1,2 }};
            matrix new_m = new matrix();
            if (new_m.judge(target1))
                Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
}
