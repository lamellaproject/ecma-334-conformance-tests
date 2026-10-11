/*
Rules: E12-4-5-binary-shared-once; E12-4-6-base-candidates
Authority: ECMA-334 7th ed 12.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: left + right
Into: left - right
*/
using System;
class Base { public static int operator +(Base x, Base y) { return 73; } }
class Left : Base { }
class Right : Base { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Left left = new Left(); Right right = new Right(); int result = left + right;
        Check(result == 73, "shared-base-candidate-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
