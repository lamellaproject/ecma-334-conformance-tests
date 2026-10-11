/*
Rules: E15-4-constant-member-access
Authority: ECMA-334 7th ed 15.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public const int Length = 163;
Into: public const int Other = 163;
*/
using System;
namespace Measurements { class Limits { public const int Length = 163; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Measurements.Limits.Length == 163, "qualified-member-constant-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
