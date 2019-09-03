using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparable_01
{

    class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();
            app.Run();
        }

        public class Application
        {
            public void Run()
            {
                var a = new Comparison();
                var b = new Comparison();
                a.Name = "Bob";
                b.Name = "Carly";
                a.CompareString(b);
                Console.WriteLine();

                a.Name = "Carly";
                b.Name = "Carly";
                a.CompareString(b);
                Console.WriteLine();

                a.Name = "Edward";
                b.Name = "Carly";
                a.CompareString(b);
                Console.WriteLine();

                while (true)
                {
                    Console.WriteLine("Enter the name for item a");
                    a.Name = Console.ReadLine();
                    Console.WriteLine("Enter the name for item b");
                    b.Name = Console.ReadLine();
                    a.CompareString(b);
                    Console.WriteLine();

                    Console.WriteLine("Enter 1 to continue, anything else to exit program");
                    if (Console.ReadLine() != "1")
                        break;
                }
            }
        }
        public class Item : IComparable
        {
            public string Name;

            public int CompareTo(object o)
            {
                Item that = o as Item;
                return this.Name.CompareTo(that.Name);
            }
        }

        public class Comparison : ICompareByName, ICompareByLength
        {
            private string name;
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int CompareByName(object obj)
            {
                Comparison that = obj as Comparison;
                return String.Compare(this.name, that.name);
            }

            public int CompareByLength(object obj)
            {
                Comparison that = obj as Comparison;
                if (this.name.Length < that.name.Length)
                    return -1;
                else if (this.name.Length == that.name.Length)
                    return 0;
                else
                    return 1;
            }

            public void CompareString(object obj)
            {
                Comparison that = obj as Comparison;
                int alpOrder = CompareByName(obj);
                PrintNameResult(this.name, that.name, alpOrder);

                int len = CompareByLength(obj);
                PrintLengthResult(this.name, that.name, len);
            }

            private void PrintNameResult(string str1, string str2, int result)
            {
                string text;
                switch (result)
                {
                    case -1:
                        text = "is below";
                        break;
                    case 0:
                        text = "is the same as";
                        break;
                    case 1:
                        text = "is above";
                        break;
                    default:
                        Console.WriteLine("Invalid Input, please try again");
                        return;
                }

                Console.WriteLine(String.Format("{0} {1} {2} alphabetically", str1, text, str2));
            }
            private void PrintLengthResult(string str1, string str2, int result)
            {
                string text;
                switch (result)
                {
                    case -1:
                        text = "is shorter than";
                        break;
                    case 0:
                        text = "has the same length as";
                        break;
                    case 1:
                        text = "is longer than";
                        break;
                    default:
                        Console.WriteLine("Invalid Input, please try again");
                        return;
                }
                Console.WriteLine(String.Format("{0} {1} {2} ", str1, text, str2));
            }
        }

        interface ICompareByName
        {
            int CompareByName(object obj);
        }
        interface ICompareByLength
        {
            int CompareByLength(object obj);
        }

    }
}
