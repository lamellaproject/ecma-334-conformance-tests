/*
Rules: E18-2-2-modifier-unsafe
Authority: ECMA-334 7th ed 18.2.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe interface IRead
Into: interface IRead
*/
using System;
unsafe interface IRead { int* Read(); }
unsafe class Reader : IRead
{
    int* value;
    public Reader(int* value) { this.value = value; }
    public int* Read() { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int value = 37;
        IRead reader = new Reader(&value);
        Check(*reader.Read() == 37, "unsafe-interface-pointer-return");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
