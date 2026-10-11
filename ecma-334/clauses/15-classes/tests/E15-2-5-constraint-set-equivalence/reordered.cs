/*
Rules: E15-2-5-constraint-set-equivalence
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: where T : class, IRight, ILeft, new()
Into: where T : class, IRight, new()
*/
using System;
interface ILeft { int Left(); }
interface IRight { int Right(); }
class Record : ILeft, IRight { public int Left() { return 41; } public int Right() { return 43; } }
partial class Box<T> where T : class, ILeft, IRight, new() { public static T Make() { return new T(); } }
partial class Box<T> where T : class, IRight, ILeft, new() { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Record item = Box<Record>.Make();
        Check(item.Left() == 41, "equivalent-constraint-set-first-interface");
        Check(item.Right() == 43, "equivalent-constraint-set-second-interface");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
