/*
Rules: E9-4-4-5-initialized-declaration-transfer
Authority: ECMA-334 7th ed 9.4.4.5
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E9-4-4-5-initialized-declaration-transfer/bypassed-local-initializer.cs.part
Mutate: if (skip) goto Done;
Into: ;
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
    static int Read(bool skip)
    {
        if (skip) goto Done;
        int local = 41;
    Done:
        return local;
    }
    static int Main()
    {
        Check(Read(true) == 41 && Read(false) == 41, "initializer-must-execute");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
