using System;
using System.Collections;

namespace EAPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EAPrime\nZach Schickler\n10/29/2021\n");

            // Step: We process all of our program's arguments.
            Arguments arguments = new Arguments(args);
            if (arguments.helpEnabled())
            {
                arguments.printHelp();
                return;
            }
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

            // Print title if enabled.
            if (arguments.printoutEnabled())
                arguments.printTitle();
            foreach (int value in values)
            {
                // Print head.
                Console.Write(value + " : ");

                ArrayList primeFactors = pfc.getPrimeFactors(value);
                // Print actual trailing list.
                for (int i = 0; i < primeFactors.Count - 1; i++)
                    Console.Write(primeFactors[i] + ", ");

                // Print final value without trailing comma.
                if (primeFactors.Count > 0)
                    Console.Write(primeFactors[primeFactors.Count - 1]);
                Console.WriteLine();
            }
        }
    }
}
