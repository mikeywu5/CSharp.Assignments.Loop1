using System;
using NUnit.Framework;
using CSharp.Assignments.Tests.Library;
using System.Text.RegularExpressions;

namespace CSharp.Assignments.Loop1.Tests
{
    public class DisplayTriangleTests
    {
        [TestCase("a", 0, ExpectedResult = new string[0])]
        [TestCase("a", 1, ExpectedResult = new[] {
            "*"})]
        [TestCase("a", 2, ExpectedResult = new[] {
            "*",
            "**"})]
        [TestCase("a", 3, ExpectedResult = new[] {
            "*",
            "**",
            "***"})]
        [TestCase("a", 5, ExpectedResult = new[] {
            "*",
            "**",
            "***",
            "****",
            "*****"})]
        [TestCase("a", 10, ExpectedResult = new[] {
            "*",
            "**",
            "***",
            "****",
            "*****",
            "******",
            "*******",
            "********",
            "*********",
            "**********"})]

        [TestCase("b", 0, ExpectedResult = new string[0])]
        [TestCase("b", 1, ExpectedResult = new[] {
            "*"})]
        [TestCase("b", 2, ExpectedResult = new[] {
            "**",
            "*"})]
        [TestCase("b", 3, ExpectedResult = new[] {
            "***",
            "**",
            "*"})]
        [TestCase("b", 5, ExpectedResult = new[] {
            "*****",
            "****",
            "***",
            "**",
            "*"})]
        [TestCase("b", 10, ExpectedResult = new[] {
            "**********",
            "*********",
            "********",
            "*******",
            "******",
            "*****",
            "****",
            "***",
            "**",
            "*"})]

        [TestCase("c", 0, ExpectedResult = new string[0])]
        [TestCase("c", 1, ExpectedResult = new[] {
            "*"})]
        [TestCase("c", 2, ExpectedResult = new[] {
            "**",
            " *"})]
        [TestCase("c", 3, ExpectedResult = new[] {
            "***",
            " **",
            "  *"})]
        [TestCase("c", 5, ExpectedResult = new[] {
            "*****",
            " ****",
            "  ***",
            "   **",
            "    *"})]
        [TestCase("c", 10, ExpectedResult = new[] {
            "**********",
            " *********",
            "  ********",
            "   *******",
            "    ******",
            "     *****",
            "      ****",
            "       ***",
            "        **",
            "         *"})]

        [TestCase("d", 0, ExpectedResult = new string[0])]
        [TestCase("d", 1, ExpectedResult = new[] {
            "*"})]
        [TestCase("d", 2, ExpectedResult = new[] {
            " *",
            "**"})]
        [TestCase("d", 3, ExpectedResult = new[] {
            "  *",
            " **",
            "***"})]
        [TestCase("d", 5, ExpectedResult = new[] {
            "    *",
            "   **",
            "  ***",
            " ****",
            "*****"})]
        [TestCase("d", 10, ExpectedResult = new[] {
            "         *",
            "        **",
            "       ***",
            "      ****",
            "     *****",
            "    ******",
            "   *******",
            "  ********",
            " *********",
            "**********"})]
        [Category("Nested Loop")]
        public string[] TestDisplayTriangle(string choice, int size)
        {
            Action app = new Action(DisplayTriangle.Main);
            string actual = app.Run(choice, size);
            var match = Regex.Match(actual, @"^\s*\*+\s*$");
            if (match != null)
            {
                actual = actual.Substring(match.Index).TrimEnd();
            }
            else
            {
                return new string[0];
            }
            var actuals = string.IsNullOrEmpty(actual) ?
                new string[0] :
                Regex.Split(actual, @"\r?\n");
            return actuals;
        }
    }
}
