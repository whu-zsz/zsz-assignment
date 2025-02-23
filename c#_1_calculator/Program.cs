namespace c__1_calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double NumA, NumB;string Symbol;string Result;
            Console.WriteLine("请输入数字1");
            NumA =double.Parse(Console.ReadLine());
            Console.WriteLine("请输入数字2");
            NumB = double.Parse(Console.ReadLine());
            Console.WriteLine("请输入运算符(+ - * /)");
            Symbol = Console.ReadLine();
              
            switch(Symbol)
            {
                case "+":
                    Result = (NumA + NumB).ToString();
                    break;
                case "-":
                    Result = (NumA - NumB).ToString();
                    break;
                case "*":
                    Result = (NumA * NumB).ToString();
                    break;
                case "/":
                    if (NumB == 0) Result = "错误，被除数不能为零。";
                    else Result = (NumA / NumB).ToString();
                    break;
                default:
                    Result = "错误，运算符非+ - * /。";
                    break;
            }
             Console.WriteLine("运算结果为:{0}",Result);
            
            
        }
    }
}
