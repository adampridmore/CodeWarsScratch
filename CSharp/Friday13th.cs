using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static string FridayTheThirteenths(int start, int? end = null)
    {
        DateTime endDateTime = CreateEndDateTime(start, end);

        return string.Join(" ",
            Get13thOfMonths(start)
            .TakeWhile(day => day < endDateTime)
            .Where(day => day.DayOfWeek == DayOfWeek.Friday)
            .Select(dt => $"{dt.Month}/{dt.Day}/{dt.Year}"));
    }

    private static DateTime CreateEndDateTime(int start, int? end)
    {
        if (end.HasValue)
        {
            return new DateTime(end.Value + 1, 1, 1, 0, 0, 0, DateTimeKind.Utc) - TimeSpan.FromDays(1);
        }
        else
        {
            return new DateTime(start, 1, 1) + TimeSpan.FromDays(365);
        }
    }

    private static IEnumerable<DateTime> Get13thOfMonths(int startYear)
    {
        var day = new DateTime(startYear, 1, 13);
        while (true)
        {
            yield return day;
            try
            {
                day = day.AddMonths(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(day);
                throw ex;
            }

        }
    }
}

[TestFixture]
public class FridayTheThirteenthsTests
{
    [Test]
    public void BasicTests()
    {
        Assert.AreEqual("8/13/1999 10/13/2000", Kata.FridayTheThirteenths(1999, 2000));
    }

    [Test]
    public void No_end_date()
    {
        Assert.AreEqual("8/13/1999", Kata.FridayTheThirteenths(1999));
    }
}