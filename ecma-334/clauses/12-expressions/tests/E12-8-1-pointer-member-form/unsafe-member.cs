/*
Rules: E12-8-1-pointer-member-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: pointer->value
Into: pointer->other
*/
using System;
struct Cell { public int value, other; }
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell { value = 3, other = 8 };
        Cell* pointer = &cell;
        int result = pointer->value;
        Check(result == 3, "pointer-member-is-primary-expression-in-unsafe-code");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
