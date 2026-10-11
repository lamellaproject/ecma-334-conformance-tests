/*
Rules: E13-6-4-assignment-on-return
Authority: ECMA-334 7th ed 13.6.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: void Assign() { state = 6; }
Into: void Assign() { }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int state;
        void Assign() { state = 6; }
        Assign();
        Check(state == 6, "local-function-return-definitely-assigns-capture");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
