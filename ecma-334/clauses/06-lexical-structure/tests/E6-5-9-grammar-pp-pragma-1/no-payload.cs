/*
Rules: E6-5-9-grammar-pp-pragma-1
Authority: ECMA-334 7th ed 6.5.9
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: #pragma
Into: #error
*/
#pragma
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}
