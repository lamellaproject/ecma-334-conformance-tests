/*
Rules: E9-6-enum-read-atomic; E9-6-enum-write-atomic
Authority: ECMA-334 7th ed 9.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: shared = Token.Second;
Into: shared = Token.Third;
*/
using System;
using System.Threading;
enum Token : short { First = 21930, Second = -21931, Third = 0 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static Token shared = Token.First;
    static void Write()
    {
        for (int i = 0; i < 200000; i++) { shared = Token.First; shared = Token.Second; }
    }
    static void Main()
    {
        Thread writer = new Thread(Write);
        writer.Start();
        bool valid = true;
        for (int i = 0; i < 200000; i++)
        {
            Token observed = shared;
            if (observed != Token.First && observed != Token.Second) valid = false;
        }
        writer.Join();
        Check(valid, "short-enum-read-observes-whole-values");
        Check(shared == Token.First || shared == Token.Second, "short-enum-final-write-is-whole");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
