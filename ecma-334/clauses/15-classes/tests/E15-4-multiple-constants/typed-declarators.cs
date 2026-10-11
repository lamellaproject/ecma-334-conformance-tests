/*
Rules: E15-4-multiple-constants; E15-4-declared-constant-type; E15-4-declarator-member; E15-4-declarator-value
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: public const long Start = 210, End = Start + 37, DoubleEnd = End * 2;
Into: public const int Start = 210, End = Start + 37, DoubleEnd = End * 2;
*/
using System;
class Limits { public const long Start = 210, End = Start + 37, DoubleEnd = End * 2; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(long value) { return 1; }
    static int Kind(int value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Start) == 1, "first-declared-type");
        Check(Kind(Limits.End) == 1, "second-declared-type");
        Check(Kind(Limits.DoubleEnd) == 1, "third-declared-type");
        Check(Limits.Start == 210, "first-declarator-value");
        Check(Limits.End == 247, "second-declarator-value");
        Check(Limits.DoubleEnd == 494, "third-declarator-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
