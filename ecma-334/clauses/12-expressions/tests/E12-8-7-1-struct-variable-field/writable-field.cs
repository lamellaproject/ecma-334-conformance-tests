/*
Rules: E12-8-7-1-struct-variable-field
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Touch(ref cell.value);
Into: Touch(ref copy);
*/
using System;
struct Cell { public int value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Touch(ref int value) { value++; }
    static void Main()
    {
        Cell cell = new Cell { value = 3 };
        int copy = cell.value;
        Touch(ref cell.value);
        Check(cell.value == 4, "struct-instance-field-member-access-refers-to-field-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
