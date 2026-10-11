/*
Rules: E9-4-4-7-unreachable-guard-assigned
Authority: ECMA-334 7th ed 9.4.4.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: switch (0)
Into: switch (1)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read()
    {
        int cell;
        switch (0)
        {
            case 1 when cell > 0: return cell;
            default: return 23;
        }
    }
    static void Main()
    {
        Check(Read() == 23, "unreachable-guard-does-not-demand-assignment");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
