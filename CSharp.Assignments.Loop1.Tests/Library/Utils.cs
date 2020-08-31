using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Assignments.Tests.Library
{
    [DebuggerNonUserCode]
    public static partial class Utils
    {
        internal static string Comma = ", ";
        public static readonly Random Random = new Random();
        public static string ToCode<T>(this T[,] x)
        {
            string[,] o = new string[x.GetLength(0), x.GetLength(1)];
            int length = 0;
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    string value = x[i, j].ToCode();
                    o[i, j] = value;
                    if (value.Length > length)
                    {
                        length = value.Length;
                    }
                }
            }

            var sb = new StringBuilder();
            sb.AppendLine("{");
            string format = $"{{0,{length}}}";
            for (int i = 0; i < o.GetLength(0); i++)
            {
                sb.Append("    { ");
                for (int j = 0; j < o.GetLength(1); j++)
                {
                    if (j > 0)
                    {
                        sb.Append(Comma);
                    }
                    sb.AppendFormat(format, o[i, j]);
                }
                if (i < o.GetLength(0) - 1)
                {
                    sb.AppendLine(" },");
                }
                else
                {
                    sb.AppendLine(" }");
                }
            }
            sb.Append("}");
            return sb.ToString();
        }

        public static string ToCode<T>(this IEnumerable<T> x)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            var i = false;
            foreach (var y in x)
            {
                if (i)
                {
                    sb.Append(Comma);
                }
                else
                {
                    i = true;
                }
                sb.Append(y.ToCode());
            }
            sb.Append("}");
            return sb.ToString();
        }

        private static string ToArrayCode(this Array x, int rank = -1, int[] indices = null)
        {
            if (rank + 1 >= x.Rank)
            {
                return x.GetValue(indices).ToCode();
            }
            if (indices == null)
            {
                indices = new int[x.Rank];
            }
            lock (indices)
            {
                var sb = new StringBuilder();
                sb.Append("{");
                rank++;
                int n = x.GetLength(rank);
                for (int i = 0; i < n; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(Comma);
                    }
                    indices[rank] = i;
                    sb.Append(x.ToArrayCode(rank, indices));
                }
                sb.Append("}");
                return sb.ToString();
            }
        }

        public static string ToCode<T>(this T x)
        {
            if (ReferenceEquals(null, x))
            {
                return "null";
            }
            if (x is Array)
            {
                return ToArrayCode((Array)(object)x);
            }
            var e = x as IEnumerable<object>;
            if (e != null)
            {
                return ToArrayCode(e.ToArray());
            }
            if (x is char)
            {
                char c = Convert.ToChar(x);
                string s = c == '\'' || c == '\\' ? "\\" + c : c.ToString();
                return "'" + s + "'";
            }
            if (x is int || x is short)
            {
                return x.ToString();
            }
            if (x is decimal)
            {
                return x + "m";
            }
            if (x is double || x is float)
            {
                return x + "f";
            }
            if (x is long)
            {
                return x + "l";
            }
            if (x is string)
            {
                var str = x.ToString();
                if (str.IndexOf('"') >= 0 || str.IndexOf('\\') >= 0)
                {
                    return string.Format(@"@""{0}""", str.Replace("\"", "\"\""));
                }
                return string.Format(@"""{0}""", str);
            }
            return x.ToString();
        }

        /// <summary>
        /// Copy a rectangular array
        /// </summary>
        /// <returns>The copy.</returns>
        /// <param name="x">rectangular array</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T[,] Copy<T>(this T[,] x)
        {
            var y = new T[x.GetLength(0), x.GetLength(1)];
            for (int j = 0; j < x.GetLength(0); j++)
            {
                for (int i = 0; i < x.GetLength(1); i++)
                {
                    y[j, i] = x[j, i];
                }
            }
            return y;
        }

        /// <summary>
        /// Shuffling an array
        /// </summary>
        /// <returns>The shuffle.</returns>
        /// <param name="o">O.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T[] Shuffle<T>(this T[] o)
        {
            for (int i = 0; i < o.Length * 2; i++)
            {
                int j = Random.Next(o.Length);
                int k = Random.Next(o.Length);
                T temp = o[j];
                o[j] = o[k];
                o[k] = temp;
            }
            return o;
        }
        public static string Tabulate<T>(this T[,] x)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    sb.Append(x[i, j]);
                    sb.Append("\t");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static T[,] Randomize<T>(int rows, int cols, T start, T end)
        {
            var a = new T[rows, cols];
            var type = typeof(T);
            for (int j = 0, k = rows * cols; j < rows; j++)
            {
                for (int i = 0; i < cols; i++, k--)
                {
                    a[j, i] = (T)type.Randomize(start, end);
                }
            }
            return a;
        }


        public static T[] Randomize<T>(int length, T start, T end)
        {
            Type type = typeof(T);
            return Enumerable.Repeat(0, length).Select(x => (T)type.Randomize(start, end)).ToArray();
        }


        public static object Randomize(this Type type, object start, object end)
        {
            object value = null;
            if (type == typeof(int) || type == typeof(short) || type == typeof(short))
            {
                int a, b;
                if (start.Equals(end))
                {
                    a = 0;
                    b = 10000;
                }
                else
                {
                    a = Convert.ToInt32(start);
                    b = Convert.ToInt32(end);
                }
                value = Random.Next(a, b + 1);
            }
            else if (type == typeof(char))
            {
                int a, b;
                if (start.Equals(end))
                {
                    a = 0;
                    b = char.MaxValue;
                }
                else
                {
                    a = Convert.ToInt32(start);
                    b = Convert.ToInt32(end);
                }
                value = Convert.ToChar(Random.Next(a, b + 1));
            }

            else if (type == typeof(double) || type == typeof(decimal) || type == typeof(float))
            {
                double a, b;
                if (start.Equals(end))
                {
                    a = 0;
                    b = 1;
                }
                else
                {
                    a = Convert.ToDouble(start);
                    b = Convert.ToDouble(end);
                }
                value = Random.NextDouble() * (b - a) + a;
            }

            else if (type == typeof(string))
            {
                string a = start.ToString();
                string b = end.ToString();
                var length = a.Length > b.Length ? b.Length : a.Length;
                var sb = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    sb.Append((char)Random.Next(a[i], b[i] + 1));
                }
                value = sb.ToString();
            }
            return value ?? Activator.CreateInstance(type);
        }

        public static string[] WordList
        {
            get
            {
                string[] words = new string[0];
                GetWords(ref words);
                return words;
            }
        }

        /// <summary>
        /// Get all the words from the word list bank.
        /// </summary>
        /// <param name="words">Words.</param>
        static partial void GetWords(ref string[] words);
    }
}
