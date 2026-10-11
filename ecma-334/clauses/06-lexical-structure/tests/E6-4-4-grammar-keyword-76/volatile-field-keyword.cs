/*
Rules: E6-4-4-grammar-keyword-76
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: volatile int Value;
Into: voltaic int Value;
*/
using System;
class Counter { public volatile int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter item = new Counter();
        item.Value = 61;
        Check(item.Value == 61, "volatile-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
