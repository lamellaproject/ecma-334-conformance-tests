/*
Rules: E7-6-method-signature-name
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: static int Write(int value)
Into: static int Read(int value)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(int value) { return value + 1; }
    static int Write(int value) { return value + 2; }
    static void Main()
    {
        Check(Read(5) == 6, "first-name");
        Check(Write(5) == 7, "second-name-with-same-parameter-types");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
