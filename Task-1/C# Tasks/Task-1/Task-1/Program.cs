
using System.Diagnostics;
using System.Text;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = GetInput();
            SumBenchmark benchmark = new SumBenchmark();
            benchmark.SumFormula(n);
            benchmark.SumForLoop(n);

            PrintNumbers();


        }

        public static void PrintNumbers()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= 100; i++)
            {
                sb.Append(i + ", ");
            }

            sb.Length--; // Remove the last comma


            /*
             * int [] numbers = new int[100];
             * for (int i = 1; i <= 100; i++)
            {
                // without string builder
                 numbers[i - 1] = i;
                
            }
            string result = string.join(", ", numbers); // this is better for large sets BUT BOTH ARE GREAT -> only one allocation for the final string (it computes the final length
            and allocates memory at once and then fills it)
            - stringbuilder appends string while removing old string
             * 
             */

            Console.WriteLine(sb.ToString());

            /*
             * string builder operates:
             * At its core, StringBuilder maintains an internal character array (buffer)
             * Unlike immutable strings, modifying a StringBuilder does not create a new string—it modifies this internal buffer directly.
             * Instead of resizing one huge array repeatedly (which is expensive), StringBuilder allocates multiple smaller arrays (chunks), each pointing to the previous chunk
             * it creates additional chunk if needed
             * Appending is fast (amortized O(1) time).
             * Random inserts or deletes are slower (can be O(n)).
             * tostring() returns a new string based on the current state of the StringBuilder, copying the characters from its internal buffer to a new string object.
             * 
             */

        }

        public static int GetInput()
        {
            Console.Write("Enter a number: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                Console.WriteLine($"You entered: {number}");
            }
            else
            {
                Console.WriteLine("Invalid number. Please enter a valid integer.");
            }
            return number;
        }
    }

    public class SumBenchmark
    {
        Stopwatch sw = new Stopwatch();


        public void SumForLoop(int n) // o(n)
        {
            sw.Restart();
            sw.Start();
            long sum = 0;
            for (int i = 1; i <= n; i++)
            {
                sum += i;
            }
            
            sw.Stop();
            Console.WriteLine($" Loop Time: {sw.ElapsedMilliseconds} ms");
        }

        public void SumFormula(int n) // o(1)
        {

            sw.Restart();
            sw.Start();
            long sum =  (long)n * (n + 1) / 2;
            sw.Stop();
            Console.WriteLine($" Formula Time: {sw.ElapsedMilliseconds} ms");

        }

        

    }
}
