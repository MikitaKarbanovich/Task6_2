using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Task6_2;

namespace Task6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqWork lq = new LinqWork();
            List<BigInteger> fibonacciList = new List<BigInteger>();
            List<BigInteger> primeFibonacciList = new List<BigInteger>();
            List<BigInteger> sumFibonacciList = new List<BigInteger>();
            fibonacciList = lq.Fibonacci(200);
            int i = 0;
            foreach (var item in fibonacciList)
            {
                //if (item.IsPrime())
                //{
                //    primeFibonacciList.Add(item);
                //}
                if (item.IsSumOfItems())
                {
                    sumFibonacciList.Add(item);
                }
                i++;
                Console.WriteLine($"Element of list {i}");
            }
            var numbersIsDividedByFive = lq.FindNumbersIsDividedByFive(fibonacciList);
            var sqrtOfNumbersContainsTwo = lq.FindSqrtOfNumbersContainsTwo(fibonacciList);
            var OrderByDescendingSecondItem = lq.SortBySecondItemOfNumber(fibonacciList);
            var maxSumOfSquareOfItems = lq.FindMaxSumOfSquareOfItems(fibonacciList);
            var averageNumberOfZeros = lq.GetAverageNumberOfZeros(fibonacciList);
            var lastTwoItems = lq.LastTwoItems(fibonacciList);
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
}
