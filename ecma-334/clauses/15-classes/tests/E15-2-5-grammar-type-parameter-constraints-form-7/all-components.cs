/*
Rules: E15-2-5-grammar-type-parameter-constraints-form-7
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : Root, IReading, new()
Into: where T : Root, IReading
*/
using System;
class Root { public int Number = 7; }
interface IReading { int Read(); }
class Record : Root, IReading { public int Read() { return 103; } }
class Program
{
    static int Read<T>() where T : Root, IReading, new()
    { T value = new T(); return value.Number + value.Read(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read<Record>() == 110, "primary-secondary-and-constructor-constraints");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
