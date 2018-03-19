using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static string FridayTheThirteenths(int start, int? end)
    {
        DateTime endDateTime = CreateEndDateTime(end);

        var results = new List<DateTime>();

        var dates =
            Get13thOfMonths(start)
            .Where(day => day < endDateTime)
            .Select(dt => $"{dt.Month}/{dt.Day}/{dt.Year}");

        return String.Join(" ", dates);
    }

    private static DateTime CreateEndDateTime(int? End, int Start)
    {
        if (End.HasValue)
        {
            return new DateTime(End.Value + 1, 1, 1, 0, 0, 0, DateTimeKind.Utc) - TimeSpan.FromDays(1);
        }
        else
        {
            return new DateTime(Start, 1, 1) + TimeSpan.FromDays(365);
        }
    }

    private static IEnumerable<DateTime> Get13thOfMonths(int startYear)
    {
        var day = new DateTime(startYear, 1, 13);
        yield return day;
        while (true)
        {
            day = day.AddMonths(1);
            yield return day;
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