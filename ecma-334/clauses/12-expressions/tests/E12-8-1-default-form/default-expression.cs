/*
Rules: E12-8-1-default-form
Authority: ECMA-334 7th ed 12.8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: default(Cell)
Into: new Cell { value = 8 }
*/
using System;
struct Cell { public int value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell result = default(Cell);
        Check(result.value == 0, "default-value-is-primary-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
