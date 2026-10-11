/*
Rules: E9-2-9-declaration-in-switch
Authority: ECMA-334 7th ed 9.2.9
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int cell = 18;
Into: int cell = 0;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(int key)
    {
        switch (key)
        {
            case 1: int cell = 18; return cell;
            default: return 7;
        }
    }
    static void Main()
    {
        Check(Read(1) == 18, "switch-block-local-declaration");
        Check(Read(0) == 7, "other-switch-path");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
