/*
Rules: E6-4-4-grammar-keyword-52; E6-4-4-grammar-keyword-45
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Adjust(ref value, out result)
Into: Adjust(value, out result)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Adjust(ref int value, out int result) { value += 3; result = value + 5; }
    static void Main()
    {
        int value = 7, result;
        Adjust(ref value, out result);
        Check(value == 10 && result == 15, "ref-and-out-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
