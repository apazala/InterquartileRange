using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            int n = int.Parse(line);

            int[] arr = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), int.Parse);
            int[] freqs = Array.ConvertAll<string, int>(Console.ReadLine().Split(' '), int.Parse);

            int totalN = freqs.Sum();
            int halfN = totalN / 2;

            int[] counts = new int[101];
            int i;
            for(i = 0; i < n; i++)
            {
                counts[arr[i]] += freqs[i];
            }

            int q1N = halfN / 2, cumFreqs = 0;
            i = 0;
            while(cumFreqs < q1N)
            {
                i++;
                cumFreqs += counts[i];
            }
            int i1 = i;
            while (cumFreqs == q1N)
            {
                i++;
                cumFreqs += counts[i];
            }
            int i2 = i;
            double q1;
            if (halfN % 2 == 0)
            { 
                q1 = (i1 + i2) / 2.0;
            }else
            {
                q1 = i2;
            }

            int q3N = halfN + (n % 2) + q1N;
            while (cumFreqs < q3N)
            {
                i++;
                cumFreqs += counts[i];
            }
            i1 = i;
            while (cumFreqs == q3N)
            {
                i++;
                cumFreqs += counts[i];
            }
            i2 = i;
            double q3;
            if (halfN % 2 == 0)
            {
                q3 = (i1 + i2) / 2.0;
            }
            else
            {
                q3 = i2;
            }

            double intqRange = q3 - q1;

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Console.WriteLine($"{intqRange:0.0}");

            return;
        }
        
    }
}
