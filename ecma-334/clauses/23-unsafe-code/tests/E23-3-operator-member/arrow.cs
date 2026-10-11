/*
Rules: E23-3-operator-member
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int observed = p->First;
Into: int observed = p->Second;
*/
using System;
struct Pair { public int First, Second; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            Pair value = new Pair { First = 7, Second = 11 };
            Pair* p = &value;
            int observed = p->First;
            Check(observed == 7, "pointer-member-access");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
