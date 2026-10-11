/*
Rules: E8-3-4-struct-operator-members
Authority: ECMA-334 7th ed 8.3.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return left.Value + right.Value;
Into: return left.Value - right.Value;
*/
using System;
struct Sample { public int Value; public static int operator +(Sample left, Sample right) { return left.Value + right.Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Sample a = new Sample(); Sample b = new Sample(); a.Value = 2; b.Value = 7;
        Check(a + b == 9, "struct-operator");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
