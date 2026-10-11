/*
Rules: E12-8-16-7-getter-values; E12-8-16-7-constructor-values; E12-8-16-7-property-types; E12-8-16-7-explicit-member-form; E12-8-16-7-trailing-comma-form; E12-8-16-7-member-list-form
Authority: ECMA-334 7th ed 12.8.16.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: new { Count = count, Link = anchor, }
Into: new { Count = count + 1, Link = anchor, }
*/
using System;
class Program
{
    static int Choose(int value) { return 1; }
    static int Choose(long value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int count = 7;
        object anchor = new object(), remembered = anchor;
        var snapshot = new { Count = count, Link = anchor, };
        count = 19;
        anchor = new object();
        Check(snapshot.Count == 7, "getter-returns-stored-integer");
        Check(object.ReferenceEquals(snapshot.Link, remembered), "getter-returns-stored-reference");
        Check(Choose(snapshot.Count) == 1, "property-uses-expression-compile-time-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
