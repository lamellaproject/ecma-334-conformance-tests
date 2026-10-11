/*
Rules: E22-2-2-inherited-true; E22-2-2-inherited-parameter
Authority: ECMA-334 7th ed 22.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Inherited = true
Into: Inherited = false
*/
using System;
[AttributeUsage(AttributeTargets.Class, Inherited = true)]
class MarkAttribute : Attribute { }
[Mark] class Parent { }
class Child : Parent { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Attribute[] inherited = Attribute.GetCustomAttributes(typeof(Child), typeof(MarkAttribute), true);
        Check(inherited.Length == 1, "inheritance-enabled");
        Check(Attribute.GetCustomAttributes(typeof(Child), typeof(MarkAttribute), false).Length == 0, "declared-only");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
