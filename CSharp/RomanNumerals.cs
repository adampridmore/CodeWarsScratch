using System.Text;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using System;

//https://www.codewars.com/kata/roman-numerals-encoder/train/csharp

namespace CSharp
{
    public class RomanConvert
    {
        public static string Solution(int n)
        {
            var symbols = new List<Tuple<int, string>>() 
            {
                Tuple.Create(1,"I"),
                Tuple.Create(5,"V"),
                Tuple.Create(10,"X"),
                Tuple.Create(50,"L"),
                Tuple.Create(100,"C"),
                Tuple.Create(500,"D"),
                Tuple.Create(1000,"M"),
            };
            symbols.Reverse();

            var text = new StringBuilder();
            var remainder = n;

            foreach(var symbol in symbols)
            {
                while(remainder >= symbol.Item1)
                {
                    text.Append(symbol.Item2);
                    remainder = remainder - symbol.Item1;
                }
            }

            text.Replace("IIII", "IV");
            text.Replace("LXXXX", "XC");
            text.Replace("DCCCC", "CM");

            return text.ToString();
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(3, "III")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(4, "IV")]
        [InlineData(10, "X")]
        [InlineData(1990, "MCMXC")]
        public void TestEvaluation(int number, string expectedText)
        {
            Assert.Equal(expectedText, Solution(number));
        }
    }
}
