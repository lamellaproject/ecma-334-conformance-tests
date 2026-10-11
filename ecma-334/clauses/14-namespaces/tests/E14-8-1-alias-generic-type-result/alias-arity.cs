/*
Rules: E14-8-1-alias-generic-type-result
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Scope::Box<int> value
Into: Scope::Box<string> value
*/
using System;
using Scope = Harbor;
namespace Harbor { class Box<T> { public T Value; public Box(T value) { Value = value; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Scope::Box<int> value = new Scope::Box<int>(29);
        Check(value.Value == 29, "alias-generic-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
