using System;
using System.Reflection;

namespace LAB_5
{
    public static class Program
    {     
        public static string ToStringWithIntegerPart(MyFrac f)
        {
            long nom = f.nom;
            long denom = f.denom;

            if (Math.Abs(nom) > Math.Abs(denom))
            {
                if (nom % denom == 0)
                {
                    if (f.pointer == 1)
                        return $"-{nom / denom}";
                    else
                        return $"{nom / denom}";
                }
                else
                {
                    long integerPart = nom / denom;
                    if (f.pointer == 1)
                        return $"-({integerPart} + {nom % denom}/{denom})";
                    else
                        return $"({integerPart} + {nom % denom}/{denom})";
                }                
            }           
            else
            {
                return $"{nom}/{denom}";
            }
        }        
        public static double DoubleValue(MyFrac f)
        {
            if (f.pointer == 1)
                return -(Convert.ToDouble(f.nom) / Convert.ToDouble(f.denom));
            else
                return Convert.ToDouble(f.nom) / Convert.ToDouble(f.denom);

        }
        public static MyFrac Plus(MyFrac f1, MyFrac f2)
        {            
            int result = f1.pointer == 1 && f2.pointer == 0 ? 1 : f1.pointer == 0 && f2.pointer == 1 ? 2 : f1.pointer == 1 && f2.pointer == 1 ? 0 : -1;
            if (result == 1)
                return new MyFrac(-f1.nom * f2.denom + f1.denom * f2.nom, f1.denom * f2.denom);
            else if (result == 2)
                return new MyFrac(f1.nom * f2.denom + f1.denom * -f2.nom, f1.denom * f2.denom);
            else if (result == 0)
                return new MyFrac(-f1.nom * f2.denom + f1.denom * -f2.nom, f1.denom * f2.denom);                   
            else
                return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom, f1.denom * f2.denom);
        }
        public static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            int result = f1.pointer == 1 && f2.pointer == 0 ? 1 : f1.pointer == 0 && f2.pointer == 1 ? 2 : f1.pointer == 1 && f2.pointer == 1 ? 0 : -1;
            if (f1.nom == f2.nom && f1.denom == f2.denom && result == -1)
                return new MyFrac(0, 0);
            else if (result == 1)
                return new MyFrac(-f1.nom * f2.denom - f1.denom * f2.nom, f1.denom * f2.denom);
            else if (result == 2)
                return new MyFrac(f1.nom * f2.denom + f1.denom * f2.nom, f1.denom * f2.denom);
            else if(result == 0)
                return new MyFrac(-f1.nom * f2.denom + f1.denom * f2.nom, f1.denom * f2.denom);
            else
                return new MyFrac(f1.nom * f2.denom - f1.denom * f2.nom, f1.denom * f2.denom);
        }
        public static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            int result = f1.pointer == 1 && f2.pointer == 0 ? 1 : f1.pointer == 0 && f2.pointer == 1 ? 2 : 0;
            if (result == 1)
                return new MyFrac(-f1.nom * f2.nom, f1.denom * f2.denom);
            else if (result == 2)
                return new MyFrac(f1.nom * -f2.nom, f1.denom * f2.denom);
            else
                return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }
        public static MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            int result = f1.pointer == 1 && f2.pointer == 0 ? 1 : f1.pointer == 0 && f2.pointer == 1 ? 2 : 0;            
            if (result == 1 || result == 2)
                return new MyFrac(-f1.nom * f2.denom, f1.denom * f2.nom);            
            else
                return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
        }
        public static MyFrac CalcSum1(int n)
        {
            MyFrac res = new MyFrac(0, 1);
            
            for (int i = 1; i <= n; i++)
            {
                MyFrac add = new MyFrac(1, i*(i+1));
                
                res = Plus(res, add);                
            }
            return res;
        }
        public static MyFrac CalcSum2(int n)
        {
            MyFrac res = Minus(new MyFrac(1, 1), new MyFrac(1, 4));

            for (int i = 3; i <= n; i++)
            {
                MyFrac add = Minus(new MyFrac(1, 1), new MyFrac(1, i * i));

                res = Multiply(res, add);
            }
            return res;
        }
        public struct MyFrac
        {            
            public long nom;
            public long denom;
            public long lowestDivisor = 0;
            public int pointer = 0;
            
            public MyFrac(long n, long d)
            {
                nom = Math.Abs(n);
                denom = Math.Abs(d);
                
                if ((n < 0 & d < 0) || (n > 0 & d > 0))
                {

                }
                else
                    pointer++;

                n = Math.Abs(n);
                d = Math.Abs(d);
                while (n != 0 && d != 0)
                {
                    if (n > d)
                        n %= d;
                    else
                        d %= n;                  
                }
                lowestDivisor = Math.Max(n, d); 
            }
            
            public override string ToString()
            {
                if (nom == 0)
                    return "0";
                if (nom == denom && pointer == 0)
                    return "1";
                if (nom == denom && pointer == 1)
                    return "-1";
                if (pointer == 1)
                    return $"-{nom / lowestDivisor}/{denom / lowestDivisor}";
                else
                    return $"{nom / lowestDivisor}/{denom / lowestDivisor}";
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Виберіть задачі з одним дробом(1), або задачі з двома дробами(2), або задачі по знаходженнню суми(добутку) по формулі(3):");
            int choice1 = int.Parse(Console.ReadLine());
            switch (choice1)
            {
                case 1:
                    Console.WriteLine("Виберіть задачу для виконання(1 - скорочення дробу, 2 - виділення цілої частини, 3 - дійсне значення дробу):");
                    int choice2 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введіть чисельник і знаменник дробу(через ентер):");
                    long high = long.Parse(Console.ReadLine());
                    long down = long.Parse(Console.ReadLine());
                    MyFrac frac = new MyFrac(high, down);

                    switch (choice2)
                    {
                        case 1:
                            Console.WriteLine("Скорочений дріб: \n" + frac);
                            break;
                        case 2:
                            Console.WriteLine("Дріб з виділеною цілою частиною: \n" + ToStringWithIntegerPart(frac));
                            break;
                        case 3:
                            Console.WriteLine("Дійсне значення дробу: \n" + DoubleValue(frac));
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Виберіть задачу для виконання(1 - сума дробів, 2 - різниця дробів, 3 - добуток дробів, 4 - частка дробів):");
                    int choice3 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введіть чисельник і знаменник першого дробу(через ентер):");
                    long highF1 = long.Parse(Console.ReadLine());
                    long downF1 = long.Parse(Console.ReadLine());
                    MyFrac newFrac1 = new MyFrac(highF1, downF1);

                    Console.WriteLine("Введіть чисельник і знаменник другого дробу(через ентер):");
                    long highF2 = long.Parse(Console.ReadLine());
                    long downF2 = long.Parse(Console.ReadLine());
                    MyFrac newFrac2 = new MyFrac(highF2, downF2);

                    switch (choice3)
                    {
                        case 1:
                            Console.WriteLine("Сума двох дробів:\n" + Plus(newFrac1, newFrac2));
                            break;
                        case 2:
                            Console.WriteLine("Різниця двох дробів:\n" + Minus(newFrac1, newFrac2));
                            break;
                        case 3:
                            Console.WriteLine("Добуток двох дробів:\n" + Multiply(newFrac1, newFrac2));
                            break;
                        case 4:
                            Console.WriteLine("Частка двох дробів:\n" + Divide(newFrac1, newFrac2));
                            break;
                        default:
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("Виберіть задачу для виконання(1 - сума по першій формулі, 2 - добуток по другій формулі):");
                    int choice4 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введіть n:");
                    int n = int.Parse(Console.ReadLine());

                    switch (choice4)
                    {
                        case 1:
                            Console.WriteLine("Сума 1:\n" + CalcSum1(n));
                            break;
                        case 2:
                            Console.WriteLine("Сума 2:\n" + CalcSum2(n));
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }                                                         
        }
    }
}