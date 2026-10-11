/*
Rules: E22-2-2-inherited-false
Authority: ECMA-334 7th ed 22.2.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Inherited = false
Into: Inherited = true
*/
using System;
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
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
        Check(inherited.Length == 0, "inheritance-enabled");
        Check(Attribute.GetCustomAttributes(typeof(Child), typeof(MarkAttribute), false).Length == 0, "declared-only");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
