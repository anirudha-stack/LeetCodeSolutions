public class Solution {
    public int SmallestValue(int n) {
        int copy = n;
        int result=0;
       List<int> factors = GetPrimeFactors(copy);
        while(factors.Count>1){
           copy = 0;
            foreach(int factor in factors){
                copy += factor;
            }
            factors = GetPrimeFactors(copy);

        }

        return factors[0];

    }

    public List<int> GetPrimeFactors(int n)
    {
        List<int> factors = new List<int>();

        // Divide out all factors of 2 first
        while (n % 2 == 0)
        {
            factors.Add(2);
            n /= 2;
        }

        // n must be odd at this point, so we can check only odd numbers
        for (int i = 3; i * i <= n; i += 2)
        {
            while (n % i == 0)
            {
                factors.Add(i);
                n /= i;
            }
        }

        // If n is a prime number greater than 2, then n will remain
        if (n > 2)
        {
            factors.Add(n);
        }

        return factors;
    }
}