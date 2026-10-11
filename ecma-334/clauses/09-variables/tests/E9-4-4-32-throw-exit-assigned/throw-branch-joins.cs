/*
Rules: E9-4-4-32-throw-exit-assigned
Authority: ECMA-334 7th ed 9.4.4.32
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (cell = 46)
Into: 46
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool fail)
    {
        int cell;
        int ignored = fail ? throw new Exception() : (cell = 46);
        return cell;
    }
    static void Main()
    {
        Check(Read(false) == 46, "normal-branch-assigned-after-throw-expression-join");
        bool thrown = false;
        try { Read(true); }
        catch (Exception) { thrown = true; }
        Check(thrown, "throw-branch-exits-with-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
