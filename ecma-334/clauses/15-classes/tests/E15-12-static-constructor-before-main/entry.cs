/*
Rules: E15-12-static-constructor-before-main
Authority: ECMA-334 7th ed 15.12
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: static Program() { Started = 13; }
Into: Program() { Started = 13; }
*/
using System;

class Program
{
    static int checks, failures;
    static int Started;
    static Program() { Started = 13; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Started == 13, "entry-class-static-constructor-before-main");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
