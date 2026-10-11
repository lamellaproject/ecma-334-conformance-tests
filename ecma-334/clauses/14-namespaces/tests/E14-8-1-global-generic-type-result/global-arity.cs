/*
Rules: E14-8-1-global-generic-type-result; E14-8-1-generic-alias-member; E14-8-1-alias-member-type-context
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: global::Box<int> value
Into: global::Box<string> value
*/
using System;
class Box<T> { public T Value; public Box(T value) { Value = value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        global::Box<int> value = new global::Box<int>(29);
        Check(value.Value == 29, "global-generic-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
