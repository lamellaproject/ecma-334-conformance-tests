/*
Rules: E6-4-2-escape-interpolated-strings
Authority: ECMA-334 7th ed 6.4.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: $"\u03BB"
Into: $"\u03BC"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string text = $"\u03BB";
        Check(text.Length == 1 && text[0] == 955, "interpolated-unicode-escape");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
