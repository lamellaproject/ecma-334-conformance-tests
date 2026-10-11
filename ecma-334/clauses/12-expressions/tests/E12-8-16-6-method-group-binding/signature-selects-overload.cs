/*
Rules: E12-8-16-6-method-group-binding; E12-8-16-6-method-group-target; E12-8-16-6-method-group-evaluation
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: new Measure(Pick)
Into: new Measure(value => Pick((int)value))
*/
using System;
delegate long Measure(long value);
class Program
{
    static long Pick(long value) { return 100 + value; }
    static int Pick(int value) { return 200 + value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Measure operation = new Measure(Pick);
        Check(operation(6) == 106, "method-group-selected-by-delegate-signature");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
