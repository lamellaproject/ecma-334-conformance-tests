/*
Rules: E6-3-2-append-final-cr
Authority: ECMA-334 7th ed 6.3.2
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: #endif
Into: #endi
*/
using System;
#if true
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif