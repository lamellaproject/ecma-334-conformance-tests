/*
Rules: E12-8-3-string-type; E12-8-3-string-call-result
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: var value = $"v{3}";
Into: FormattableString value = $"v{3}";
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Pick(string value) { return 3; }
    static int Pick(object value) { return 8; }
    static void Main()
    {
        var value = $"v{3}";
        Check(Pick(value) == 3, "unconverted-interpolated-expression-has-string-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
