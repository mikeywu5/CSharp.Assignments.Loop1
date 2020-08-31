using System;
using CSharp.Assignments.Tests.Library;
using NUnit.Framework;

namespace CSharp.Assignments.Loop1.Tests
{
    public class IntegerPalindromesTests
    {
        const string Case1 = "Not Palindrome";
        const string Case2 = "Palindrome";
        const string Case3 = "Sentinel Loop";

        [TestCase(Case1, Description = Case1)]
        [TestCase(Case2, Description = Case2)]
        [TestCase(Case3, Description = Case3)]
        [Category("Loop")]
        public void TestIntegerPalindromes(string testCase)
        {
            Action app = new Action(IntegerPalindromes.Main);
            string result;
            switch (testCase)
            {
                case Case1:
                    result = app.Run(123456789).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("n.*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(987654321).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("n.*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(123554321).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("n.*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(111111110).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("n.*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(500000000).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("n.*?palindrome", result.ToLowerInvariant(), Case1);
                    break;

                case Case2:
                    result = app.Run(123454321).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("^[^n]*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(936212639).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("^[^n]*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(999999999).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("^[^n]*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(733333337).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("^[^n]*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(883333388).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("^[^n]*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(883393388).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("^[^n]*?palindrome", result.ToLowerInvariant(), Case1);
                    break;

                case Case3:
                    result = app.Run(12321, 123456789).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("n.*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(0, 12321, 1, 77, 123456789).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("n.*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(12345, 123454321).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("^[^n]*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(12, 998321, 112, 7744, 123454321).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("^[^n]*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(1000000001, 100000000).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("n.*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(99999999, 100000000).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("n.*?palindrome", result.ToLowerInvariant(), Case1);

                    result = app.Run(123454321, 1234567891).Trim();
                    result = result.Substring(result.LastIndexOf('\n') + 1).Trim();
                    StringAssert.IsMatch("^[^n]*?palindrome", result.ToLowerInvariant(), Case1);
                    break;
            }
        }
    }
}
