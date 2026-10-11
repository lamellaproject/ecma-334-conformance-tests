/*
Rules: E12-8-1-element-access-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: values[Index()]
Into: values[0]
*/
using System;
class Program
{
    static int checks, failures, calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Index() { calls++; return 0; }
    static void Main()
    {
        int[] values = new int[] { 3, 8 };
        int result = values[Index()];
        Check(result == 3, "element-access-is-primary-expression");
        Check(calls == 1, "element-access-evaluates-index");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
