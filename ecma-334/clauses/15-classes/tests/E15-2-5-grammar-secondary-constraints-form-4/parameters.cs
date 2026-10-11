/*
Rules: E15-2-5-grammar-secondary-constraints-form-4; E15-2-5-interface-dependent; E15-2-5-effective-interface
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: where S : T, U
Into: where S : T
*/
using System;
interface ILeft { int Left(); }
interface IRight { int Right(); }
class Record : ILeft, IRight { public int Left() { return 13; } public int Right() { return 19; } }
class Program
{
    static int Read<S,T,U>(S value) where S : T, U where T : ILeft where U : IRight
    { return value.Left() + value.Right(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Read<Record,ILeft,IRight>(new Record()) == 32, "union-of-parameter-interface-sets");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
