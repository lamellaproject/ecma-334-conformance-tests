/*
Rules: E19-4-first-implicit-zero; E19-4-next-implicit-value; E19-4-explicit-value
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: Start, Next
Into: Start = 1, Next
*/
using System;
enum Code : short { Start, Next, Jump = 11, After, Back = -2, Following }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check((short)Code.Start == 0, "first-implicit-zero");
        Check((short)Code.Next == 1, "next-plus-one");
        Check((short)Code.Jump == 11, "explicit-jump");
        Check((short)Code.After == 12, "after-explicit-plus-one");
        Check((short)Code.Back == -2, "explicit-negative");
        Check((short)Code.Following == -1, "negative-plus-one");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
