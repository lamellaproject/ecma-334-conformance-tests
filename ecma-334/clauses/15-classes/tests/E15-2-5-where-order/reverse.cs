/*
Rules: E15-2-5-where-order; E15-2-5-grammar-type-parameter-constraints-clauses-form-2
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where U : struct where T : IReading
Into: where U : struct
*/
using System;
interface IReading { int Read(); }
class Record : IReading { public int Read() { return 107; } }
class Pair<T,U> where U : struct where T : IReading
{ public static int Read(T item, U value) { return item.Read(); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Pair<Record,int>.Read(new Record(), 5) == 107, "where-clauses-in-reverse-parameter-order");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
