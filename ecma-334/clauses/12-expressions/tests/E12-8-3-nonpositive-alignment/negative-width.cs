/*
Rules: E12-8-3-nonpositive-alignment; E12-8-3-width-after-format; E12-8-3-field-width; E12-8-3-alignment-sign; E12-8-3-pad-width; E12-8-3-verbatim-interpolation
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: $@"{26,-5:X}"
Into: $@"{26,5:X}"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string result = $@"{26,-5:X}";
        Check(result == "1A   ", "negative-width-pads-formatted-value-on-right");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
