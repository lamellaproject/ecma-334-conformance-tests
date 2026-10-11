/*
Rules: E14-5-2-alias-closed-generic
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: using Pick = Harbor.Box<int>;
Into: using Pick = Harbor.Box<string>;
*/
using System;
using Pick = Harbor.Box<int>;
namespace Harbor { class Box<T> { public T Value; public Box(T value) { Value = value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Pick value = new Pick(29);
        Check(value.Value == 29, "closed-generic-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
