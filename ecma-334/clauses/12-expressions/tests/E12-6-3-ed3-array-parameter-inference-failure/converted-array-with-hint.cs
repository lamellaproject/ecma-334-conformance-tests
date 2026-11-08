/*
Rules: E12-6-3-ed3-array-parameter-inference-failure
Authority: ECMA-334 3rd ed 25.6.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-6-3-ed3-array-parameter-inference-failure/converted-array-with-hint.cs.part
Mutate: First(source, hint)
Into: First<int>(source, hint)
*/
// ECMA-334 3rd ed 25.6.4, p. 398 (PDF p. 418).
using System;
struct Packet
{
    public static implicit operator int[](Packet value)
    {
        return new int[] { 61 };
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
    static T First<T>(T[] values, T hint) { return values[0]; }
    static int Main()
    {
        Packet source = new Packet();
        int hint = 24;
        int value = First(source, hint);
        Check(value == 61, "converted-array-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
