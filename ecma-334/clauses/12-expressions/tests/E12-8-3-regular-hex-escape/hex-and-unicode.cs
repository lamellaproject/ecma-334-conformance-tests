/*
Rules: E12-8-3-regular-hex-escape; E12-8-3-regular-unicode-escape
Authority: ECMA-334 7th ed 12.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: $"\x0041\u0042\U00000043{3}"
Into: $"\x0042\u0042\U00000043{3}"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string result = $"\x0041\u0042\U00000043{3}";
        Check(result == "ABC3", "hex-and-unicode-escapes-are-decoded");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
