/*
Rules: E15-4-constant-string
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const string Direction = "north" + "west";
Into: public const string Direction = "north" + "east";
*/
using System;
class Limits { public const string Direction = "north" + "west"; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(string value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Direction) == 1, "string-constant-type");
        Check(Limits.Direction == "northwest", "string-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
