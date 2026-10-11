/*
Rules: E12-8-22-remove-formatting-characters
Authority: ECMA-334 7th ed 12.8.22
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: nameof(lab\u200Cel)
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
        Check(nameof(lab\u200Cel) == "label", "identifier-format-character-removed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
