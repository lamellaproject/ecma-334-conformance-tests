/*
Rules: E12-3-1-binds-element-access
Authority: ECMA-334 7th ed 12.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic index = 3;
Into: object index = 3;
*/
using System;
public class Box { public int this[int index] { get { return index + 14; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box receiver = new Box(); dynamic index = 3;
        int value = receiver[index];
        Check(value == 17, "dynamic-element-binding");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
