/*
Rules: E15-2-5-partial-unconstrained-default
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: partial class Box<T> { public T Value; }
Into: partial class Box<T> where T : class { public T Value; }
*/
using System;
partial class Box<T> { public T Value; }
partial class Box<T> { public T Read() { return Value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object item = new object();
        Check(new Box<int> { Value = 251 }.Read() == 251, "unconstrained-partial-accepts-value-argument");
        Check(new Box<object> { Value = item }.Read() == item, "unconstrained-partial-accepts-reference-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
