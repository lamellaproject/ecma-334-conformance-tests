/*
Rules: E6-5-6-grammar-pp-diagnostic-2
Authority: ECMA-334 7th ed 6.5.6
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: #warning
Into: #error
*/
#warning
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
