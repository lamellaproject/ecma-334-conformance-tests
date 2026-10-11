/*
Rules: E9-4-4-29-constant-null-exit
Authority: ECMA-334 7th ed 9.4.4.29
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (string)null
Into: "left"
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static string Right(out int value) { value = 24; return "right"; }
    static void Main()
    {
        int cell;
        string result = (string)null ?? Right(out cell);
        Check(cell == 24 && result == "right", "constant-null-propagates-right-operand-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
