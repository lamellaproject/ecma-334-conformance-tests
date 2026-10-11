/*
Rules: E15-4-multiple-declaration-equivalence
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public const short Large = 3000, Small = 120;
Into: public const ushort Large = 3000, Small = 120;
*/
using System;
class Grouped
{
    [Obsolete("Old limit")]
    public const short Large = 3000, Small = 120;
}
class Separate
{
    [Obsolete("Old limit")]
    public const short Large = 3000;
    [Obsolete("Old limit")]
    public const short Small = 120;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(short value) { return 1; }
    static int Kind(int value) { return 2; }
    static void Main()
    {
        Check(Grouped.Large == Separate.Large && Grouped.Large == 3000, "grouped-first-value");
        Check(Grouped.Small == Separate.Small && Grouped.Small == 120, "grouped-second-value");
        Check(Kind(Grouped.Large) == 1 && Kind(Separate.Large) == 1, "grouped-first-type");
        Check(Kind(Grouped.Small) == 1 && Kind(Separate.Small) == 1, "grouped-second-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
