using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdvCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var lines = File.ReadAllLines("input.txt").ToList();
            var ctr3counts = 0;
            var ctr2counts = 0;
            foreach (var line in lines)
            {
                var lineGroup = line.GroupBy(q => q);
                var has3count = lineGroup.Any(q => q.Count() == 3);
                var has2count = lineGroup.Any(q => q.Count() == 2);
                //Console.WriteLine($"Teksten '{line}' 3: {has3count}, 2: {has2count}");
                ctr3counts += has3count ? 1 : 0;
                ctr2counts += has2count ? 1 : 0;
            }

            Console.WriteLine($"Totalt {ctr3counts}x3 og {ctr2counts}x2, checksum = {ctr3counts * ctr2counts}");
            sw.Stop();
            Console.WriteLine($"Part 1: {sw.ElapsedMilliseconds}ms");
            sw.Restart();

            for (int ctr = 0; ctr < lines.Count(); ctr++)
            {
                for (int ctr2 = ctr + 1; ctr2 < lines.Count(); ctr2++)
                {
                    var result = CompareFuzz(lines[ctr], lines[ctr2]);
                    if (result.equalish)
                    {
                        Console.WriteLine($"Fant like-ish: {lines[ctr]} - {lines[ctr2]} - diff: {result.rest}");
                    }
                }
            }

            sw.Stop();
            Console.WriteLine($"Part 2: {sw.ElapsedMilliseconds}ms");
            
            (bool equalish, string rest) CompareFuzz(string str1, string str2) {
                if (str1.Length != str2.Length) return (false, null);

                var errcounter = 0;
                var errpos = -1;
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != str2[i]) {
                        errcounter++;
                        errpos = i;
                        if (errcounter > 1) return (false, null);
                    }
                }
                if (errcounter == 1) {
                    return (true, str1.Remove(errpos,1));
                }
                return (false, null);
            }
        }
    }
}
