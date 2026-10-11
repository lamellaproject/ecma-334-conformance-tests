/*
Rules: E13-1-embedded-fixed
Authority: ECMA-334 7th ed 13.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: pointer[1] = 11;
Into: pointer[0] = 11;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int[] data = { 2, 3 };
        if (true) fixed (int* pointer = data) { pointer[1] = 11; }
        Check(data[0] == 2 && data[1] == 11, "embedded-fixed-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
