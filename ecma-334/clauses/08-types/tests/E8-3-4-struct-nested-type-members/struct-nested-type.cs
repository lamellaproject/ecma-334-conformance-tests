/*
Rules: E8-3-4-struct-nested-type-members
Authority: ECMA-334 7th ed 8.3.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return 44;
Into: return 45;
*/
using System;
struct Sample { public class Inner { public int Read() { return 44; } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Sample.Inner inner = new Sample.Inner();
        Check(inner.Read() == 44, "struct-nested-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
