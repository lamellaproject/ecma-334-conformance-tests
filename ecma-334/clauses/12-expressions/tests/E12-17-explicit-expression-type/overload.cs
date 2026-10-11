/*
Rules: E12-17-explicit-expression-type; E12-17-explicit-variable-type; E12-17-explicit-classification; E12-17-explicit-type-form; E12-17-out-argument; E12-17-form; E12-17-declares-local
Authority: ECMA-334 7th ed 12.17
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: out int number
Into: out long number
*/
using System;
class Program
{
    static int Fill(out int value) { value = 41; return 1; }
    static int Fill(out long value) { value = 41; return 2; }
    static int Kind(int value) { return 1; } static int Kind(long value) { return 2; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int selected = Fill(out int number);
        Check(selected == 1 && number == 41 && Kind(number) == 1, "explicit-expression-and-variable-type-select-overload");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
