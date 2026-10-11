/*
Rules: E9-4-4-7-other-guard-entry; E9-4-4-7-default-section-transfer; E9-4-4-7-other-unguarded-transfer
Authority: ECMA-334 7th ed 9.4.4.7
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: switch (cell = source)
Into: switch (source)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(int source)
    {
        int cell;
        switch (cell = source)
        {
            case 8 when cell > 0: return cell;
            case 0: return cell;
            default: return cell;
        }
    }
    static void Main()
    {
        Check(Read(8) == 8, "guard-entry-after-control-expression");
        Check(Read(0) == 0, "unguarded-entry-after-control-expression");
        Check(Read(27) == 27, "default-entry-after-control-expression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
