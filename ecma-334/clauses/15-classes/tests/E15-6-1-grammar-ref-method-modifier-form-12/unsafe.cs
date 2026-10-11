/*
Rules: E15-6-1-grammar-ref-method-modifier-form-12
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public unsafe int Read()
Into: public int Read()
*/
using System;
class Holder
{
    public unsafe int Read() { int value = 53; int* pointer = &value; return *pointer; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Holder().Read() == 53, "unsafe-method-context-permits-pointer-operations");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
