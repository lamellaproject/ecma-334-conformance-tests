/*
Rules: E14-7-ed5-class-nested-access-restriction
Authority: ECMA-334 5th ed 14.7
Version: 5
Expected: reject
Version-Witness: version-witnesses/E14-7-ed5-class-nested-access-restriction/private-protected.cs.part
Mutate: private protected class Part
Into: protected class Part
*/
// ECMA-334 5th ed 14.7, p. 256 (PDF p. 278), and 15.3.6, p. 275 (PDF p. 297).
// The listed nested-type access forms exclude the private protected combination.
using System;
class Container
{
    private protected class Part { public static int Next(int value) { return value + 1; } }
    public static int Read(int value) { return Part.Next(value); }
}
class Program
{
    static int Main()
    {
        int value = Container.Read(28);
        if (value != 29) { Console.WriteLine("FAIL nested-type"); return 1; }
        Console.WriteLine("OK 1");
        return 0;
    }
}
