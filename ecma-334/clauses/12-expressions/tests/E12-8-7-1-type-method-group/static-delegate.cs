/*
Rules: E12-8-7-1-type-method-group; E12-8-7-1-type-lookup
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Worker.Value;
Into: other.Value;
*/
using System;
delegate int Pick();
class Worker { public static int Value() { return 3; } }
class Other { public int Value() { return 8; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Other other = new Other();
        Pick call = Worker.Value;
        Check(call.Target == null, "type-method-group-has-no-instance-expression");
        Check(call() == 3, "type-method-group-binds-static-method");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
