using System.Text;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

using Xunit;
using FluentAssertions;
using Xunit.Abstractions;

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
                Tuple.Create(4,"IV"),
                Tuple.Create(5,"V"),
                Tuple.Create(9,"IX"),
                Tuple.Create(10,"X"),
                Tuple.Create(40,"XL"),
                Tuple.Create(50,"L"),
                Tuple.Create(90,"XC"),
                Tuple.Create(100,"C"),
                Tuple.Create(400,"CD"),
                Tuple.Create(500,"D"),
                Tuple.Create(900,"CM"),
                Tuple.Create(1000,"M"),
            }.OrderByDescending(x => x.Item1);

            var text = new StringBuilder();
            var remainder = n;

            foreach (var symbol in symbols)
            {
                while (remainder >= symbol.Item1)
                {
                    text.Append(symbol.Item2);
                    remainder = remainder - symbol.Item1;
                }
            }

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

        [Fact]
        public void Csv_test()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            var resource = assembly.GetManifestResourceStream("CSharp.Resources.RomanNumerals.csv");

            var tr = new StreamReader(resource);
            var text = tr.ReadToEnd();
            var lines = text.Split("\r\n");

            var testValues = lines
                .Select(line => line.Split(","))
                .Select(values => Tuple.Create(int.Parse(values[0]), values[1]));

            foreach (var testValue in testValues)
            {
                var number = testValue.Item1;
                var expectedRomanNumeral = testValue.Item2;

                Solution(number).Should().Match(expectedRomanNumeral, "values was " + number.ToString());
            }
        }
    }
}
