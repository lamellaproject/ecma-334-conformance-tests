/*
Rules: E7-7-1-method-parameter-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: Select(ref int value)
Into: Select(ref int renamed)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(int value) { if (value < 0) return -value; return value + 1; }
    static ref int Select(ref int value) { return ref value; }
    static void Main()
    {
        Check(Read(-89) == 89, "parameter-in-nested-statement");
        Check(Read(97) == 98, "parameter-in-final-return");
        int value = 101;
        ref int alias = ref Select(ref value);
        alias = 103;
        Check(value == 103, "parameter-in-ref-method-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
