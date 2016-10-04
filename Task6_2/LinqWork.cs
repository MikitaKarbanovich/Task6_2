using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Task6_2;

namespace Task6_2
{
    public class LinqWork
    {
        public List<BigInteger> Fibonacci(int n)
        {
            List<BigInteger> fibonacciList = new List<BigInteger>();
            BigInteger a = 0;
            BigInteger b = 1;
            fibonacciList.Add(a);
            for (int i = 0; i < n - 1; i++)
            {
                BigInteger temp = a;
                a = b;
                b = temp + b;
                fibonacciList.Add(a);
            }
            return fibonacciList;
        }
        public List<BigInteger> FindNumbersIsDividedByFive(List<BigInteger> fibonacciList)
        {
            var numbersIsDividedByFive = fibonacciList
                 .Where(number => number % 5 == 0)
                 .ToList();
            return numbersIsDividedByFive;

        }
        public List<BigInteger> FindSqrtOfNumbersContainsTwo(List<BigInteger> fibonacciList)
        {
            var numbersContainsTwo = fibonacciList
                .Where(number => number.ToString().Contains("2"))
                .Select(number => (BigInteger)Math.Floor((double)number * (double)number))
                .ToList();
            return numbersContainsTwo;

        }
        public List<BigInteger> SortBySecondItemOfNumber(List<BigInteger> fibonacciList)
        {
            var numbersContainsTwo = fibonacciList
                .Where(number => number >= 10)
                .OrderByDescending(number => number.ToString().ElementAt(1))
                .ToList();
            return numbersContainsTwo;

        }
        public List<string> LastTwoItems(List<BigInteger> fibonacciList)
        {
            var numbersContainsTwo = fibonacciList
                .Where(number => number % 3 == 0)
                .Where((num, index) => fibonacciList.GetRange(index <= 5 ? 0 : index - 5, index + 5 <= fibonacciList.Count ? index + 5 : fibonacciList.Count)
                .Where(i => i % 5 == 0).ToList().Count > 0)
                .Where(number => number.ToString().Length > 2)
                .Select(number => number.ToString().GetLast(2))
                .ToList();
            return numbersContainsTwo;

        }
        public BigInteger FindMaxSumOfSquareOfItems(List<BigInteger> fibonacciList)
        {
            var maxSumOfItemsSquares = fibonacciList
                .Max(number => number.SumOfSquareOfItems());
            return maxSumOfItemsSquares;
        }
        public double GetAverageNumberOfZeros(List<BigInteger> fibonacciList)
        {
            var averageNumberOfZeros = fibonacciList
                .Average(number => number.ToString().GetQuantityOfZeros());
            return averageNumberOfZeros;
        }

    }
    public static class MyExtensions
    {
        public static int GetQuantityOfZeros(this string source)
        {
            int quantityOfZeros = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i].Equals('0'))
                {
                    quantityOfZeros++;
                }
            }
            return quantityOfZeros;
        }
        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }

        public static bool IsPrime(this BigInteger number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var boundary = number.Sqrt();

            for (BigInteger i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
        public static bool IsSumOfItems(this BigInteger number)
        {
            if (number == 0)
            {
                return false;
            }
            BigInteger rem, sum = 0;
            for (BigInteger i = number; i > 0; i = i / 10)
            {
                rem = i % 10;
                sum += rem;
            }
            if (number % sum == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static BigInteger SumOfSquareOfItems(this BigInteger number)
        {
            BigInteger rem, sum = 0;
            for (BigInteger i = number; i > 0; i = i / 10)
            {
                rem = i % 10;
                sum += (rem * rem);
            }
            return sum;


        }
        public static BigInteger Sqrt(this BigInteger n)
        {
            if (n == 0) return 0;
            if (n > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(n, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);

                while (!isSqrt(n, root))
                {
                    root += n / root;
                    root /= 2;
                }

                return root;
            }

            throw new ArithmeticException("NaN");
        }
        private static Boolean isSqrt(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);

            return (n >= lowerBound && n < upperBound);
        }
    }
}
