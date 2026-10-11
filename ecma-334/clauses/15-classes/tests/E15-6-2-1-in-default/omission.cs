/*
Rules: E15-6-2-1-in-default
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: in int value = 37
Into: in int value = 41
*/
using System;
class Program
{
    static int Read(in int value = 37) { return value; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = 43;
        Check(Read() == 37, "omitted-input-argument-uses-default");
        Check(Read(in value) == 43, "explicit-input-argument-overrides-default");
        Check(Read(47) == 47, "ordinary-input-argument-overrides-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
