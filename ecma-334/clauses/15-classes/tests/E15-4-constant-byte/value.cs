/*
Rules: E15-4-constant-byte
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public const byte Code = 241;
Into: public const byte Code = 240;
*/
using System;
class Limits { public const byte Code = 241; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(byte value) { return 1; }
    static int Kind(int value) { return 2; }
    static void Main()
    {
        Check(Kind(Limits.Code) == 1, "byte-constant-type");
        Check(Limits.Code == 241, "byte-constant-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
