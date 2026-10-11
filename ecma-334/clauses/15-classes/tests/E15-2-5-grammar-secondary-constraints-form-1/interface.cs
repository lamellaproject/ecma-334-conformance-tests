/*
Rules: E15-2-5-grammar-secondary-constraints-form-1; E15-2-5-grammar-type-parameter-constraints-form-2; E15-2-5-constrained-instance-members
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : IReading
Into: 
*/
using System;
interface IReading { int Read(); }
class Record : IReading { public int Read() { return 85; } }
class Program
{
    static int Read<T>(T value) where T : IReading { return value.Read(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read(new Record()) == 85, "secondary-interface-member-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
