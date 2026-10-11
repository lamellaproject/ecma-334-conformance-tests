/*
Rules: E23-4-fixed-value-parameter
Authority: ECMA-334 7th ed 23.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int* p = &value;
Into: int* p = &other;
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read(int value)
    {
        int other = 3;
        int* p = &value;
        return *p;
    }
    static void Main()
    {
        Check(Read(29) == 29, "value-parameter-address");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
