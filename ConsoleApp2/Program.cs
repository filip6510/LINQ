using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Excercises
{
    public static void Do1()
    {
        int n = 0;
        try
        {
            n = int.Parse(Console.ReadLine());
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.StackTrace);
            return;
        }
        var squares =
            from num in Enumerable.Range(1, n)
            where (num != 9 && num != 5 && (num % 2 == 1 || num % 7 == 0))
            select num * num;
        Console.WriteLine(squares.Sum());
        Console.WriteLine(squares.Count());
        Console.WriteLine(squares.First());
        Console.WriteLine(squares.Last());
        Console.WriteLine(squares.ElementAtOrDefault(2));

    }
    public static void Do2()
    {
        Random r = new Random();
        int n = 0, m = 0;
        try
        {
            n = int.Parse(Console.ReadLine());
            m = int.Parse(Console.ReadLine());
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.StackTrace);
            return;
        }
        List<List<int>> list = (from li in Enumerable.Range(1, n)
                                 select (from num in Enumerable.Range(1, m)
                                         select r.Next(-5000, 5000)).ToList()).ToList();
        var sumList = list.SelectMany(q => q.ToList());                                 
        Console.WriteLine(sumList.Sum());
        Console.WriteLine(String.Join(" ",sumList));
    }
    public static void Do3 ()
    {
        List<string> cities = new List<string>();
        string read = Console.ReadLine();
        while (read != "X")
        {
            cities.Add(read);
            read = Console.ReadLine();
        }
        var GroupedCity = cities.GroupBy(city => city.ElementAt(0))
           .Select(gr => gr.OrderBy(x => x)).ToDictionary(x => x.ElementAt(0).ElementAt(0));
        for (; ; )
        {
            read = Console.ReadLine();
            if (read.Length ==  1)
            {
                var aux = from gr in GroupedCity
                          where gr.Key == read.ElementAt(0)
                          select gr;
                if (aux.Count() == 0)
                    Console.WriteLine("PUSTE");
                else
                    Console.WriteLine(String.Join(",", aux.ElementAt(0).Value));
            }
        }
    }
}


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Excercises.Do3();
            Console.ReadLine();
        }
    }
}
