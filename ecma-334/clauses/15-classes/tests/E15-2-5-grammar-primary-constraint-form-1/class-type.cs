/*
Rules: E15-2-5-grammar-primary-constraint-form-1; E15-2-5-grammar-type-parameter-constraints-form-1; E15-2-5-grammar-type-parameter-constraints-clauses-form-1; E15-2-5-grammar-type-parameter-constraints-clause; E15-2-5-optional-constraints
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where T : Record
Into: 
*/
using System;
class Record { public int Number = 83; }
class Program
{
    static int Read<T>(T value) where T : Record { return value.Number; }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read(new Record()) == 83, "primary-class-type-constraint");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
