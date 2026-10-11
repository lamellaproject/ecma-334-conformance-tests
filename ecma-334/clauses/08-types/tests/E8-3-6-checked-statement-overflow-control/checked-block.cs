/*
Rules: E8-3-6-checked-statement-overflow-control; E8-3-6-checked-overflow-runtime
Authority: ECMA-334 7th ed 8.3.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: checked {
Into: unchecked {
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = int.MaxValue; bool correct = false;
        try { checked { value += 1; } }
        catch (OverflowException) { correct = true; }
        catch (Exception) { }
        Check(correct, "checked-statement-overflow");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
