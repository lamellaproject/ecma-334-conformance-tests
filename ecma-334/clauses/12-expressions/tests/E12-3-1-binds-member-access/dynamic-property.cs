/*
Rules: E12-3-1-binds-member-access
Authority: ECMA-334 7th ed 12.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic receiver = new Box();
Into: object receiver = new Box();
*/
using System;
public class Box { public int Value { get { return 23; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic receiver = new Box();
        int value = receiver.Value;
        Check(value == 23, "dynamic-member-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
