using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EAPrime\nZach Schickler\n10/29/2021\n");

            // Step: We process all of our program's arguments.
            Arguments arguments = new Arguments(args);
            if (arguments.getFilepath().Equals("empty"))
            {
                Console.WriteLine("Error: No file specified. Exiting.");
                return;
            }

            // Step: We read the values from our file into memory.
            FileParser fp = new FileParser(arguments.getFilepath());
            if (!fp.generateListFromFile())
            {
                return;
            }

            // Step: We print out the prime factorization for each value.
            PrimeFactorCalculator pfc = new PrimeFactorCalculator();
            ArrayList values = fp.getInputList();
            foreach (int value in values)
            {
                Console.Write(value + " : ");
                ArrayList primeFactors = pfc.getPrimeFactors(value);
                for (int i = 0; i < primeFactors.Count - 1; i++)
                    Console.Write(primeFactors[i] + ", ");
                if (primeFactors.Count > 0)
                    Console.Write(primeFactors[primeFactors.Count - 1]);
                Console.WriteLine();
            }
        }
    }
}
