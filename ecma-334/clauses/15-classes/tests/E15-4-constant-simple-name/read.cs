/*
Rules: E15-4-constant-simple-name
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: const int Length = 149;
Into: const int Other = 149;
*/
using System;
class Limits
{
    const int Length = 149;
    public static int Read() { return Length; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Limits.Read() == 149, "simple-name-constant-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
