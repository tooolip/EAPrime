using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAPrime
{
    public class PrimeFactorCalculator
    {
        private static PrimeFactorCalculator instance = null;

        public static PrimeFactorCalculator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PrimeFactorCalculator();
                }

                return instance;
            }
        }

        public ArrayList getPrimeFactors(int n)
        {
            ArrayList result = new ArrayList();
            int cur = n;

            ArrayList primes = getPrimesUpTo(n);

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

        public ArrayList getPrimesUpTo(int n)
        {
            ArrayList result = new ArrayList();

            if (n <= 1)
                return result;

            bool[] isPrime = new bool[n + 1];

            for (int i = 2; i <= n; i++)
                isPrime[i] = true;

            for (int i = 2; i * i <= n; i++)
                if (isPrime[i])
                    for (int j = i * i; j <= n; j += i)
                        isPrime[j] = false;

            for (int i = 2; i <= n; i++)
                if (isPrime[i])
                    result.Add(i);

            return result;
        }
    }
}