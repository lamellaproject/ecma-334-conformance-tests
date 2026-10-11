/*
Rules: E18-4-6-explicit-cast-disambiguation
Authority: ECMA-334 7th ed 18.4.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ((ILeft)view).Read()
Into: view.Read()
*/
using System;
interface ILeft { int Read(); }
interface IRight { int Read(); }
interface IBoth : ILeft, IRight { }
class Both : IBoth
{
    int ILeft.Read() { return 137; }
    int IRight.Read() { return 139; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IBoth view = new Both();
        Check(((ILeft)view).Read() == 137, "left-cast-resolves-ambiguity");
        Check(((IRight)view).Read() == 139, "right-cast-resolves-ambiguity");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
