/*
Rules: E9-4-4-27-true-both-exit
Authority: ECMA-334 7th ed 9.4.4.27
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: first && (cell = 11) > 0
Into: first || (cell = 11) > 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool first, bool second)
    {
        int cell;
        if ((first && (cell = 11) > 0) || (second && (cell = 22) > 0)) return cell;
        return -1;
    }
    static void Main()
    {
        Check(Read(true, false) == 11, "or-true-from-first-operand");
        Check(Read(false, true) == 22, "or-true-from-second-operand");
        Check(Read(false, false) == -1, "or-false-without-reading-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
