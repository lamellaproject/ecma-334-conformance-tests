/*
Rules: E12-8-21-conditional-operand; E12-8-21-local-initializer-context
Authority: ECMA-334 7th ed 12.8.21
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: choose ? stackalloc int[1] { 11 } : stackalloc int[2] { 7, 19 }
Into: default(Span<int>)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Exercise(bool choose)
    {
        Span<int> values = choose ? stackalloc int[1] { 11 } : stackalloc int[2] { 7, 19 };
        Check(values.Length == (choose ? 1 : 2), "chosen-allocation-length");
        bool correct = choose ? values.Length == 1 && values[0] == 11 : values.Length == 2 && values[0] == 7 && values[1] == 19;
        Check(correct, "chosen-allocation-items");
    }
    static void Main()
    {
        Exercise(true);
        Exercise(false);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
