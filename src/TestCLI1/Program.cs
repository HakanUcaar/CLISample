using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCLI1
{
    class Program
    {
        static Dictionary<string, Action<double, double>> CommandList = new Dictionary<string, Action<double, double>>()
        {
            { "--t", delegate (double A, double B) { Topla(A, B); }},
            { "--topla", delegate (double A, double B) { Topla(A,B); }},
            { "--c", delegate (double A, double B) { Cikart(A, B); }},
            { "--cikar", delegate (double A, double B) { Cikart(A,B); }},
            { "--b", delegate (double A, double B) { Bol(A, B); }},
            { "--bol", delegate (double A, double B) { Bol(A,B); }},
            { "--ca", delegate (double A, double B) { Carp(A, B); }},
            { "--carp", delegate (double A, double B) { Carp(A,B); }}
        };
        static Dictionary<string, Action> OtherCommandList = new Dictionary<string, Action>()
        {
            { "-v",delegate() { ShowRobot(); } },
            { "-version",delegate() { ShowRobot(); } },
            { "-help",delegate() { Help(); }}
        };

        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < args.Count(); i++)
                {
                    if (OtherCommandList.ContainsKey(args[i]))
                    {
                        OtherCommandList[args[i]]();
                        break;
                    }
                    if (CommandList.ContainsKey(args[i]))
                    {
                        CommandList[args[i]](Convert.ToDouble(args[i + 1]), Convert.ToDouble(args[i + 2]));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Topla(double A, double B)
        {
            Console.WriteLine(A + B);
        }
        static void Cikart(double A, double B)
        {
            Console.WriteLine(A - B);
        }
        static void Bol(double A, double B)
        {
            Console.WriteLine(A / B);
        }
        static void Carp(double A, double B)
        {
            Console.WriteLine(A * B);
        }

        static void ShowRobot()
        {
            string bot = $"\n       version @0.0.1";
            bot +=
             @"
                    __________________
                                      \
                                       \
                                          ....
                                          ....'
                                           ....
                                        ..........
                                    .............'..'..
                                 ................'..'.....
                               .......'..........'..'..'....
                              ........'..........'..'..'.....
                             .'....'..'..........'..'.......'.
                             .'..................'...   ......
                             .  ......'.........         .....
                             .    _            __        ......
                            ..    #            ##        ......
                           ....       .                 .......
                           ......  .......          ............
                            ................  ......................
                            ........................'................
                           ......................'..'......    .......
                        .........................'..'.....       .......
                     ........    ..'.............'..'....      ..........
                   ..'..'...      ...............'.......      ..........
                  ...'......     ...... ..........  ......         .......
                 ...........   .......              ........        ......
                .......        '...'.'.              '.'.'.'         ....
                .......       .....'..               ..'.....
                   ..       ..........               ..'........
                          ............               ..............
                         .............               '..............
                        ...........'..              .'.'............
                       ...............              .'.'.............
                      .............'..               ..'..'...........
                      ...............                 .'..............
                       .........                        ..............
                        .....
                ";
            Console.WriteLine(bot);
        }
        static void Help()
        {
            Console.WriteLine(
            @"
                --t , --topla  Toplama işlemi yapabilirsin
                --c , --cikar  Çıkarma işlemi yapabilirsin
                --b , --bol    Bölme işlemi yapabilirsin
                --ca , --carp  Çarpma işlemi yapabilirsin
            ");
        }
    }
}
