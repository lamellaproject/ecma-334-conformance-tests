/*
Rules: E19-6-operator-xor; E19-6-operator-and; E19-6-operator-or
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Code.Left ^ Code.Right
Into: Code.Left | Code.Right
*/
using System;
enum Code : byte { Left = 6, Right = 5 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Code exclusive = Code.Left ^ Code.Right;
        Code both = Code.Left & Code.Right;
        Code either = Code.Left | Code.Right;
        Check((byte)exclusive == 3, "enum-xor");
        Check((byte)both == 4, "enum-and");
        Check((byte)either == 7, "enum-or");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
