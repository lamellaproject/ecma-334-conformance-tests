/*
Rules: E10-5-5-ed3-direct-type-candidates
Authority: ECMA-334 3rd ed 13.4.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E10-5-5-ed3-direct-type-candidates/source-parameter.cs.part
Mutate: return (Seal)value;
Into: return (Seal)(Stone)value;
*/
// ECMA-334 3rd ed 13.4.4, p. 142 (PDF p. 162).
using System;
class Stone
{
    public static explicit operator Seal(Stone value) { return new Seal(); }
}
class Pebble : Stone {}
class Seal {}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static Seal Convert<T>(T value) where T : Stone { return (Seal)value; }
    static int Main()
    {
        Check(Convert(new Pebble()) != (object)null, "source-parameter-cast");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
