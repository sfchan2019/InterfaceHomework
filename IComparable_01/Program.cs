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
            Comparison comparison = new Comparison();

            var a = new Item();
            var b = new Item();
            a.Name = "Bob";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));
            comparison.CompareString(a.Name, b.Name);
            Console.WriteLine();

            a.Name = "Carly";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));
            comparison.CompareString(a.Name, b.Name);
            Console.WriteLine();

            a.Name = "Edward";
            b.Name = "Carly";
            Console.WriteLine("{0} compared to {1} is {2}", a.Name, b.Name, a.CompareTo(b));
            comparison.CompareString(a.Name, b.Name);
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

            public int CompareByName(string str1, string str2)
            {
                return String.Compare(str1, str2);
            }

            public int CompareByLength(string str1, string str2)
            {
                if (str1.Length < str2.Length)
                    return -1;
                else if (str1.Length == str2.Length)
                    return 0;
                else
                    return 1;
            }

            public void CompareString(string str1, string str2)
            {
                int alpOrder = CompareByName(str1, str2);
                PrintResultByName(str1, str2, alpOrder);

                int len = CompareByLength(str1, str2);
                PrintResultByLength(str1, str2, len);
            }

            private void PrintResultByName(string str1, string str2, int result)
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

                Console.WriteLine(String.Format("{0} {1} {2} in alphabetically order", str1, text, str2));
            }
            private void PrintResultByLength(string str1, string str2, int result)
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
            int CompareByName(string str1, string str2);
        }
        interface ICompareByLength
        {
            int CompareByLength(string str1, string str2);
        }

    }
}
