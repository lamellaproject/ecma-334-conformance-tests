/*
Rules: E10-2-9-ed3-nullable-own-interface-boxing
Authority: ECMA-334 3rd ed 13.1.5
Version: ISO-2
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E10-2-9-ed3-nullable-own-interface-boxing/nullable-interface-with-plain-underlying.cs.part
Mutate: IComparable boxed = seed;
Into: IComparable boxed = null;
*/
// ECMA-334 3rd ed 13.1.5, p. 135 (PDF p. 155).
using System;
struct Marker { public int Number; public Marker(int number) { Number = number; } }
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
        Marker? seed = new Marker(71);
        IComparable boxed = seed;
        Check(boxed != (object)null, "nullable-own-interface");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
