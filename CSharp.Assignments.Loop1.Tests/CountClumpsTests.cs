using System;
using NUnit.Framework;
using CSharp.Assignments.Tests.Library;
using System.Text.RegularExpressions;

namespace CSharp.Assignments.Loop1.Tests
{
    public class CountClumpsTests
    {
        [TestCase(1, 2, 2, 3, 4, 4, ExpectedResult = 2)]
        [TestCase(1, 1, 2, 1, 1, ExpectedResult = 2)]
        [TestCase(1, 1, 1, 1, 1, ExpectedResult = 1)]
        [TestCase(1, 2, 3, ExpectedResult = 0)]
        [TestCase(2, 2, 1, 1, 1, 2, 1, 1, 2, 2, ExpectedResult = 4)]
        [TestCase(0, 2, 2, 1, 1, 1, 2, 1, 1, 2, 2, ExpectedResult = 4)]
        [TestCase(0, 0, 2, 2, 1, 1, 1, 2, 1, 1, 2, 2, ExpectedResult = 5)]
        [TestCase(0, 0, 0, 2, 2, 1, 1, 1, 2, 1, 1, 2, 2, ExpectedResult = 5)]
        [Category("Loop")]
        public int TestCountClumps(params int[] input)
        {
            Action app = new Action(CountClumps.Main);
            string actual;
            actual = app.Run(input);
            var match = Regex.Match(actual, @"([-]?\d+)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            if (match == null)
            {
                Assert.Fail($"The last number should indicate the number of clumps. - {actual}");
                return 0;
            }
            int actualValue = int.Parse(match.Captures[0].Value);
            return actualValue;
        }
    }
}
