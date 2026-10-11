/*
Rules: E23-2-unsafe-delegate; E23-2-delegate-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe delegate int* Pass
Into: delegate int* Pass
*/
using System;
unsafe delegate int* Pass(int* value);
class Item { public static unsafe int* Identity(int* value) { return value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            int value = 7;
            Pass action = Item.Identity;
            Check(action(&value) == &value, "pointer-delegate-signature");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
