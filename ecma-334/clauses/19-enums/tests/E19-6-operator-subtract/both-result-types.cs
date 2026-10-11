/*
Rules: E19-6-operator-subtract
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Code.High - Code.Low
Into: Code.Low - Code.High
*/
using System;
enum Code : byte { Low = 5, High = 19 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        byte distance = Code.High - Code.Low;
        Code reduced = Code.High - (byte)3;
        Check(distance == 14, "enum-minus-enum-underlying-result");
        Check((byte)reduced == 16, "enum-minus-underlying-enum-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
