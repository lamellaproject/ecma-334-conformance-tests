/*
Rules: E14-2-physical-type-containers
Authority: ECMA-334 7th ed 14.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: class Beacon { }
Into: class Different { }
*/
using System;
class Beacon { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(typeof(Beacon).Assembly != null, "declared-type-assembly-container");
        Check(typeof(Beacon).Module.Assembly == typeof(Beacon).Assembly, "module-in-assembly");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
