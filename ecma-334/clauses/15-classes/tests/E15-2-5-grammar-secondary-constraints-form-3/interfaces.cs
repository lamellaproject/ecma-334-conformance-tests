/*
Rules: E15-2-5-grammar-secondary-constraints-form-3
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: where T : ILeft, IRight
Into: where T : ILeft
*/
using System;
interface ILeft { int Left(); }
interface IRight { int Right(); }
class Record : ILeft, IRight { public int Left() { return 11; } public int Right() { return 17; } }
class Program
{
    static void Read<T>(T value, out int left, out int right) where T : ILeft, IRight
    { left = value.Left(); right = value.Right(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int left, right;
        Read(new Record(), out left, out right);
        Check(left == 11, "first-interface-member");
        Check(right == 17, "appended-interface-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
