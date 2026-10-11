/*
Rules: E15-2-5-interface-union
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: where S : ILeft, T
Into: where S : ILeft
*/
using System;
interface ILeft { int Left(); }
interface IRight { int Right(); }
class Record : ILeft, IRight { public int Left() { return 31; } public int Right() { return 37; } }
class Program
{
    static void Read<S,T>(S value, out int left, out int right) where S : ILeft, T where T : IRight
    { left = value.Left(); right = value.Right(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int left, right;
        Read<Record,IRight>(new Record(), out left, out right);
        Check(left == 31, "mixed-constraints-direct-interface-member");
        Check(right == 37, "mixed-constraints-dependent-interface-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
