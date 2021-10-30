using System.Collections;

namespace EAPrime
{
    // We use a singleton pattern here because we will never need or want more than one of these calculators.
    // Side note: There are definitely multiple ways to design this class but I just wanted to demonstrate a singleton pattern.
    // Another side note: This class has not been adapted for multi-threading because it is not needed.
    public class PrimeFactorCalculator
    {
        private static PrimeFactorCalculator instance = null;

        public static PrimeFactorCalculator Instance
        {
            get
            {
                // We check to determine if instance is null, which tells us that we have never made an object of this class before.
                if (instance == null)
                {
                    instance = new PrimeFactorCalculator();
                }

                return instance;
            }
        }

        // getPrimeFactors() will provide the program with an array of factors in ascending order.
        public ArrayList getPrimeFactors(int n)
        {
            ArrayList result = new ArrayList();
            int cur = n;

            // Determining the prime factors of a number requires knowing which numbers are prime.
            // Therefore, we start by getting a list of prime numbers that we can refer to.
            ArrayList primes = getPrimesUpTo(n);

            /* 
             * The algorithm involves starting with the smallest prime number less than n and dividing n by it.
             * If the number divides with no remainder, then we know the number is a factor.
             * In order to deal with instances where n can have factors that also have prime factors
             * (i.e. 2 being a factor of 16, 2 being a factor of 4, 4 being a factor of 16)
             * We keep dividing by the smallest prime until we no longer can (hit a remainder).
             * For more information on prime factorization, see https://www.mathsisfun.com/prime-factorization.html.
             */
            while (n > 1)
            {
                foreach (int prime in primes)
                {
                    while (n % prime == 0)
                    {
                        result.Add(prime);
                        n /= prime;
                    }
                }
            }

            return result;
        }

        // getPrimesUpTo() will provide a list of prime numbers up to n.
        public ArrayList getPrimesUpTo(int n)
        {
            ArrayList result = new ArrayList();

            // Base case: There are no primes up to 1 because 1 is not prime.
            if (n <= 1)
                return result;

            /*
             * This algorithm is an implementation of the famous Sieve of Eratosthenes (https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes).
             * It is widely considered a fast method for getting a list of prime numbers (O(nloglogn)).
             * To see various other implementations, visit https://www.geeksforgeeks.org/sieve-of-eratosthenes/.
             * We start by creating a list of numbers up to n.
             * Note: We intitialize with size n + 1 because we treat the array as 1-indexed for convenience.
             */
            bool[] isPrime = new bool[n + 1];

            // Every number starts off as prime because the algorithm determines primes through process of elimination.
            // Note: All of our loops start at 2 because 1 is already known to not be prime and is not required
            // for the rest of the algorithm.
            for (int i = 2; i <= n; i++)
                isPrime[i] = true;


            for (int i = 2; i * i <= n; i++) // Values over i*i are handled in the inner for loop, effectively dividing the work.
                if (isPrime[i]) // We start on 2 which does not need to be checked.
                    for (int j = i * i; j <= n; j += i) // We visit every multiple of i staring at i^2 as to not repeat checked values.
                        isPrime[j] = false; // We can set these numbers as not prime since we have landed on them as a multiple of the prime i.

            // Finally, we check which numbers have survived and add them to our output.
            for (int i = 2; i <= n; i++)
                if (isPrime[i])
                    result.Add(i);

            return result;
        }
    }
}