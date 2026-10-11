/*
Rules: E23-3-safe-typeof-pointer
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: typeof(int*)
Into: typeof(int)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Type type = typeof(int*);
        Check(type.IsPointer && type.GetElementType() == typeof(int), "safe-typeof-pointer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
