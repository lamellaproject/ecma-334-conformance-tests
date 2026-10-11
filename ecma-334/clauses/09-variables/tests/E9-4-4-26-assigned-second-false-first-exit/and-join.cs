/*
Rules: E9-4-4-26-assigned-second-false-first-exit
Authority: ECMA-334 7th ed 9.4.4.26
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (cell = 9) > 0
Into: true
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool gate)
    {
        int cell;
        bool result = (gate || (cell = 3) < 0) && ((cell = 9) > 0);
        return cell + (result ? 100 : 0);
    }
    static void Main()
    {
        Check(Read(true) == 109, "second-assigned-on-first-true");
        Check(Read(false) == 3, "first-assigned-on-first-false");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
