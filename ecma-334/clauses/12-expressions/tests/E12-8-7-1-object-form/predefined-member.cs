/*
Rules: E12-8-7-1-object-form; E12-8-7-1-predefined-member-form
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object.ReferenceEquals(first, first)
Into: object.ReferenceEquals(first, second)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object first = new object(), second = new object();
        bool result = object.ReferenceEquals(first, first);
        Check(result, "object-keyword-is-static-method-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
