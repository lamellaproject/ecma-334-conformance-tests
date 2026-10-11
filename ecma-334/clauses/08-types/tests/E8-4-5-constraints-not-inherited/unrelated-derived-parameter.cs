/*
Rules: E8-4-5-constraints-not-inherited
Authority: ECMA-334 7th ed 8.4.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Derived<int> value = new Derived<int>();
Into: Derived<int> value = null;
*/
using System;
class Base<T> where T : class { }
class Derived<U> : Base<object> { public U Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Derived<int> value = new Derived<int>(); value.Value = 24;
        Check(value.Value == 24, "base-class-constraint-not-inherited-by-new-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
