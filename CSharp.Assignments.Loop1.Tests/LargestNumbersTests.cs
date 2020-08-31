using System;
using CSharp.Assignments.Tests.Library;
using NUnit.Framework;
namespace CSharp.Assignments.Loop1.Tests
{
    /// <summary>
    /// The process of finding the maximum value (i.e., the largest
    /// of a group of values) is used frequently in computer applications.
    /// For example, an app that determines the winner of a sales contest
    /// would input the number of units sold by each salesperson. The
    /// salesperson who sells the most units wins the contest.
    /// Write pseudocode, then a C# app that inputs a series of 10 integers,
    /// then determines and displays the largest integer followed by the
    /// second largest integer.
    /// Your app should use at least the following four variables:
    ///     counter: A counter to count to 10 (i.e., to keep track of
    ///        how many numbers have been input and to determine when all
    ///        10 numbers have been processed).
    ///     number (integer): The integer most recently input by the user.
    ///     largest: The largest number found so far.
    ///     largest2: The second largest number found so far.
    /// </summary>
    public class LargestNumbersTests
    {
        const string Case1 = "1 through 10";
        const string Case2 = "Unique Numbers";
        const string Case3 = "Repeated Numbers";
        const string Case4 = "Numbers With some Repeats";
        [TestCase(Case1, Description = Case1)]
        [TestCase(Case2, Description = Case2)]
        [TestCase(Case3, Description = Case3)]
        [TestCase(Case4, Description = Case4)]
        [Category("Loop")]
        public void TestLargestNumbers(string testCase)
        {
            Action app = new Action(LargestNumbers.Main);
            string result;
            switch (testCase)
            {
                case Case1:
                    result = app.Run(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
                    AssertTwoLargest(result, 10, 9, Case1);
                    result = app.Run(-1, -2, -3, -4, -5, -6, -7, -8, -9, -10);
                    AssertTwoLargest(result, -1, -2, Case1);
                    break;

                case Case2:
                    result = app.Run(86413, 31728, 83272, 72137, 90522, 32072, 77765, 20890, 80355, 36987);
                    AssertTwoLargest(result, 90522, 86413, Case2);
                    result = app.Run(-86413, -31728, -83272, -72137, -90522, -32072, -77765, -20890, -80355, -36987);
                    AssertTwoLargest(result, -20890, -31728, $"{Case2} (negatives)");
                    break;

                case Case3:
                    result = app.Run(10, 10, 10, 10, 10, 10, 10, 10, 10, 10);
                    AssertTwoLargest(result, 10, 10, Case3);
                    result = app.Run(-10, -10, -10, -10, -10, -10, -10, -10, -10, -10);
                    AssertTwoLargest(result, -10, -10, $"{Case3} (negatives)");
                    break;

                case Case4:
                    result = app.Run(19, 87, 41, 45, 96, 41, 21, 45, 80, 87);
                    AssertTwoLargest(result, 96, 87, Case4);
                    result = app.Run(19, 87, 41, 45, 96, 41, 21, 45, 80, 96);
                    AssertTwoLargest(result, 96, 96, $"{Case4}");
                    result = app.Run(-19, -87, -41, -45, -96, -41, -21, -45, -80, -21);
                    AssertTwoLargest(result, -19, -21, $"{Case4} (negatives)");
                    result = app.Run(-19, -87, -41, -45, -96, -41, -21, -45, -80, -19);
                    AssertTwoLargest(result, -19, -19, $"{Case4} (negatives)");
                    result = app.Run(-19, -87, -41, -45, 96, -41, -21, -45, -80, -19);
                    AssertTwoLargest(result, 96, -19, $"{Case4} (all)");
                    result = app.Run(-19, -87, -41, -45, 96, -41, -21, -45, -80, 96);
                    AssertTwoLargest(result, 96, 96, $"{Case4} (all)");
                    break;
            }
        }

        private static void AssertTwoLargest(string result, int expectedLargest, int expectedSecondLargest, string message)
        {
            StringAssert.IsMatch($"{expectedLargest}\\b[^\\d-]+?{expectedSecondLargest}\\b", result, message); ;
        }
    }
}
