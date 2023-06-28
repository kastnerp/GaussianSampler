using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Distributions;

public class Program
{
    private static void Main(string[] args)
    {
        var histogram = new Dictionary<int, int>();
        var normalDist = new Normal(0, 2); // Mean = 0, SD = 2
        normalDist.RandomSource = new Random(123); // Seed

        for (int i = 0; i < 1000; i++)
        {
            var value = normalDist.Sample();
            var bucket = (int)Math.Floor(value);
            if (histogram.ContainsKey(bucket))
            {
                histogram[bucket]++;
            }
            else
            {
                histogram[bucket] = 1;
            }
        }

        foreach (var bucket in histogram.OrderBy(b => b.Key)) // Sort by bucket key
        {
            Console.WriteLine($"{bucket.Key}: {new string('*', bucket.Value)}");
        }
    }
}