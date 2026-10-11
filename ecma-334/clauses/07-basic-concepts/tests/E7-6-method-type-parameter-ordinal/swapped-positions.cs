/*
Rules: E7-6-method-type-parameter-ordinal
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Read<X, Y>(Y first, X second)
Into: Read<X, Y>(X first, Y second)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read<T, U>(T first, U second) { return 17; }
    static int Read<X, Y>(Y first, X second) { return 19; }
    static void Main()
    {
        Check(Read<int, string>(1, "oak") == 17, "parameter-type-ordinals-zero-one");
        Check(Read<int, string>("oak", 1) == 19, "parameter-type-ordinals-one-zero");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
