/*
Rules: E12-8-20-reference-parameter-constant
Authority: ECMA-334 7th ed 12.8.20
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: const object value = default(T);
Into: const object value = new object();
*/
using System;
class Marker { }
class Program
{
    static bool IsNull<T>() where T : class { const object value = default(T); return value == null; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(IsNull<Marker>(), "class-bound-default-is-constant");
        Check(IsNull<string>(), "string-bound-default-is-constant");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
