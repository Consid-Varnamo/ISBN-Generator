using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consid.ISBN.Generator
{
    static class Common
    {
        public static IEnumerable<string> GenerateISBNNumberSeries()
        {
            int seed = Convert.ToInt32(DateTime.Now.Ticks & 0x7FFFFFFF);
            Random rnd = new Random(seed);

            for (int i = 0; i < 10; i++)
                yield return CreateISBNNumber(rnd);
        }

        private static string CreateISBNNumber(Random rnd)
        {
            string isbn = "000";

            while (isbn.Length < 12)
            {
                isbn = string.Format("{0}{1}", isbn, rnd.Next(0, 9));
            }

            isbn = string.Format("{0}{1}", isbn, GetISBNCheckDigit(isbn));

            return isbn;
        }

        private static int GetISBNCheckDigit(string digitString)
        {
            int sum;
            int[] digits = digitString
                .ToCharArray()
                .Take(12)
                .Select(c => int.Parse(c.ToString()))
                .ToArray();

            sum = digits
                .Select((i, c) => c % 2 == 0 ? i : i * 3)
                .Sum();

            int checkDigit = (10 - (sum % 10)) % 10;

            return checkDigit;
        }
    }
}
