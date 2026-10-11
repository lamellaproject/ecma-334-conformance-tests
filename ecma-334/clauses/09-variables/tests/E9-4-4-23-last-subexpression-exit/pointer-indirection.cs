/*
Rules: E9-4-4-23-last-subexpression-exit; E9-4-4-23-embedded-expression-scope
Authority: ECMA-334 7th ed 9.4.4.23
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: *(pointer = &cell)
Into: *(&cell)
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell = 39;
        int* pointer;
        int result = *(pointer = &cell);
        Check(result == 39 && *pointer == 39, "indirection-operand-assignment-exit");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
