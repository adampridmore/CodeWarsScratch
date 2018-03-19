using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
    public static string FridayTheThirteenths(int Start, int End = int.MinValue)
    {
        var start = new DateTime(Start, 1, 13, 0, 0, 0, DateTimeKind.Utc);

        DateTime end;
        if (End == int.MinValue)
        {
            end = start + TimeSpan.FromDays(365);
        }
        else
        {
            end = new DateTime(End + 1, 1, 1, 0, 0, 0, DateTimeKind.Utc) - TimeSpan.FromDays(1);
        }

        var results = new List<DateTime>();

        for (var day = start; day <= end; day = day.AddMonths(1))
        {
            if (day.DayOfWeek == DayOfWeek.Friday)
            {
                results.Add(day);
            }
        }

        return String.Join(" ", results
            .Select(dt => $"{dt.Month}/{dt.Day}/{dt.Year}"));
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