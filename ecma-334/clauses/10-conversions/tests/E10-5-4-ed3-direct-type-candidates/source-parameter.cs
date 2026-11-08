/*
Rules: E10-5-4-ed3-direct-type-candidates
Authority: ECMA-334 3rd ed 13.4.3
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E10-5-4-ed3-direct-type-candidates/source-parameter.cs.part
Mutate: return value;
Into: return (Stone)value;
*/
// ECMA-334 3rd ed 13.4.3, p. 141 (PDF p. 161).
using System;
class Stone
{
    public static implicit operator Seal(Stone value) { return new Seal(); }
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
    static Seal Convert<T>(T value) where T : Stone { return value; }
    static int Main()
    {
        Check(Convert(new Pebble()) != (object)null, "source-parameter-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
