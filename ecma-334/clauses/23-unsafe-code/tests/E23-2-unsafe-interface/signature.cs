/*
Rules: E23-2-unsafe-interface; E23-2-interface-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: unsafe interface Contract
Into: interface Contract
*/
using System;
unsafe interface Contract { int* Identity(int* value); }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {

        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
