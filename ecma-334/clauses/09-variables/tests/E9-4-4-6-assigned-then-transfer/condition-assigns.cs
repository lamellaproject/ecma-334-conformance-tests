/*
Rules: E9-4-4-6-assigned-then-transfer; E9-4-4-6-assigned-false-transfer; E9-4-4-6-condition-entry
Authority: ECMA-334 7th ed 9.4.4.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: if ((cell = source) > 0)
Into: if (source > 0)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(int source)
    {
        int cell;
        if ((cell = source) > 0) return cell;
        else return cell;
    }
    static void Main()
    {
        Check(Read(18) == 18, "assignment-transferred-to-then");
        Check(Read(-23) == -23, "assignment-transferred-to-else");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
