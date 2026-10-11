/*
Rules: E8-2-4-dynamic-runtime-resolution; E8-7-dynamic-binding-type; E8-7-dynamic-operations; E8-7-dynamic-expression-definition
Authority: ECMA-334 7th ed 8.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: dynamic value = (object)new Derived();
Into: Base value = new Derived();
*/
using System;
public class Base { public int Read() { return 11; } }
public class Derived : Base { public new int Read() { return 37; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic value = (object)new Derived();
        int result = value.Read();
        Check(result == 37, "runtime-receiver-type-selects-hidden-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
