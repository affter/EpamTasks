using System;

namespace Task02_04
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MyString temp = new MyString("123423123124312");
            MyString temp2 = new MyString("441");
            MyString temp3 = temp + temp2;
            string test = "12312312312312312312";
            Console.WriteLine(test.Substring(2, 4));
            Console.WriteLine(test.Substring(2));
            Console.WriteLine(temp3.IndexOf("43").ToString());
            Console.WriteLine(temp3.Substring(2).ToString());
            Console.WriteLine(temp3.Substring(2, 4).ToString());
            Console.WriteLine(temp3.ToString());
            Console.WriteLine(temp3.Remove(2));
            Console.WriteLine(temp3.Remove(3, 6));
        }
    }
}