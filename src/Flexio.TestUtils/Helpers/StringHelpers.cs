using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexio.TestUtils.Helpers
{
    public static class StringHelpers
    {
        public static string GetRandomString(int size)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            string randomString = new string(Enumerable.Repeat(chars, size)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return randomString;
        }

        public static string GetRandomNumericAsString(int size)
        {
            Random random = new Random();
            string chars = "0123456789";

            string randomString = new string(Enumerable.Repeat(chars, size)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return randomString;
        }

        public static decimal GetRandomDecimalWithPrecision(int precision, int scale)
        {
            if (precision > 28) throw new Exception();
            if (scale > precision) throw new Exception();

            Random random = new Random();
            string chars = "123456789";

            string numberPart = new string(Enumerable.Repeat(chars, precision - scale)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            string decimalPart = new string(Enumerable.Repeat(chars, scale)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            var decimalString = numberPart + "." + decimalPart;

            return decimal.Parse(decimalString);
        }
    }
}
