/*
Rules: E15-10-3-binary-nonshift-return-type
Authority: ECMA-334 7th ed 15.10.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: string operator ==(Gauge a, Gauge b) { return "equal"; }
Into: string operator ==(Gauge a, Gauge b) { return "changed"; }
*/
using System;
class Gauge { public static string operator ==(Gauge a, Gauge b) { return "equal"; } public static string operator !=(Gauge a, Gauge b) { return "different"; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge a = new Gauge();
        Gauge b = new Gauge();
        Check((a == b) == "equal", "equality-unrelated-result");
        Check((a != b) == "different", "inequality-unrelated-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
