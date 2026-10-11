/*
Rules: E12-6-2-1-ref-mode; E12-6-2-1-grammar-ref
Authority: ECMA-334 7th ed 12.6.2.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Update(ref number)
Into: Update(ref other)
*/
using System;
class Program
{
    static int checks, failures;
    static void Update(ref int value) { value += 17; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int number = 11, other = 5; Update(ref number);
        Check(number == 28 && other == 5, "reference-parameter-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
