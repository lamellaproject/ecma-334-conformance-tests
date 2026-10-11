/*
Rules: E23-6-5-address-no-assignment-prerequisite; E23-6-5-address-definite-assignment
Authority: ECMA-334 7th ed 23.6.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int* pointer = &value;
Into: int* pointer = (int*)value;
*/
using System;
unsafe class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Write(bool flag)
    {
        int value;
        if (flag)
        {
            int* pointer = &value;
            *pointer = 47;
            return value;
        }
        return 0;
    }
    static void Main()
    {
        Check(Write(true) == 47, "address-establishes-assignment-on-path");
        Check(Write(false) == 0, "untaken-address-path");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
