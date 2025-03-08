using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace c__7_shapes
{
    internal class Program
    {
        public abstract class o_shapes
        {
            protected int []sides;//边集合
            protected int[]angle;//角集合
            private double area;//非法图形面积默认为零
            public double Areas//面积属性
            {
                get { return area; }

                set { area = value; }
            }
            public static  bool if_legal(int[] sides, int[] angle) { return true; }//静态函数判断合法性

            public abstract void area_count();//根据合法性计算面积

            public o_shapes(int[] sides, int[]angle) { this.sides = sides;
                this.angle = angle;//构造函数
            }
        }

        public class triangle:o_shapes
        {
           
            public triangle(int[] sides, int[] angle):base(sides,angle) { }
            static public  bool if_legal(int[] sides, int[] angle)
            {
                if (sides.Length != 3) return false;
                else if (sides[0] + sides[1] > sides[2] 
                    && sides[2] + sides[1] > sides[0] && sides[0] + sides[2] > sides[1])//两边之和大于第三边
                    return true;
                else return false;
            }
            public override void area_count()
            {
                if (if_legal(sides, angle))
                {
                    double p = (sides[0] + sides[1] + sides[2]) / 2.0;
                    double tmp = p * (p - sides[0]) * (p - sides[1]) * (p - sides[2]);//海伦公式
                    Areas=System.Math.Sqrt(tmp);
                    
                }
                else Areas= 0;
            }
        }

        public class square : o_shapes
        {
            public square(int[] sides, int[] angle) : base(sides, angle) { }

            static public  bool if_legal(int[] sides, int[] angle)
            {
                if (angle.Length == 4 && sides.Length == 4)
                {
                    return (angle[0] == 90 && angle[1] == 90 && angle[2] == 90 && angle[3] == 90)
                        && (sides[0] == sides[1] && sides[0] == sides[2] && sides[0] == sides[3]);

                }
                else return false;                
            }
            public override void area_count()
            {
                if (if_legal(sides, angle))
                {
                    Areas= sides[0] * sides[0];
                    
                }
                else Areas = 0;
            }
        }

        public class rectangle : o_shapes
        {
            public rectangle(int[] sides, int[] angle) : base(sides, angle) { }

            static public  bool if_legal(int[] sides, int[] angle)
            {
                if (sides.Length == 4 && angle.Length == 4)
                {
                     int[] tmp = sides;
                    Array.Sort(tmp);
                    return (tmp[0] == tmp[1] && tmp[2] == tmp[3])
                        && (angle[0] == 90 && angle[1] == 90 && angle[2] == 90 && angle[3] == 90);
                }
                else return false;
            }
            public override void area_count()
            {
                if(if_legal(sides, angle))
                {
                    int[] tmp = sides;
                    Array.Sort(tmp);
                    Areas= tmp[0] * tmp[3];
                    
                }
                else Areas = 0;
            }


        }

        public class shape_simple_factory : o_shapes//简单设计工厂
        {
            public shape_simple_factory(int[] sides, int[] angle) : base(sides, angle) { }
            public static o_shapes creat_shapes(int[] sides, int[]angle)//根据合法性创造对应的图形对象
            {
                o_shapes o = null;
                if (triangle.if_legal(sides, angle))
                {
                    o = new triangle(sides, angle);
                    Console.WriteLine("构造三角形");
                }
                else if (rectangle.if_legal(sides, angle))
                {
                    o = new rectangle(sides, angle);
                    Console.WriteLine("构造矩形");
                }
                else if (square.if_legal(sides, angle))
                {
                    o = new square(sides, angle);
                    Console.WriteLine("构造正方形");
                }
                else Console.WriteLine("非法图形");
                return o;
            }
            public override void area_count()
            {
                throw new NotImplementedException();
            }
            static public double count_whole_area(List<o_shapes>whole_shape)//计算全部图形的面积和
            {
                double whole_area=0.0;
                foreach(var i in whole_shape)
                {

                    if (i == null)
                        whole_area += 0;
                    else
                    {
                        i.area_count();
                        whole_area += i.Areas; }
                }
                return whole_area;
            }
        }
        static void Main(string[] args)
        {
            int[] sides1 = new int[] {1,2,5 }; int[] angle1 = new int[] {60,40,100 };
            int[] sides2 = new int[] {2,2,2,2 }; int[] angle2 = new int[] {90,90,90,90 };
            int[] sides3 = new int[] {2,3,6 }; int[] angle3 = new int[] {50,60,70 };
            int[] sides4 = new int[] {2,5,6,8 }; int[] angle4 = new int[] {100,20,20,40 };
            int[] sides5 = new int[] {6,6,6,6 }; int[] angle5 = new int[] { 90,90,90,90};
            int[] sides6 = new int[] {2,6,2,6 }; int[] angle6 = new int[] {90,90,90,90 };
            int[] sides7 = new int[] { 5,9,8}; int[] angle7 = new int[] {40,50,90 };
            int[] sides8 = new int[] {4,5,7,5 }; int[] angle8 = new int[] {50,20,30,30 };
            int[] sides9 = new int[] {1,1,3 }; int[] angle9 = new int[] { 120,40,10};
            int[] sides10 = new int[] {3,3,3 }; int[] angle10 = new int[] {60,60,60 };
            List<o_shapes> whole_shape = new List<o_shapes>();
            int[][] whole_sides = {sides1,sides2, sides3 , sides4,sides5,sides6 , sides7 , sides8 ,
            sides9,sides10};
            int[][] whole_angle = {angle1, angle2 , angle3 , angle4 , angle5 , angle6 , angle7 , angle8 ,
            angle9,angle10};
            for(int i = 0; i < 10; i++)
            {
                o_shapes o_tmp = shape_simple_factory.creat_shapes(whole_sides[i], whole_angle[i]);
                
                whole_shape.Add(o_tmp);
            }
            Console.WriteLine("总面积为：{0}",shape_simple_factory.count_whole_area(whole_shape));
        }
    }
}
