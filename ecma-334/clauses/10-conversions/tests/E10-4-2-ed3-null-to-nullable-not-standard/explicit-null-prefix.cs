/*
Rules: E10-4-2-ed3-null-to-nullable-not-standard
Authority: ECMA-334 3rd ed 13.3.1
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E10-4-2-ed3-null-to-nullable-not-standard/explicit-null-prefix.cs.part
Mutate: Tally sum = (Tally)null;
Into: Tally sum = (Tally)(short?)null;
*/
// ECMA-334 3rd ed 13.3.1, p. 140 (PDF p. 160).
using System;
struct Tally
{
    internal int Stamp;
    public static implicit operator Tally(short? item)
    {
        Tally value = new Tally();
        value.Stamp = item.HasValue ? 13 : 17;
        return value;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        Tally sum = (Tally)null;
        Check(sum.Stamp == 17, "nullable-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
