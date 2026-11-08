/*
Rules: E9-4-4-27-ed3-or-second-entry
Authority: ECMA-334 3rd ed 12.3.3.24
Version: ISO-2
Expected: run
Stdout: OK 2
Mutate: flag || (assigned = 29) < 0
Into: flag && (assigned = 29) < 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static bool Select(bool flag)
    {
        int assigned;
        return (flag || (assigned = 29) < 0) || assigned == 29;
    }
    static int Main()
    {
        Check(Select(false), "false-substate-enters-right");
        Check(Select(true), "true-path-skips-right");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
