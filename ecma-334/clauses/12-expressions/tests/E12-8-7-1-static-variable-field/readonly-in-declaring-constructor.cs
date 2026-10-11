/*
Rules: E12-8-7-1-static-variable-field
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Touch(ref Worker.value);
Into: Touch(ref copy);
*/
using System;
class Worker
{
    public static readonly int value;
    static Worker()
    {
        value = 3;
        int copy = value;
        Touch(ref Worker.value);
    }
    static void Touch(ref int value) { value++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Worker.value == 4, "readonly-static-field-is-variable-in-declaring-static-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
