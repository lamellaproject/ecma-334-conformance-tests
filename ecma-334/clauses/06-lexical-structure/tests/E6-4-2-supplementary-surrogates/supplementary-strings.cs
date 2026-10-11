/*
Rules: E6-4-2-supplementary-surrogates; E6-4-2-escape-codepoint
Authority: ECMA-334 7th ed 6.4.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: "\U00023456"
Into: "\U00023457"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string value = "\U00023456";
        Check(value.Length == 2, "surrogate-pair-length");
        Check(value[0] == 55373 && value[1] == 56406, "surrogate-pair-value");
        string maximum = "\U0010FFFF";
        Check(maximum.Length == 2 && maximum[0] == 56319 && maximum[1] == 57343, "maximum-codepoint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
