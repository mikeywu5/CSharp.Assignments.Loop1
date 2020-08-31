using System;
using NUnit.Framework;
using System.Text.RegularExpressions;
using CSharp.Assignments.Tests.Library;
namespace CSharp.Assignments.Loop1.Tests
{
    public class FibonacciNumbersTests
    {
        [TestCase(-1, ExpectedResult = new string[0])]
        [TestCase(0, ExpectedResult = new[] {
            0
        })]
        [TestCase(1, ExpectedResult = new[] {
            0, 1, 1
        })]
        [TestCase(2, ExpectedResult = new[] {
            0, 1, 1, 2
        })]
        [TestCase(3, ExpectedResult = new[] {
            0, 1, 1, 2, 3
        })]
        [TestCase(4, ExpectedResult = new[] {
            0, 1, 1, 2, 3
        })]
        [TestCase(5, ExpectedResult = new[] {
            0, 1, 1, 2, 3, 5
        })]
        [TestCase(10, ExpectedResult = new[] {
            0, 1, 1, 2, 3, 5, 8
        })]
        [TestCase(50, ExpectedResult = new[] {
            0, 1, 1, 2, 3, 5, 8, 13, 21, 34
        })]
        [TestCase(144, ExpectedResult = new[] {
            0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144
        })]
        [TestCase(1000, ExpectedResult = new[] {
            0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987
        })]
        [Category("Loop")]
        public int[] TestFibonacciNumbers(int lastNumber)
        {
            Action app = new Action(FibonacciNumbers.Main);
            string actual = app.Run(lastNumber);
            var matches = Regex.Matches(actual, @"([-]?\d+)", RegexOptions.RightToLeft | RegexOptions.Singleline);
            int[] actuals = new int[matches.Count];
            for (int i = 0, j = matches.Count - 1; i < matches.Count; i++, j--)
            {
                Match match = matches[j];
                actuals[i] = int.Parse(match.Groups[1].Value);
            }
            return actuals;
        }
    }
}
