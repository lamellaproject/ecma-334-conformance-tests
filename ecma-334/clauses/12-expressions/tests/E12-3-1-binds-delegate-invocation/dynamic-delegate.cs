/*
Rules: E12-3-1-binds-delegate-invocation
Authority: ECMA-334 7th ed 12.3.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic callable = (Transform)Double;
Into: object callable = (Transform)Double;
*/
using System;
public delegate int Transform(int value);
class Program
{
    static int checks, failures;
    static int Double(int value) { return value * 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic callable = (Transform)Double;
        int result = callable(11);
        Check(result == 22, "dynamic-delegate-invocation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
