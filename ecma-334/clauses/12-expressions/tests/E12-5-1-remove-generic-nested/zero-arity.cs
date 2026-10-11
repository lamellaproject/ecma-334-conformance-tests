/*
Rules: E12-5-1-remove-generic-nested
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Mark<T>
Into: class Mark
*/
using System;
class Base { public int Mark = 37; }
class Derived : Base { public new class Mark<T> { } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived receiver = new Derived(); int result = receiver.Mark;
        Check(result == 37, "generic-nested-type-removed-at-zero-arity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
