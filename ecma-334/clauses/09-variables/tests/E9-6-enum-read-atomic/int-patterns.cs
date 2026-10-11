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
enum Token : int { First = 0x55AA55AA, Second = unchecked((int)0xAA55AA55u), Third = 0 }
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
        Check(valid, "int-enum-read-observes-whole-values");
        Check(shared == Token.First || shared == Token.Second, "int-enum-final-write-is-whole");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
