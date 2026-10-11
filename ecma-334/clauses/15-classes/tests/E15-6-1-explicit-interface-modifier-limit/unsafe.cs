/*
Rules: E15-6-1-explicit-interface-modifier-limit
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: unsafe int IReader.Read()
Into: int IReader.Read()
*/
using System;
// 15.6.1, p. 396, read with 23.2, pp. 547-548:
// clause 23 extends every member declaration with unsafe.
interface IReader { int Read(); }
class Holder : IReader
{
    unsafe int IReader.Read() { int value = 53; int* pointer = &value; return *pointer; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IReader reader = new Holder();
        Check(reader.Read() == 53, "explicit-unsafe-pointer-read");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
