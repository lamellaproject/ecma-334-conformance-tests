/*
Rules: E9-4-4-6-false-state-if-end
Authority: ECMA-334 7th ed 9.4.4.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: cell = 17;
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool gate)
    {
        int cell;
        if (gate || (cell = 0) > 0) cell = 17;
        return cell;
    }
    static void Main()
    {
        Check(Read(true) == 17, "then-assignment-joins-with-false-substate");
        Check(Read(false) == 0, "false-condition-assignment-reaches-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
