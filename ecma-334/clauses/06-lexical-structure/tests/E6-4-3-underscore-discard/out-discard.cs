/*
Rules: E6-4-3-underscore-discard
Authority: ECMA-334 7th ed 6.4.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: out _
Into: out absent
*/
using System;
class Program
{
    static int checks, failures, visits;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Supply(out int value) { visits++; value = 61; return true; }
    static void Main()
    {
        bool supplied = Supply(out _);
        Check(supplied && visits == 1, "underscore-without-a-declaration");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
