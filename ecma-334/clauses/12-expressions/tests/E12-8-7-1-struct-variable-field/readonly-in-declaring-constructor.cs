/*
Rules: E12-8-7-1-struct-variable-field
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Touch(ref this.value);
Into: Touch(ref copy);
*/
using System;
struct Cell
{
    public readonly int value;
    public Cell(int input)
    {
        value = input;
        int copy = value;
        Touch(ref this.value);
    }
    static void Touch(ref int value) { value++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Cell(3).value == 4, "readonly-struct-field-is-variable-in-declaring-instance-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
