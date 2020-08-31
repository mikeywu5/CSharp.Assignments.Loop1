using UnitTestingAssert = NUnit.Framework.Assert;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace CSharp.Assignments.Tests.Library
{
    /// <summary>
    /// Expects to equal, equal ignoring cse, contain, start with, end with,
    /// match, not equal, not equal ignoring case, not start with, and not end with.
    /// Adding expect to assert continuously allows the assertions to check
    /// until it matches the criteria.
    /// Expect to go continues on the next statement.
    /// </summary>
    [Flags]
    public enum ExpectTo
    {
        Equal,
        EqualIgnoringCase,
        Contain,
        StartWith,
        EndWith,
        Match,
        NotEqual = 256,
        NotEqualIgnoringCase,
        NotMatch,
        NotStartWith,
        NotEndWith,
        AssertContinuously = 65536,
        Go = 131072,
    }

    //[DebuggerNonUserCode]
    /// <summary>
    /// Assert a console application through the parameterless Main method.
    /// </summary>
    public static class ConsoleAssert
    {
        /// <summary>
        /// Run the main program with several inputs to Console.Read* statements, and then return a string containing the output from Console.Write* statements.
        /// </summary>
        /// <param name="action">The action method</param>
        /// <param name="error">Standard error</param>
        /// <param name="inputs">Variable input arguments</param>
        /// <example>string actual = ConsoleAssert.Run(HelloWorld.Main, "Mike"); // outputs: "Hello World, Mike!</example>
        /// <returns></returns>

        public static string Run<T>(this Action action, out string error, params T[] inputs)
        {
            if (inputs == null) throw new ArgumentNullException();
            string input = inputs == null || inputs.Length < 0 ? "" : string.Join(Environment.NewLine, inputs);
            using (StringReader sr = new StringReader(input))
            {
                Console.SetIn(sr);
                using (StringWriter sw = new StringWriter())
                using (StringWriter se = new StringWriter())
                {
                    Console.SetOut(sw);
                    Console.SetError(se);
                    action();
                    error = se.ToString();
                    return sw.ToString();
                }
            }
        }

        /// <summary>
        /// Run the action with object arguments; Generic arguments may cause issues when you mix-and-match different variable types.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="error">Standard error</param>        /// <param name="inputs"></param>
        /// <returns></returns>
        public static string Run(this Action action, out string error, params object[] inputs)
        {
            return Run<object>(action, out error, inputs);
        }

        /// <summary>
        /// Run the action with no arguments
        /// </summary>
        /// <param name="action"></param>
        /// <param name="error">Standard error</param>
        /// <returns></returns>
        public static string Run(this Action action, out string error)
        {
            return Run<string>(action, out error);
        }

        /// <summary>
        /// Run the main program with several inputs to Console.Read* statements, and then return a string containing the output from Console.Write* statements.
        /// </summary>
        /// <param name="action">The action method</param>
        /// <param name="inputs">Variable input arguments</param>
        /// <example>string actual = ConsoleAssert.Run(HelloWorld.Main, "Mike"); // outputs: "Hello World, Mike!</example>
        /// <returns></returns>

        public static string Run<T>(this Action action, params T[] inputs)
        {
            string error;
            return Run<T>(action, out error, inputs);
        }

        /// <summary>
        /// Run the action with object arguments; Generic arguments may cause issues when you mix-and-match different variable types.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string Run(this Action action, params object[] inputs)
        {
            string error;
            return Run<object>(action, out error, inputs);
        }

        /// <summary>
        /// Run the action with no arguments
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string Run(this Action action)
        {
            string error;
            return Run<string>(action, out error);
        }

        /// <summary>
        /// Asserts the string to match a list of expected values, separated by new-lines.
        /// </summary>
        /// <param name="actual">actual string</param>
        /// <param name="expected">expected objects - optionally ExpectTo enum to indicate the type of string assertions</param>
        /// <returns>The remaining strings that haven't been asserted yet. It can be chained to the next assertions.</returns>
        /// <see cref="ExpectTo"/>
        public static string Assert(this string actual, params object[] expected)
        {
            ExpectTo expects = ExpectTo.Equal;
            bool continueSearching = ExpectTo.AssertContinuously == (expects & ExpectTo.AssertContinuously);
            var actuals =
                actual.TrimEnd().Split('\n').Select(
                    s => s.TrimEnd()
                ).ToArray();
            int lastLine = actuals.Length;
            int i = 0;
            int expectedLine = 1;
            string message;
            if (expected.Length == 0)
            {
                expected = new[] { "" };
            }

            for (int line = 1; line <= lastLine; line++)
            {
                string act = actuals[line - 1];
                var a = act.TrimEnd();
                var o = expected[i];

                if (o is ExpectTo)
                {
                    expects = (ExpectTo)o;
                    if (ExpectTo.Go == (expects & ExpectTo.Go))
                    {
                        return string.Join(Environment.NewLine, actuals.Skip(line - 1));
                    }
                    continueSearching = ExpectTo.AssertContinuously == (expects & ExpectTo.AssertContinuously);
                    expects = expects & (ExpectTo)65535;

                    i++;
                    line--;
                    if (i >= expected.Length)
                    {
                        UnitTestingAssert.Fail($"Expected string has reached to the end of line. Actual at Line {line}: {a}");
                        return "";
                    }

                    continue;
                }
                if (i >= expected.Length)
                {
                    if (continueSearching)
                    {
                        return string.Join(Environment.NewLine, actuals.Skip(line - 1));
                    }
                    UnitTestingAssert.Fail($"Expected string has reached to the end of line. Actual at Line {line}: {a}");
                    return "";
                }

                if (!continueSearching || line >= lastLine || expects >= (ExpectTo)ExpectTo.NotEqual)
                {
                    message = line == (i + 1) ? $"Line {line}" : $"Expected Line {expectedLine}, Actual Line {line}";
                }
                else
                {
                    message = null;
                }
                string e = Convert.ToString(o);
                if (continueSearching)
                {
                    bool assertion = Assert(a, expects, e, message);
                    if (assertion && expects >= (ExpectTo)ExpectTo.NotEqual)
                    {
                        continue;
                    }
                    if (!assertion)
                    {
                        if (message == null)
                        {
                            continue;
                        }
                        else
                        {
                            return string.Join(Environment.NewLine, actuals.Skip(line));
                        }
                    }
                }
                else
                {
                    bool asserted = Assert(a, expects, e, message);
                    if (!asserted)
                    {
                        return "";
                    }
                }
                i++;
                expectedLine++;
            }
            if (expects < ExpectTo.NotEqual && i < expected.Length)
            {
                UnitTestingAssert.Fail($"Expected string has reached to the end of line. Expected line {expectedLine}: {expected[i]}");
            }
            return "";
        }

        private static bool Assert(string actual, ExpectTo expectsTo, string expected, string message)
        {
            bool r;
            switch (expectsTo)
            {
                case ExpectTo.Contain:
                    r = actual == null && expected == null || actual != null && expected != null && actual.Contains(expected);
                    if (!r && message != null)
                    {
                        StringAssert.Contains(expected, actual, $"{message} - The actual string should contain the expected string.");
                    }
                    return r;
                case ExpectTo.EndWith:
                    r = expected == null && actual == null ||
                        actual != null && expected != null && actual.EndsWith(expected, StringComparison.Ordinal);
                    if (!r && message != null)
                        StringAssert.EndsWith(expected, actual, $"{message} - The actual string should end with the expected string.");
                    return r;
                case ExpectTo.Equal:
                    r = expected == actual;
                    if (!r && message != null)
                        UnitTestingAssert.AreEqual(expected, actual, $"{message} - The actual string should equal to the expected string.");
                    return r;
                case ExpectTo.EqualIgnoringCase:
                    r = string.Equals(expected, actual, StringComparison.InvariantCultureIgnoreCase);
                    if (!r && message != null)
                        StringAssert.AreEqualIgnoringCase(expected, actual, $"{message}: The actual string does not equal ignoring case to the expected string.");
                    return r;
                case ExpectTo.Match:
                    r = expected == null && actual == null || expected != null && actual != null && Regex.IsMatch(actual, expected);
                    if (!r && message != null)
                        StringAssert.IsMatch(expected, actual, $"{message} - The actual string should match the expected string pattern.");
                    return r;
                case ExpectTo.NotEndWith:
                    r = (actual == null) != (expected == null) || expected != null && actual != null && !actual.EndsWith(expected, StringComparison.Ordinal);
                    if (!r && message != null)
                        StringAssert.DoesNotEndWith(expected, actual, $"{message} - The actual string should not end with the expected string.");
                    return r;
                case ExpectTo.NotEqual:
                    r = actual != expected;
                    if (!r && message != null)
                        UnitTestingAssert.AreNotEqual(expected, actual, $"{message}: The actual string should not equal to the expected string.");
                    return r;
                case ExpectTo.NotEqualIgnoringCase:
                    r = (expected == null) != (actual == null) || expected != null && actual != null && !expected.Equals(actual, StringComparison.OrdinalIgnoreCase);
                    if (!r && message != null)
                        StringAssert.AreNotEqualIgnoringCase(expected, actual, $"{message} - The actual string should not equal ignoring case to the expected string.");
                    return r;
                case ExpectTo.NotMatch:
                    r = (expected == null) != (actual == null) || expected != null && actual != null && !Regex.IsMatch(actual, expected);
                    if (!r && message != null)
                        StringAssert.DoesNotMatch(expected, actual, $"{message} - The actual string should not match the expected string.");
                    return r;
                case ExpectTo.NotStartWith:
                    r = (expected == null) != (actual == null) ||
                        actual != null && expected != null && !actual.StartsWith(expected, StringComparison.Ordinal);
                    if (!r && message != null)
                        StringAssert.DoesNotStartWith(expected, actual, $"{message} - The actual string should not start with the expected string.");
                    return r;
                case ExpectTo.StartWith:
                    r = (expected == null) && (actual == null) ||
                        actual != null && expected != null && actual.StartsWith(expected, StringComparison.Ordinal);
                    if (!r && message != null)
                        StringAssert.StartsWith(expected, actual, $"{message} - The actual string should start with the expected string.");
                    return r;
                default:
                    throw new InvalidOperationException($"Expect to {expectsTo} is invalid.");
            }
        }

        /// <summary>
        /// Asserting a platform independent string with new-lines.
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        /// <param name="message"></param>
        public static void AreEqual(string expected, string actual, string message = null)
        {
            UnitTestingAssert.AreEqual(
                expected == null ? null : expected.Replace("\r", "").TrimEnd(),
                actual == null ? null : actual.Replace("\r", "").TrimEnd(), message);
        }

        /// <summary>
        /// Append the C# codes to the string builder for easy-to-build assertions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sb"></param>
        /// <param name="action"></param>
        /// <param name="inputs"></param>
        public static void Append<T>(this StringBuilder sb, Action action, T[] inputs)
        {
            string inputString = inputs.ToCode().Trim('{', '}');
            sb.AppendLine($"actual = app.Run({inputString});");
            var output = action.Run(inputs);
            string outputString = output.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToCode().Trim('{', '}');
            sb.AppendLine($"actual.Assert({outputString});");
        }

        /// <summary>
        /// Append the C# codes to the string builder for easy-to-build assertions; all the outputs will add new-lines for readability.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sb"></param>
        /// <param name="action"></param>
        /// <param name="inputs"></param>
        public static void AppendLine<T>(this StringBuilder sb, Action action, T[] inputs)
        {
            var comma = Utils.Comma;
            string inputString = inputs.ToCode().Trim('{', '}');
            sb.AppendLine($"actual = app.Run({inputString});");
            var output = action.Run(inputs);
            Utils.Comma = $",{Environment.NewLine}";
            string outputString = output.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).ToCode().Trim('{', '}');
            sb.AppendLine("actual.Assert(");
            sb.AppendLine($"{ outputString});");
            Utils.Comma = comma;
            sb.AppendLine();
        }

        /// <summary>
        /// Generate test cases
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string Run2(System.Linq.Expressions.Expression<Action> action, params string[] inputs)
        {
            if (inputs == null) throw new ArgumentNullException();
            string input = inputs == null || inputs.Length < 0 ? "" : string.Join(Environment.NewLine, inputs);
            using (StringReader sr = new StringReader(input))
            {
                using (StringWriter sw = new StringWriter())
                {
                    System.Diagnostics.Trace.WriteLine($"actual = ConsoleAssert.Run({action}{input});");
                    Console.SetOut(sw);
                    action.Compile().Invoke();
                    var actuals = sw.ToString();
                    string actualString = string.Join("\n", actuals);
                    System.Diagnostics.Trace.WriteLine($"ConsoleAssert.AreEqual(@\"{actualString}\", actual);");
                    return actualString;
                }
            }
        }
    }
}
