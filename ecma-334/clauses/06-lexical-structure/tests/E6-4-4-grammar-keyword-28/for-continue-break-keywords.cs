/*
Rules: E6-4-4-grammar-keyword-28; E6-4-4-grammar-keyword-13; E6-4-4-grammar-keyword-5
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: continue;
Into: break;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int total = 0;
        for (int i = 0; i < 5; i++)
        {
            if (i == 1) continue;
            if (i == 4) break;
            total += i;
        }
        Check(total == 5, "for-with-continue-and-break");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
