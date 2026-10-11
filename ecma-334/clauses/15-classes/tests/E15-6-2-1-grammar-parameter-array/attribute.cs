/*
Rules: E15-6-2-1-grammar-parameter-array
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [OnlyParameter] params int[] values
Into: [OnlyMethod] params int[] values
*/
using System;
[AttributeUsage(AttributeTargets.Parameter)]
class OnlyParameterAttribute : Attribute { }
[AttributeUsage(AttributeTargets.Method)]
class OnlyMethodAttribute : Attribute { }
class Program
{
    static int Count([OnlyParameter] params int[] values) { return values.Length; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Count(3, 5) == 2, "attribute-target-is-parameter-array");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
