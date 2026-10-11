/*
Rules: E12-8-3-positive-alignment; E12-8-3-width-after-format; E12-8-3-field-width; E12-8-3-alignment-sign; E12-8-3-pad-width; E12-8-3-width-form; E12-8-3-regular-interpolation
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: $"{26,width:X}"
Into: $"{26,-width:X}"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        const int width = 2 + 3;
        string result = $"{26,width:X}";
        Check(result == "   1A", "positive-width-pads-formatted-value-on-left");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
