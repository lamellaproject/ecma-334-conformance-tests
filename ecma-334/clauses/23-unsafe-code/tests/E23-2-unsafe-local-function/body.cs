/*
Rules: E23-2-unsafe-local-function; E23-2-local-function-context
Authority: ECMA-334 7th ed 23.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe int Read()
Into: int Read()
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe int Read() { int value = 29; int* p = &value; return *p; }
        Check(Read() == 29, "unsafe-local-function");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
