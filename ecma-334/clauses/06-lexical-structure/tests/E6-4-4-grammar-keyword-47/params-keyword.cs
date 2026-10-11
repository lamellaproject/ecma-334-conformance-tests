/*
Rules: E6-4-4-grammar-keyword-47
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: params int[] items
Into: int[] items
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Sum(params int[] items)
    {
        int total = 0;
        for (int i = 0; i < items.Length; i++) total += items[i];
        return total;
    }
    static void Main()
    {
        Check(Sum(7, 11) == 18, "params-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
