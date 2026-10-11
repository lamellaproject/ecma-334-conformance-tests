/*
Rules: E15-10-3-paired-parameter-types-match
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: operator !=(Gauge a, dynamic b) { return false; }
Into: operator !=(Gauge a, dynamic b) { return true; }
*/
using System;
class Gauge { public static bool operator ==(Gauge a, object b) { return true; } public static bool operator !=(Gauge a, dynamic b) { return false; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge item = new Gauge();
        object other = new object();
        Check(item == other, "object-dynamic-identity-equality");
        Check(!(item != other), "object-dynamic-identity-inequality");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
