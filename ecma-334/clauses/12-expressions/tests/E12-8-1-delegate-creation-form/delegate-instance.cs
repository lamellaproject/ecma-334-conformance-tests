/*
Rules: E12-8-1-delegate-creation-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Pick(Value)
Into: new Pick(Other)
*/
using System;
delegate int Pick();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Value() { return 3; }
    static int Other() { return 8; }
    static void Main()
    {
        Pick call = new Pick(Value);
        Check(call() == 3, "delegate-creation-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
