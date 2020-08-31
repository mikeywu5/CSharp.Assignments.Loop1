using System;
using NUnit.Framework;
using System.Text.RegularExpressions;
using CSharp.Assignments.Tests.Library;
namespace CSharp.Assignments.Loop1.Tests
{
    public class SquareUpTests
    {
        [TestCase(0, ExpectedResult = new int[0])]
        [TestCase(1, ExpectedResult = new[] { 1 })]
        [TestCase(2, ExpectedResult = new[] { 0, 1, 2, 1 })]
        [TestCase(3, ExpectedResult = new[] { 0, 0, 1, 0, 2, 1, 3, 2, 1 })]
        [TestCase(4, ExpectedResult = new[] { 0, 0, 0, 1, 0, 0, 2, 1, 0, 3, 2, 1, 4, 3, 2, 1 })]
        [TestCase(6, ExpectedResult = new[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2, 1, 0, 0, 0, 3, 2, 1, 0, 0, 4, 3, 2, 1, 0, 5, 4, 3, 2, 1, 6, 5, 4, 3, 2, 1 })]
        [Category("Nested Loop")]

        public int[] TestSquareUp(int size)
        {
            Action app = new Action(SquareUp.Main);
            string actual = app.Run(size);
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
