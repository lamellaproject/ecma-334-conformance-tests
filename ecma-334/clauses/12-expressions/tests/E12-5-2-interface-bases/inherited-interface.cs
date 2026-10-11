/*
Rules: E12-5-2-interface-bases
Authority: ECMA-334 7th ed 12.5.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: interface IDerived : IBase
Into: interface IDerived
*/
using System;
interface IBase { int Read(); }
interface IDerived : IBase { }
class Box : IDerived { public int Read() { return 31; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IDerived receiver = new Box();
        Check(receiver.Read() == 31, "base-interface-member");
        Check(receiver.Equals(receiver), "interface-object-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
