/*
Rules: E15-2-5-constraint-constructed-parameters
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: where S : IValues<T,U>
Into: 
*/
using System;
interface IValues<A,B> { void Read(out A first, out B second); }
class Record : IValues<int,short>
{ public void Read(out int first, out short second) { first = 151; second = 23; } }
class Program
{
    static void Read<S,T,U>(S value, out T first, out U second) where S : IValues<T,U>
    { value.Read(out first, out second); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int first; short second;
        Read<Record,int,short>(new Record(), out first, out second);
        Check(first == 151, "constructed-constraint-first-parameter");
        Check(second == 23, "constructed-constraint-second-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
