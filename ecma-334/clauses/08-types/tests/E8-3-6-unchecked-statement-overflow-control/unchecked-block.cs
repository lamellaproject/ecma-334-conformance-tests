/*
Rules: E8-3-6-unchecked-statement-overflow-control; E8-3-6-unchecked-overflow-truncation
Authority: ECMA-334 7th ed 8.3.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unchecked {
Into: checked {
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        uint value = uint.MaxValue;
        unchecked { value += 1; }
        Check(value == 0U, "unchecked-statement-high-bits-truncated");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
