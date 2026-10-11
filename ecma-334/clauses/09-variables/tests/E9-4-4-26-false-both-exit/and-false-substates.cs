/*
Rules: E9-4-4-26-false-both-exit
Authority: ECMA-334 7th ed 9.4.4.26
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: first || (cell = 11) < 0
Into: first && (cell = 11) < 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool first, bool second)
    {
        int cell;
        if ((first || (cell = 11) < 0) && (second || (cell = 22) < 0)) return -1;
        return cell;
    }
    static void Main()
    {
        Check(Read(false, false) == 11, "and-false-from-first-operand");
        Check(Read(true, false) == 22, "and-false-from-second-operand");
        Check(Read(true, true) == -1, "and-true-without-reading-variable");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
