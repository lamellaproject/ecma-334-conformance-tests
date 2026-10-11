/*
Rules: E7-6-method-signature-arity
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: static int Read<T, U>(int value)
Into: static int Read<T>(int value)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(int value) { return value + 1; }
    static int Read<T>(int value) { return value + 2; }
    static int Read<T, U>(int value) { return value + 3; }
    static void Main()
    {
        Check(Read(5) == 6, "zero-type-parameters");
        Check(Read<int>(5) == 7, "one-type-parameter");
        Check(Read<int, string>(5) == 8, "two-type-parameters");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
