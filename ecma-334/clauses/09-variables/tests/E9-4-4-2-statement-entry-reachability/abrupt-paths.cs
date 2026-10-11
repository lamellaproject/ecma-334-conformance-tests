/*
Rules: E9-4-4-2-statement-entry-reachability; E9-4-4-2-statement-end-reachability
Authority: ECMA-334 7th ed 9.4.4.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: if (leave) return -1;
Into: if (leave) goto Join;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(bool leave)
    {
        int cell;
        if (leave) return -1;
        else { cell = 25; }
        Join: return cell;
    }
    static void Main()
    {
        Check(Read(true) == -1, "abrupt-path-does-not-join");
        Check(Read(false) == 25, "only-reachable-end-assigned");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
