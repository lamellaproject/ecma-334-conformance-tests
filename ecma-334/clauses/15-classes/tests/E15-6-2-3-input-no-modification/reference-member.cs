/*
Rules: E15-6-2-3-input-no-modification
Authority: ECMA-334 7th ed 15.6.2.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static void Edit(in Box value)
Into: static void Edit(out Box value)
*/
using System;
class Box { public int Number; }
class Program
{
    static void Edit(in Box value) { value.Number = 67; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box value = new Box();
        Box original = value;
        Edit(in value);
        Check(value == original, "input-reference-value-remains-unchanged");
        Check(value.Number == 67, "object-behind-readonly-input-reference-remains-mutable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
