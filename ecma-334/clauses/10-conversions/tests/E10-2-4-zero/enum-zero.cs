/*
Rules: E10-2-4-zero
Authority: ECMA-334 7th ed 10.2.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: State result = 0;
Into: State result = 1;
*/
using System;
enum State { None, Ready }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        State result = 0;
        Check(result == State.None, "enum-zero/value");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
