/*
Rules: E12-8-22-decode-unicode-escapes
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: nameof(lab\u0065l)
Into: nameof(other)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int label = 7, other = 19;
        Check(nameof(lab\u0065l) == "label", "identifier-unicode-escape-decoded");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
