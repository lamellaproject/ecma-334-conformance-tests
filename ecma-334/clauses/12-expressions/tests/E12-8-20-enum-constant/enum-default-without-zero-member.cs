/*
Rules: E12-8-20-enum-constant
Authority: ECMA-334 7th ed 12.8.20
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: const Mode value = default(Mode);
Into: const Mode value = Mode.Active;
*/
using System;
enum Mode : ushort { Active = 7 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const Mode value = default(Mode);
        Check(value == (Mode)0, "default-enum-is-zero-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
