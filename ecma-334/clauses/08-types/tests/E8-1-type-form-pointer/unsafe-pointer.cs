/*
Rules: E8-1-type-form-pointer
Authority: ECMA-334 7th ed 8.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe class Pointer
Into: class Pointer
*/
using System;
unsafe class Pointer { public static int Read() { int value = 43; int* p = &value; return *p; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pointer.Read() == 43, "pointer-type-in-unsafe-code");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
