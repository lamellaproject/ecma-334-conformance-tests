/*
Rules: E8-2-6-interface-contract; E8-2-6-multiple-base-interfaces; E8-2-6-multiple-interface-implementation
Authority: ECMA-334 7th ed 8.2.6
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: public int ReadRight() { return 27; }
Into: public int ReadRight() { return 28; }
*/
using System;
interface ILeft { int ReadLeft(); }
interface IRight { int ReadRight(); }
interface IMerged : ILeft, IRight { }
class Device : IMerged, ILeft, IRight { public int ReadLeft() { return 12; } public int ReadRight() { return 27; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IMerged merged = new Device(); ILeft left = merged; IRight right = merged;
        Check(left.ReadLeft() == 12 && right.ReadRight() == 27, "multiple-interface-contracts");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
