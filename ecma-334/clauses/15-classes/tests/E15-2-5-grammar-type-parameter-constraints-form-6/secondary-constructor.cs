/*
Rules: E15-2-5-grammar-type-parameter-constraints-form-6
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : IReading, new()
Into: where T : IReading
*/
using System;
interface IReading { int Read(); }
class Record : IReading { public int Read() { return 101; } }
class Program
{
    static int Read<T>() where T : IReading, new() { return new T().Read(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read<Record>() == 101, "secondary-and-constructor-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
