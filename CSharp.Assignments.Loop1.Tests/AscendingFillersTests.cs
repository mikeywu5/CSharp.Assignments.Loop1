using System;
using NUnit.Framework;
using CSharp.Assignments.Tests.Library;
using System.Text.RegularExpressions;
namespace CSharp.Assignments.Loop1.Tests
{
    public class AscendingFillersTests
    {
        [Category("Sentinel")]
        [TestCase(ExpectedResult = 0)]
        [TestCase(-1, 10, 20, ExpectedResult = 0)]
        [TestCase(5, ExpectedResult = 0)]
        [TestCase(5, 4, ExpectedResult = 2)]
        [TestCase(5, 6, 7, ExpectedResult = 0)]
        [TestCase(7, 7, 7, ExpectedResult = 3)]
        [TestCase(7, 7, 7, 7, ExpectedResult = 6)]
        [TestCase(7, 7, 0, 7, 7, ExpectedResult = 2)]
        [TestCase(0, 0, 0, 0, 1, ExpectedResult = 0)]
        [TestCase(3, 4, 5, 6, 7, 8, ExpectedResult = 0)]
        [TestCase(3, 4, 5, 0, 6, 7, 8, ExpectedResult = 0)]
        [TestCase(8, 7, 6, 5, 4, 3, 2, 1, ExpectedResult = 56)]
        [TestCase(1, 3, 3, 4, 6, 2, 3, 5, 9, 15, 14, 0, 1, 1, 6, 3, 7, ExpectedResult = 25)]
        public int TestAscendingFillers(params int[] input)
        {
            Action app = new Action(AscendingFillers.Main);
            string actual;
            actual = app.Run(input);
            var match = Regex.Match(actual, @"([-]?\d+)", RegexOptions.Singleline | RegexOptions.RightToLeft);
            if (match == null)
            {
                Assert.Fail($"The last number should indicate the sum of the fillers. - {actual}");
                return 0;
            }
            int actualValue = int.Parse(match.Captures[0].Value);
            return actualValue;
        }
    }
}
