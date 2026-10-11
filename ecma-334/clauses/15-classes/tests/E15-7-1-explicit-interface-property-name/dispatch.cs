/*
Rules: E15-7-1-explicit-interface-property-name
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int IBox.Item => 22;
Into: int IBox.Item => 23;
*/
using System;
interface IBox { int Item { get; } }
class Box : IBox { int IBox.Item => 22; public int Item => 41; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        Check(box.Item == 41, "ordinary-name");
        Check(((IBox)box).Item == 22, "qualified-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
