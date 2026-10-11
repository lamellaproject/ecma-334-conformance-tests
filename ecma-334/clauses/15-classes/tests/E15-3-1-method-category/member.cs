/*
Rules: E15-3-1-method-category; E15-3-1-grammar-class-member-declaration-form-3
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Add(int value) { Number += value; return Number; }
Into: public int Add(int value) { return Number; }
*/
using System;
class Counter
{
    public int Number = 101;
    public int Add(int value) { Number += value; return Number; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter value = new Counter();
        Check(value.Add(3) == 104, "method-computes-result");
        Check(value.Number == 104, "method-performs-action");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
