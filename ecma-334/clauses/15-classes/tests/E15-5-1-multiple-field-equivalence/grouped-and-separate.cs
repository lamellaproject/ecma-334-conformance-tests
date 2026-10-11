/*
Rules: E15-5-1-multiple-field-equivalence
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public short First = 701, Second = 739;
Into: public ushort First = 701, Second = 739;
*/
using System;
class Grouped
{
    [Obsolete("Old reading")]
    public short First = 701, Second = 739;
}
class Separate
{
    [Obsolete("Old reading")]
    public short First = 701;
    [Obsolete("Old reading")]
    public short Second = 739;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(short value) { return 1; }
    static int Kind(int value) { return 2; }
    static void Main()
    {
        Grouped grouped = new Grouped();
        Separate separate = new Separate();
        Check(grouped.First == separate.First && grouped.First == 701, "grouped-first-field-value");
        Check(grouped.Second == separate.Second && grouped.Second == 739, "grouped-second-field-value");
        Check(Kind(grouped.First) == 1 && Kind(separate.First) == 1, "grouped-first-field-type");
        Check(Kind(grouped.Second) == 1 && Kind(separate.Second) == 1, "grouped-second-field-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
