/*
Rules: E12-8-4-method-type-parameter
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return default(T);
Into: return default(global::T);
*/
using System;
class T { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static object Resolve<T>() { return default(T); }
    static void Main()
    {
        object result = Resolve<int>();
        Check(result is int && (int)result == 0, "method-type-parameter-precedes-namespace-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
