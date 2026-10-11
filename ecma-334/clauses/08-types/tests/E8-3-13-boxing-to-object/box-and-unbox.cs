/*
Rules: E8-3-13-boxing-to-object; E8-3-13-unboxing-from-object
Authority: ECMA-334 7th ed 8.3.13
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: object boxed = source;
Into: object boxed = new Sample();
*/
using System;
struct Sample { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Sample source = new Sample(); source.Value = 24;
        object boxed = source; source.Value = 61;
        Sample result = (Sample)boxed;
        Check(result.Value == 24 && source.Value == 61, "box-copy-unbox-value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
