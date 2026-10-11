/*
Rules: E15-6-1-returns-no-value; E15-6-1-grammar-return-type-form-2
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public void Add(int amount) { Value += amount; }
Into: public void Add(int amount) { Value -= amount; }
*/
using System;
class Counter
{
    public int Value;
    public void Add(int amount) { Value += amount; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter value = new Counter();
        value.Add(17);
        Check(value.Value == 17, "void-method-performs-action-without-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
