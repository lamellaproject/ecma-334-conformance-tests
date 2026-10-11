/*
Rules: E12-4-4-unary-enum-delegate; E12-4-5-binary-enum-delegate
Authority: ECMA-334 7th ed 12.4.4
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Bits first = ~value;
Into: Bits first = value;
*/
using System;
enum Bits { First = 1, Second = 2 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Bits value = Bits.First; Bits first = ~value; Bits second = value | Bits.Second;
        Check((int)first == -2, "enum-unary-candidate");
        Check((int)second == 3, "enum-binary-candidate");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
