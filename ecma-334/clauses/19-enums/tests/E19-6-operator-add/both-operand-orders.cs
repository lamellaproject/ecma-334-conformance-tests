/*
Rules: E19-6-operator-add
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Code.Start + (byte)3
Into: Code.Start - (byte)3
*/
using System;
enum Code : byte { Start = 13 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Code right = Code.Start + (byte)3;
        Code left = (byte)5 + Code.Start;
        Check((byte)right == 16, "enum-plus-underlying");
        Check((byte)left == 18, "underlying-plus-enum");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
