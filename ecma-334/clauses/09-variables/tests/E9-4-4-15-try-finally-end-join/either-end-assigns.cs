/*
Rules: E9-4-4-15-try-finally-end-join
Authority: ECMA-334 7th ed 9.4.4.15
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: finally { cell = 66; }
Into: finally { }
*/
using System;
class Program
{
    static int checks, failures, trace;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int TryAssigns()
    {
        int cell;
        try { cell = 47; }
        finally { trace++; }
        return cell;
    }
    static int FinallyAssigns()
    {
        int cell;
        try { trace += 10; }
        finally { cell = 66; }
        return cell;
    }
    static void Main()
    {
        Check(TryAssigns() == 47 && trace == 1, "try-assignment-reaches-end");
        Check(FinallyAssigns() == 66 && trace == 11, "finally-assignment-reaches-end");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
