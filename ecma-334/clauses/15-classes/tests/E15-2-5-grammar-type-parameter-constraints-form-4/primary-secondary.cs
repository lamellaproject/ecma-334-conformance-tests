/*
Rules: E15-2-5-grammar-type-parameter-constraints-form-4
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : class, IReading
Into: where T : class
*/
using System;
interface IReading { int Read(); }
class Record : IReading { public int Read() { return 89; } }
class Program
{
    static int Read<T>(T value) where T : class, IReading { return value.Read(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read(new Record()) == 89, "primary-and-secondary-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
