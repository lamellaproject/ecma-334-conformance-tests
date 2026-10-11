/*
Rules: E6-5-2-grammar-pp-conditional-symbol-1
Authority: ECMA-334 7th ed 6.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: #define class
Into: #undef class
*/
#define class
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
#if class
        int amount = 23;
#else
        int amount = 0;
#endif
        Check(amount == 23, "nonboolean-keyword-is-basic-identifier");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
