using System;
using NUnit.Framework;
using CSharp.Assignments.Tests.Library;
namespace CSharp.Assignments.Loop1.Tests
{
    public class CheckerboardPatternTests
    {
        const string Case1 = "Blank";
        const string Case2 = "1 by 1";
        const string Case3 = "2 by 2";
        const string Case4 = "3 by 3";
        const string Case5 = "8 by 8";
        const string Case6 = "19 by 19";
        [Category("Nested Loop")]
        [TestCase(Case1, Description = Case1)]
        [TestCase(Case2, Description = Case2)]
        [TestCase(Case3, Description = Case3)]
        [TestCase(Case4, Description = Case4)]
        [TestCase(Case5, Description = Case5)]
        [TestCase(Case6, Description = Case6)]
        public void TestCheckerboardPattern(string testCase)
        {
            Action app = new Action(CheckerboardPattern.Main);
            string result;
            switch (testCase)
            {
                case Case1:
                    result = app.Run(0, "#");
                    result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.NotMatch,
                        @"#"
                    );
                    result = app.Run(-1, "#");
                    result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.NotMatch,
                        @"#"
                    );
                    break;

                case Case2:
                    result = app.Run(1, "$");
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Equal,
                        @"$");
                    Assert.IsEmpty(result.Trim(), Case2);
                    break;
                case Case3:
                    result = app.Run(2, "@");
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Equal,
                        @"@ @",
                        ExpectTo.Equal,
                        @" @ @");
                    Assert.IsEmpty(result.Trim(), Case3);
                    break;
                case Case4:
                    result = app.Run(3, "^");
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Equal,
                        @"^ ^ ^",
                        ExpectTo.Equal,
                        @" ^ ^ ^",
                        @"^ ^ ^");
                    Assert.IsEmpty(result.Trim(), Case4);
                    break;
                case Case5:
                    result = app.Run(8, "&");
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Equal,
                        @"& & & & & & & &",
                        ExpectTo.Equal,
                        @" & & & & & & & &",
                        @"& & & & & & & &",
                        @" & & & & & & & &",
                        @"& & & & & & & &",
                        @" & & & & & & & &",
                        @"& & & & & & & &",
                        @" & & & & & & & &"
                        );
                    Assert.IsEmpty(result.Trim(), Case5);
                    break;

                case Case6:
                    result = app.Run(19, "*");
                    result = result.Assert(
                        ExpectTo.AssertContinuously | ExpectTo.Equal,
                        @"* * * * * * * * * * * * * * * * * * *",
                        ExpectTo.Equal,
                        @" * * * * * * * * * * * * * * * * * * *",
                        @"* * * * * * * * * * * * * * * * * * *",
                        @" * * * * * * * * * * * * * * * * * * *",
                        @"* * * * * * * * * * * * * * * * * * *",
                        @" * * * * * * * * * * * * * * * * * * *",
                        @"* * * * * * * * * * * * * * * * * * *",
                        @" * * * * * * * * * * * * * * * * * * *",
                        @"* * * * * * * * * * * * * * * * * * *",
                        @" * * * * * * * * * * * * * * * * * * *",
                        @"* * * * * * * * * * * * * * * * * * *",
                        @" * * * * * * * * * * * * * * * * * * *",
                        @"* * * * * * * * * * * * * * * * * * *",
                        @" * * * * * * * * * * * * * * * * * * *",
                        @"* * * * * * * * * * * * * * * * * * *",
                        @" * * * * * * * * * * * * * * * * * * *",
                        @"* * * * * * * * * * * * * * * * * * *",
                        @" * * * * * * * * * * * * * * * * * * *",
                        @"* * * * * * * * * * * * * * * * * * *"
                        );
                    Assert.IsEmpty(result.Trim(), Case6);
                    break;
            }
        }
    }
}
