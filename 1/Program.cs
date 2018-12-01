using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadAllLines("input").Select(q => int.Parse(q)).ToList();
            Console.WriteLine("Sum");
            Console.WriteLine(data.Sum());
            
            var knownValues = new List<int>();
            var current = 0;
            for (int ctr = 0; ctr < data.Count; ctr++)
            {
                current += data[ctr];
                if (knownValues.Contains(current)) {
                    Console.WriteLine($"Found duplicate: {current}");
                    break;
                } else {
                    knownValues.Add(current);
                }
                if (ctr == data.Count - 1) {
                    Console.WriteLine("Starting over");
                    ctr = -1;
                }
            }


        }
    }
}
