/*
Rules: E6-4-4-grammar-keyword-51
Authority: ECMA-334 7th ed 6.4.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: readonly int Value;
Into: const int Value;
*/
using System;
class Counter
{
    public readonly int Value;
    public Counter(int input) { Value = input; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Counter item = new Counter(61);
        Check(item.Value == 61, "readonly-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
