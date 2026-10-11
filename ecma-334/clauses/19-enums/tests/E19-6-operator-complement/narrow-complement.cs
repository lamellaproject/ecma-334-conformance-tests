/*
Rules: E19-6-operator-complement
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: checked(~Code.Low)
Into: checked(Code.Low)
*/
using System;
enum Code : byte { Low = 15 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Code complement = checked(~Code.Low);
        Check((byte)complement == 240, "byte-enum-complement-always-unchecked");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
