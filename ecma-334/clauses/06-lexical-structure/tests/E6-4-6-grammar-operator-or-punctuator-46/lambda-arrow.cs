/*
Rules: E6-4-6-grammar-operator-or-punctuator-46
Authority: ECMA-334 7th ed 6.4.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: number => number + 5
Into: number = number + 5
*/
using System;
delegate int Map(int number);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Map apply = number => number + 5;
        Check(apply(12) == 17, "equal-greater");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
