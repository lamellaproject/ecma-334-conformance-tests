/*
Rules: E9-4-4-7-default-section-transfer; E9-4-4-7-other-unguarded-transfer
Authority: ECMA-334 7th ed 9.4.4.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: switch (slot = input)
Into: switch (input)
*/
using System;
class Program
{
    static int checks, failures, next = 2;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Next() { next += 5; return next; }
    static int Read(int input)
    {
        int slot;
        switch (slot = input)
        {
            case 7: return slot;
            default: return slot;
        }
    }
    static void Main()
    {
        Check(Read(Next()) == 7, "assignment-reaches-ordinary-case");
        Check(Read(Next()) == 12, "assignment-reaches-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
