/*
Rules: E10-5-5-ed3-direct-type-candidates
Authority: ECMA-334 3rd ed 13.4.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E10-5-5-ed3-direct-type-candidates/target-parameter.cs.part
Mutate: return (T)value;
Into: return (T)(Stone)value;
*/
// ECMA-334 3rd ed 13.4.4, p. 142 (PDF p. 162).
using System;
struct Seed {}
class Stone
{
    public static explicit operator Stone(Seed value) { return new Pebble(); }
}
class Pebble : Stone {}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static T Convert<T>(Seed value) where T : Stone { return (T)value; }
    static int Main()
    {
        Check(Convert<Pebble>(new Seed()) != (object)null, "target-parameter-cast");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
