/*
Rules: E12-8-4-enclosing-type-parameter; E12-8-4-enclosing-type-order
Authority: ECMA-334 7th ed 12.8.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return default(T);
Into: return default(global::T);
*/
using System;
class T { }
class Shell<T>
{
    public class Nested { public static object Resolve() { return default(T); } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object result = Shell<int>.Nested.Resolve();
        Check(result is int && (int)result == 0, "enclosing-type-parameter-precedes-namespace-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
