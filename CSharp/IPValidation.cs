using NUnit.Framework;
using System;
using System.Linq;

namespace Solution
{
    // https://www.codewars.com/kata/515decfd9dcfc23bb6000006/
    [TestFixture]
    public class Kata
    {
        public static bool isValidPart(string part){
            if (String.IsNullOrWhiteSpace(part)){
                return false;
            }

            if (part.Trim() != part){
                return false;
            }

            if (part[0] == '0'){
                return false;
            }

            int i;
            if (!Int32.TryParse(part, out i)){
                return false;
            }

            if (i < 1){
                return false;
            }

            return true;
        }
        public static bool is_valid_IP(string IpAddres)
        {
            var parts = IpAddres.Split('.');
            if (parts.Length != 4)
            {
                return false;
            }

            return parts
                .All(isValidPart)
                ;
        }

        [TestCase("12.255.56.1", ExpectedResult = true)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("abc.def.ghi.jkl", ExpectedResult = false)]
        [TestCase("123.456.789.0", ExpectedResult = false)]
        [TestCase("12.34.56", ExpectedResult = false)]
        [TestCase("12.34.56 .1", ExpectedResult = false)]
        [TestCase("12.34.56.-1", ExpectedResult = false)]
        [TestCase("123.045.067.089", ExpectedResult = false)]
        public bool TestCases(string text)
        {
            return Kata.is_valid_IP(text);
        }
    }
}
