/*
Rules: E13-1-embedded-lock
Authority: ECMA-334 7th ed 13.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: lock (gate) mark++;
Into: lock (gate) ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object gate = new object();
        int mark = 0;
        if (true) lock (gate) mark++;
        Check(mark == 1, "embedded-lock-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
