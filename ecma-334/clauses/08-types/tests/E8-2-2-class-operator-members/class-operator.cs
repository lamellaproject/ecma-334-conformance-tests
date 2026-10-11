/*
Rules: E8-2-2-class-operator-members
Authority: ECMA-334 7th ed 8.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return left.Value + right.Value;
Into: return left.Value - right.Value;
*/
using System;
class Device { public int Value; public static int operator +(Device left, Device right) { return left.Value + right.Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Device left = new Device(); Device right = new Device(); left.Value = 4; right.Value = 9;
        Check(left + right == 13, "class-operator-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
